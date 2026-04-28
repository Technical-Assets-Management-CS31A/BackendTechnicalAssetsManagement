/**
 * ESP32 + PN532 Item Return Sketch — Web-Triggered Session Mode
 *
 * Flow:
 *   1. Connect to WiFi + sync time
 *   2. Poll GET /api/v1/return-sessions/pending every 2s  ← idles until web triggers
 *   3. Session found → student taps item NFC tag
 *   4. GET /api/v1/items/rfid/{uid}           → resolve itemId + itemName
 *   5. GET /api/v1/lentItems/borrowed         → find active lent record for this item
 *   6. PATCH /api/v1/lentItems/{lentItemId}   → { status: "Returned", returnedAt: <now> }
 *   7. POST /api/v1/return-sessions/{id}/complete → report result back to web
 *   8. Reset → back to polling
 *
 * All endpoints are AllowAnonymous — no login required.
 *
 * Wiring (PN532 → ESP32) — I2C mode:
 *   VCC → 3.3V  |  GND → GND
 *   SDA → GPIO 21  |  SCL → GPIO 22
 *   IRQ → GPIO 4   |  RSTO → GPIO 2
 *
 * Libraries: Adafruit PN532, ArduinoJson
 */

#include <Wire.h>
#include <Adafruit_PN532.h>
#include <WiFi.h>
#include <HTTPClient.h>
#include <ArduinoJson.h>
#include <time.h>

// ── Config ────────────────────────────────────────────────────────────────────
#define WIFI_SSID           "EjGwapo2.4G"
#define WIFI_PASSWORD       "vigheadTHEG0D2.4G"
#define API_BASE_URL        "http://192.168.1.17:5289"

#define NTP_SERVER          "pool.ntp.org"
#define GMT_OFFSET_SEC      28800   // GMT+8 Philippines
#define DAYLIGHT_OFFSET_SEC 0

#define SCAN_COOLDOWN_MS    2000
#define POLL_INTERVAL_MS    2000

// ── PN532 ─────────────────────────────────────────────────────────────────────
#define PN532_IRQ   4
#define PN532_RESET 2

Adafruit_PN532 nfc(PN532_IRQ, PN532_RESET);

// ── State machine ─────────────────────────────────────────────────────────────
enum State { POLLING, WAIT_ITEM, SUBMITTING };

State  currentState  = POLLING;
String sessionId     = "";
String lastUid       = "";
unsigned long lastScanTime = 0;
unsigned long lastPollTime = 0;

// ─────────────────────────────────────────────────────────────────────────────

void setup() {
  Serial.begin(115200);
  delay(500);

  Serial.println("\n=== RFID Item Return Station (Session Mode) ===");

  nfc.begin();
  uint32_t ver = nfc.getFirmwareVersion();
  if (!ver) {
    Serial.println("ERROR: PN532 not found. Check wiring/I2C switches.");
    while (1);
  }
  Serial.printf("PN532 firmware v%d.%d\n", (ver >> 16) & 0xFF, (ver >> 8) & 0xFF);
  nfc.SAMConfig();

  connectWiFi();
  syncTime();

  Serial.println("\nPolling for return sessions from web...");
}

void loop() {
  unsigned long now = millis();

  // ── POLLING: wait for web to create a session ─────────────────────────────
  if (currentState == POLLING) {
    if (now - lastPollTime >= POLL_INTERVAL_MS) {
      lastPollTime = now;
      checkPendingSession();
    }
    return;
  }

  // ── SUBMITTING: blocked until processReturn() finishes ────────────────────
  if (currentState == SUBMITTING) return;

  // ── WAIT_ITEM: read item NFC tag ───────────────────────────────────────────
  uint8_t uid[7];
  uint8_t uidLength;
  if (!nfc.readPassiveTargetID(PN532_MIFARE_ISO14443A, uid, &uidLength, 1000)) return;

  String uidStr = getUidString(uid, uidLength);
  if (uidStr == lastUid && (now - lastScanTime) < SCAN_COOLDOWN_MS) return;
  lastUid      = uidStr;
  lastScanTime = now;

  Serial.printf("\nScanned tag: %s\n", uidStr.c_str());

  currentState = SUBMITTING;
  processReturn(uidStr);
  resetSession();
}

// ── WiFi ──────────────────────────────────────────────────────────────────────

void connectWiFi() {
  Serial.printf("Connecting to %s", WIFI_SSID);
  WiFi.begin(WIFI_SSID, WIFI_PASSWORD);
  while (WiFi.status() != WL_CONNECTED) { delay(500); Serial.print("."); }
  Serial.printf("\nConnected — IP: %s\n", WiFi.localIP().toString().c_str());
}

