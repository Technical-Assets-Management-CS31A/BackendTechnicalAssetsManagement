# Activity Logs API

Activity logs are **append-only audit records** automatically written whenever a borrow-related status transition occurs. You never POST to this API manually — you only read from it.

> **Quick distinction:**
>
> - `LentItems` = the transaction record (mutable, tracks current state)
> - `ActivityLog` = the audit trail (immutable, one new row per event)

---

## Authentication

All endpoints require a Bearer token with **Admin or Staff** role.

```
Authorization: Bearer <your_token>
```

---

## Base URL

```
/api/v1/activity-logs
```

---

## Endpoints

### 1. Get All Logs

```
GET /api/v1/activity-logs
```

Returns all activity logs. Every query parameter is optional — omit any to skip that filter.

**Query Parameters**

| Parameter     | Type     | Description                                    | Example                     |
| ------------- | -------- | ---------------------------------------------- | --------------------------- |
| `category`    | string   | Filter by log category (see values below)      | `?category=BorrowedItem`    |
| `from`        | datetime | Start of date range (inclusive)                | `?from=2026-04-01`          |
| `to`          | datetime | End of date range (inclusive)                  | `?to=2026-04-19`            |
| `actorUserId` | guid     | Filter by the user who performed the action    | `?actorUserId=3fa85f64-...` |
| `itemId`      | guid     | Filter by item                                 | `?itemId=3fa85f64-...`      |
| `status`      | string   | Filter by the resulting status after the event | `?status=Borrowed`          |

**Category Values**

| Value          | When it appears                                        |
| -------------- | ------------------------------------------------------ |
| `BorrowedItem` | Item was physically borrowed / borrow request made     |
| `Returned`     | Item was returned                                      |
| `Reserved`     | Item was reserved                                      |
| `Approved`     | Borrow request was approved by staff                   |
| `Denied`       | Borrow request was denied                              |
| `Canceled`     | Borrow request was canceled (manually or auto-expired) |
| `StatusChange` | Any other status transition                            |
| `General`      | Catch-all for events that don't fit above categories   |

**Example Requests**

```http
# All logs
GET /api/v1/activity-logs

# Only borrow events
GET /api/v1/activity-logs?category=BorrowedItem

# Date range
GET /api/v1/activity-logs?from=2026-04-01&to=2026-04-19

# Returned items in a date range
GET /api/v1/activity-logs?category=Returned&from=2026-04-01&to=2026-04-19

# All activity for a specific user
GET /api/v1/activity-logs?actorUserId=3fa85f64-5717-4562-b3fc-2c963f66afa6

# All activity for a specific item
GET /api/v1/activity-logs?itemId=3fa85f64-5717-4562-b3fc-2c963f66afa6

# Filter by resulting status
GET /api/v1/activity-logs?status=Borrowed
```

---

### 2. Get Single Log Entry

```
GET /api/v1/activity-logs/{id}
```

Returns one log entry by its ID.

```http
GET /api/v1/activity-logs/3fa85f64-5717-4562-b3fc-2c963f66afa6
```

**Responses**

| Status | Meaning             |
| ------ | ------------------- |
| `200`  | Log entry found     |
| `404`  | Log entry not found |

---

### 3. Get Borrow Logs

```
GET /api/v1/activity-logs/borrow-logs
```

Returns the full borrow lifecycle — combines `BorrowedItem` and `Returned` entries so you can trace a complete borrow-to-return journey for any item or user.

**Query Parameters**

| Parameter | Type     | Description         |
| --------- | -------- | ------------------- |
| `from`    | datetime | Start of date range |
| `to`      | datetime | End of date range   |
| `userId`  | guid     | Filter by borrower  |
| `itemId`  | guid     | Filter by item      |

**Example Requests**

```http
# All borrow lifecycle logs
GET /api/v1/activity-logs/borrow-logs

# For a specific date range
GET /api/v1/activity-logs/borrow-logs?from=2026-04-01&to=2026-04-19

# Everything borrowed/returned by a specific student
GET /api/v1/activity-logs/borrow-logs?userId=3fa85f64-5717-4562-b3fc-2c963f66afa6

# Full history of a specific item
GET /api/v1/activity-logs/borrow-logs?itemId=3fa85f64-5717-4562-b3fc-2c963f66afa6
```

---

## Response Shape

All endpoints return the standard `ApiResponse<T>` wrapper.

```json
{
  "success": true,
  "message": "Activity logs retrieved successfully.",
  "data": [
    {
      "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
      "category": "BorrowedItem",
      "action": "Borrow request created with status 'Borrowed'",
      "actorUserId": "a1b2c3d4-...",
      "actorName": "Juan Dela Cruz",
      "actorRole": "Student",
      "itemId": "e5f6a7b8-...",
      "itemName": "HDMI Cable",
      "itemSerialNumber": "SN-00123",
      "lentItemId": "c9d0e1f2-...",
      "previousStatus": null,
      "newStatus": "Borrowed",
      "borrowedAt": "2026-04-19 09:10",
      "returnedAt": null,
      "reservedFor": null,
      "remarks": null,
      "createdAt": "2026-04-19 09:10"
    }
  ],
  "errors": null
}
```

---

## How Logs Are Written

Logs are written **automatically** by the system — no manual API call needed. Every time a status transition happens in `LentItemsService`, a new log row is inserted.

| User Action                       | Endpoint called                     | Category logged |
| --------------------------------- | ----------------------------------- | --------------- |
| Student submits borrow request    | `POST /api/v1/lentItems`            | `BorrowedItem`  |
| Staff submits borrow for a guest  | `POST /api/v1/lentItems/guests`     | `BorrowedItem`  |
| Staff approves a request          | `PATCH /api/v1/lentItems/{id}`      | `Approved`      |
| Staff denies a request            | `PATCH /api/v1/lentItems/{id}`      | `Denied`        |
| Request is canceled               | `PATCH /api/v1/lentItems/{id}`      | `Canceled`      |
| Item physically taken (RFID scan) | `PATCH /api/v1/lentItems/scan/{id}` | `BorrowedItem`  |
| Item returned (RFID scan)         | `PATCH /api/v1/lentItems/scan/{id}` | `Returned`      |
| Any other status change           | any update endpoint                 | `StatusChange`  |

A single borrow cycle produces multiple log entries — one per event. This is intentional: the log is an immutable timeline, not a single record that gets overwritten.

---

## Database Migration

Before using this feature, run the EF Core migration to create the `ActivityLogs` table:

```bash
dotnet ef migrations add AddActivityLogs
dotnet ef database update
```