// ── NTP ───────────────────────────────────────────────────────────────────────

void syncTime() {
  Serial.print("Syncing time with NTP...");
  configTime(GMT_OFFSET_SEC, DAYLIGHT_OFFSET_SEC, NTP_SERVER);
  struct tm timeinfo;
  int attempts = 0;
  while (!getLocalTime(&timeinfo) && attempts < 10) { Serial.print("."); delay(1000); attempts++; }
  if (attempts >= 10) {
    Serial.println("\nWarning: NTP sync failed.");
  } else {
    char buf[32];
    strftime(buf, sizeof(buf), "%A %I:%M %p", &timeinfo);
    Serial.printf("\nTime synced: %s\n", buf);
  }
}

String getCurrentTimestamp() {
  struct tm timeinfo;
  if (!getLocalTime(&timeinfo)) return "";
  char buf[25];
  strftime(buf, sizeof(buf), "%Y-%m-%dT%H:%M:%S", &timeinfo);
  return String(buf);
}

// ── UID Helper ────────────────────────────────────────────────────────────────

String getUidString(uint8_t* buf, uint8_t len) {
  String s = "";
  for (uint8_t i = 0; i < len; i++) { if (buf[i] < 0x10) s += "0"; s += String(buf[i], HEX); }
  s.toUpperCase();
  return s;
}

// ── API Calls ─────────────────────────────────────────────────────────────────

// Poll GET /api/v1/return-sessions/pending — 204 = nothing, 200 = go
void checkPendingSession() {
  if (WiFi.status() != WL_CONNECTED) { connectWiFi(); }

  String url = String(API_BASE_URL) + "/api/v1/return-sessions/pending";
  HTTPClient http;
  http.setConnectTimeout(5000);
  http.setTimeout(10000);
  http.begin(url);

  int code = http.GET();
  String resp = http.getString();
  http.end();

  if (code == 204) return;  // nothing pending — keep polling silently
  if (code != 200) { Serial.printf("✗ Poll error: %d\n", code); return; }

  StaticJsonDocument<256> doc;
  deserializeJson(doc, resp);
  sessionId = doc["data"]["id"].as<String>();

  Serial.println("\n─────────────────────────────────────────");
  Serial.println("✓ Return session triggered from web!");
  Serial.printf("  Session ID: %s\n", sessionId.c_str());
  Serial.println("─────────────────────────────────────────");
  Serial.println("\nTap the item NFC tag on the scanner...");

  currentState = WAIT_ITEM;
}

// Full return flow: resolve item → find lent record → patch returned → complete session
void processReturn(const String& rfidUid) {
  if (WiFi.status() != WL_CONNECTED) { connectWiFi(); }

  // ── Step 1: resolve item from tag ─────────────────────────────────────────
  String itemUrl = String(API_BASE_URL) + "/api/v1/items/rfid/" + rfidUid;
  Serial.printf("GET %s\n", itemUrl.c_str());

  HTTPClient http1;
  http1.setConnectTimeout(5000);
  http1.setTimeout(10000);
  http1.begin(itemUrl);

  int itemCode = http1.GET();
  String itemResp = http1.getString();
  http1.end();

  Serial.printf("HTTP %d\n", itemCode);

  if (itemCode == 404) {
    Serial.println("✗ Item not registered.");
    completeSession(false, "", "", Guid_Empty(), "Item tag not registered.");
    return;
  }
  if (itemCode != 200) {
    Serial.printf("✗ Item lookup error: %d\n", itemCode);
    completeSession(false, "", "", Guid_Empty(), "Item lookup error " + String(itemCode));
    return;
  }

  StaticJsonDocument<512> itemDoc;
  deserializeJson(itemDoc, itemResp);
  String itemId   = itemDoc["data"]["id"].as<String>();
  String itemName = itemDoc["data"]["itemName"].as<String>();
  Serial.printf("✓ Item: %s (ID: %s)\n", itemName.c_str(), itemId.c_str());

  // ── Step 2: find active lent record for this item ─────────────────────────
  String borrowedUrl = String(API_BASE_URL) + "/api/v1/lentItems/borrowed";
  Serial.printf("GET %s\n", borrowedUrl.c_str());

  HTTPClient http2;
  http2.setConnectTimeout(5000);
  http2.setTimeout(10000);
  http2.begin(borrowedUrl);

  int borrowedCode = http2.GET();
  String borrowedResp = http2.getString();
  http2.end();

  Serial.printf("HTTP %d\n", borrowedCode);

  if (borrowedCode != 200) {
    Serial.printf("✗ Failed to get borrowed items: %d\n", borrowedCode);
    completeSession(false, itemName, "", Guid_Empty(), "Borrowed list error " + String(borrowedCode));
    return;
  }

  DynamicJsonDocument borrowedDoc(4096);
  DeserializationError err = deserializeJson(borrowedDoc, borrowedResp);
  if (err) {
    Serial.printf("✗ JSON parse error: %s\n", err.c_str());
    completeSession(false, itemName, "", Guid_Empty(), "JSON parse error.");
    return;
  }
  JsonArray lentItems = borrowedDoc["data"].as<JsonArray>();

  String lentItemId   = "";
  String borrowerName = "";

  for (JsonObject lent : lentItems) {
    if (String(lent["item"]["id"].as<String>()) == itemId) {
      lentItemId   = lent["id"].as<String>();
      borrowerName = lent["borrowerFullName"].as<String>();
      break;
    }
  }

  if (lentItemId.length() == 0) {
    Serial.println("✗ No active borrowed record found for this item.");
    completeSession(false, itemName, "", Guid_Empty(), "Item is not currently borrowed.");
    return;
  }

  Serial.printf("✓ Lent record: %s (Borrower: %s)\n", lentItemId.c_str(), borrowerName.c_str());

  // ── Step 3: mark as returned ───────────────────────────────────────────────
  String timestamp = getCurrentTimestamp();
  if (timestamp.length() == 0) {
    Serial.println("✗ Cannot get current time.");
    completeSession(false, itemName, borrowerName, Guid_Empty(), "NTP time unavailable.");
    return;
  }

  String patchUrl = String(API_BASE_URL) + "/api/v1/lentItems/" + lentItemId;
  Serial.printf("PATCH %s\n", patchUrl.c_str());

  StaticJsonDocument<128> patchDoc;
  patchDoc["status"]     = "Returned";
  patchDoc["returnedAt"] = timestamp;
  String patchBody;
  serializeJson(patchDoc, patchBody);

  HTTPClient http3;
  http3.setConnectTimeout(5000);
  http3.setTimeout(10000);
  http3.begin(patchUrl);
  http3.addHeader("Content-Type", "application/json");

  int patchCode = http3.PATCH(patchBody);
  http3.end();

  Serial.printf("PATCH HTTP %d\n", patchCode);

  if (patchCode == 200) {
    Serial.printf("✓ Item marked as RETURNED at %s\n", timestamp.c_str());
    completeSession(true, itemName, borrowerName, lentItemId, "");
  } else {
    Serial.printf("✗ Return failed: %d\n", patchCode);
    completeSession(false, itemName, borrowerName, Guid_Empty(), "PATCH error " + String(patchCode));
  }
}

// POST /api/v1/return-sessions/{id}/complete
void completeSession(bool success, const String& itemName, const String& borrowerName,
                     const String& lentItemId, const String& errorMsg) {
  if (WiFi.status() != WL_CONNECTED) { connectWiFi(); }

  String url = String(API_BASE_URL) + "/api/v1/return-sessions/" + sessionId + "/complete";
  Serial.printf("POST %s\n", url.c_str());

  StaticJsonDocument<256> doc;
  doc["success"]      = success;
  doc["itemName"]     = itemName;
  doc["borrowerName"] = borrowerName;
  if (success && lentItemId.length() > 0) doc["lentItemId"]   = lentItemId;
  if (!success)                           doc["errorMessage"] = errorMsg;
  String body;
  serializeJson(doc, body);

  HTTPClient http;
  http.setConnectTimeout(5000);
  http.setTimeout(10000);
  http.begin(url);
  http.addHeader("Content-Type", "application/json");

  int code = http.POST(body);
  http.end();

  Serial.printf("Session complete HTTP %d\n", code);
}

// Helper — returns empty string to use as a null GUID placeholder
String Guid_Empty() { return ""; }

// ── Session Reset ─────────────────────────────────────────────────────────────

void resetSession() {
  sessionId    = "";
  lastUid      = "";
  currentState = POLLING;

  Serial.println("\n── Session reset — polling for next request...\n");

  // Give the TCP stack time to fully close all connections before next poll
  delay(3000);

  // Force WiFi reconnect to clear any stale socket state
  if (WiFi.status() != WL_CONNECTED) {
    connectWiFi();
  } else {
    WiFi.disconnect(false);
    delay(500);
    WiFi.reconnect();
    unsigned long start = millis();
    while (WiFi.status() != WL_CONNECTED && millis() - start < 5000) {
      delay(200);
    }
    Serial.printf("WiFi ready — IP: %s\n", WiFi.localIP().toString().c_str());
  }
}
