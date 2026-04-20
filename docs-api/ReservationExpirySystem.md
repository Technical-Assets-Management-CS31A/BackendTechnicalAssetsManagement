# Reservation Expiry System

## Overview

The Reservation Expiry System automatically cancels reservations when users fail to pick up reserved items within the specified time window. When a reservation expires, the system:

1. **Cancels the reservation** - Sets status to "Canceled"
2. **Releases the item** - Sets item status back to "Available"
3. **Notifies the user** - Sends real-time SignalR notification to the mobile app
4. **Notifies admin/staff** - Alerts staff that the item is available again
5. **Logs the event** - Records the cancellation in the activity log

## Configuration

### Grace Period

- **Default**: 30 minutes after `ReservedFor` time
- **Location**: `src/Services/LentItemsService.cs` → `CancelExpiredReservationsAsync()`
- **Configurable**: Change `graceMinutes` variable

```csharp
var graceMinutes = 30; // Adjust as needed
```

### Check Interval

- **Default**: Every 5 minutes
- **Location**: `src/Services/ReservationExpiryBackgroundService.cs`
- **Configurable**: Change `_checkInterval` field

```csharp
private readonly TimeSpan _checkInterval = TimeSpan.FromMinutes(5);
```

## Architecture

### Components

#### 1. Background Service

**File**: `src/Services/ReservationExpiryBackgroundService.cs`

- Runs continuously as a hosted service
- Checks for expired reservations every 5 minutes
- Calls `ILentItemsService.CancelExpiredReservationsAsync()`

#### 2. Business Logic

**File**: `src/Services/LentItemsService.cs`

**Method**: `CancelExpiredReservationsAsync()`

**Logic Flow**:

```
1. Get current UTC time
2. Fetch all lent items
3. Filter expired reservations:
   - ReservedFor + 30 minutes < now
   - Status is Pending, Approved, or Reserved
   - LentAt is null (not picked up yet)
4. For each expired reservation:
   a. Update status to "Canceled"
   b. Set item back to "Available"
   c. Send SignalR notification
   d. Log the cancellation
5. Save all changes
6. Return count of canceled reservations
```

#### 3. Notification Service

**File**: `src/Services/NotificationService.cs`

**Method**: `SendReservationExpiredNotificationAsync()`

**Sends to**:

- User's personal group: `user_{userId}`
- Admin/staff group: `admin_staff`

**Event name**: `ReceiveReservationExpired`

#### 4. SignalR Hub

**File**: `src/Hubs/NotificationHub.cs`

**Endpoint**: `/notificationHub`

**Client Methods**:

- `JoinUserGroup(userId)` - Subscribe to personal notifications
- `JoinAdminStaffGroup()` - Subscribe to admin/staff notifications

## Database Schema

### LentItems Table

Relevant fields for reservation expiry:

| Field         | Type      | Description                                                            |
| ------------- | --------- | ---------------------------------------------------------------------- |
| `ReservedFor` | DateTime? | When the user plans to pick up the item                                |
| `LentAt`      | DateTime? | When the item was actually picked up (null = not picked up)            |
| `Status`      | string    | Current status (Pending, Approved, Reserved, Borrowed, Canceled, etc.) |
| `UserId`      | Guid?     | User who made the reservation                                          |
| `ItemId`      | Guid      | Item being reserved                                                    |

### Items Table

| Field    | Type       | Description                                          |
| -------- | ---------- | ---------------------------------------------------- |
| `Status` | ItemStatus | Available, Borrowed, Reserved, Unavailable, Archived |

## API Integration

### No Direct API Endpoint

The expiry system runs automatically in the background. No API endpoint is needed for triggering expiry.

### Related Endpoints

- `POST /api/v1/lentItems` - Create reservation (sets `ReservedFor`)
- `PATCH /api/v1/lentItems/{id}` - Update status (can manually cancel)
- `GET /api/v1/lentItems` - View all reservations

## Mobile Client Setup

### 1. Install SignalR Client

**Flutter**:

```yaml
dependencies:
  signalr_netcore: ^1.3.3
```

**React Native**:

```bash
npm install @microsoft/signalr
```

### 2. Connect to Hub

**Flutter Example**:

```dart
import 'package:signalr_netcore/signalr_client.dart';

// Initialize connection
final hubConnection = HubConnectionBuilder()
    .withUrl(
      'https://your-api.com/notificationHub',
      HttpConnectionOptions(
        accessTokenFactory: () async => await getAuthToken(),
      ),
    )
    .withAutomaticReconnect()
    .build();

// Listen for reservation expiry events
hubConnection.on('ReceiveReservationExpired', (args) {
  final notification = args?[0] as Map<String, dynamic>;

  // Show notification to user
  showNotification(
    title: 'Reservation Expired',
    body: notification['message'],
    data: notification,
  );

  // Update UI if on reservations screen
  refreshReservationsList();
});

// Start connection
await hubConnection.start();

// Join user's personal group
await hubConnection.invoke('JoinUserGroup', args: [userId]);
```

**React Native Example**:

```typescript
import * as signalR from "@microsoft/signalr";

// Initialize connection
const connection = new signalR.HubConnectionBuilder()
  .withUrl("https://your-api.com/notificationHub", {
    accessTokenFactory: () => getAuthToken(),
  })
  .withAutomaticReconnect()
  .build();

// Listen for reservation expiry events
connection.on("ReceiveReservationExpired", (notification) => {
  // Show push notification
  PushNotification.localNotification({
    title: "Reservation Expired",
    message: notification.message,
    data: notification,
  });

  // Update UI
  refreshReservations();
});

// Start connection
await connection.start();

// Join user's personal group
await connection.invoke("JoinUserGroup", userId);
```

### 3. Notification Payload

```typescript
interface ReservationExpiredNotification {
  type: "reservation_expired";
  lentItemId: string;
  itemName: string;
  borrowerName: string;
  reservedFor: string; // ISO 8601 datetime
  message: string;
  timestamp: string; // ISO 8601 datetime
}
```

**Example**:

```json
{
  "type": "reservation_expired",
  "lentItemId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "itemName": "Projector A",
  "borrowerName": "Juan Dela Cruz",
  "reservedFor": "2026-04-20T10:00:00Z",
  "message": "Your reservation for 'Projector A' has expired because it was not picked up in time. The item is now available again.",
  "timestamp": "2026-04-20T10:30:05Z"
}
```

### 4. Handle Disconnection

```dart
// Flutter
hubConnection.onclose((error) {
  print('Connection closed: $error');
  // Attempt to reconnect
  Future.delayed(Duration(seconds: 5), () {
    hubConnection.start();
  });
});
```

```typescript
// React Native
connection.onclose((error) => {
  console.log("Connection closed:", error);
  // Automatic reconnect is handled by withAutomaticReconnect()
});
```

## Admin/Staff Dashboard Setup

### 1. Connect and Join Admin Group

```typescript
// After successful connection
await connection.start();

// Check if user is admin/staff
if (userRole === "Admin" || userRole === "Staff" || userRole === "SuperAdmin") {
  await connection.invoke("JoinAdminStaffGroup");
}
```

### 2. Listen for Expiry Events

```typescript
connection.on("ReceiveReservationExpired", (notification) => {
  // Show toast notification
  toast.info(`${notification.itemName} is now available (reservation expired)`);

  // Update pending reservations list
  removePendingReservation(notification.lentItemId);

  // Update available items list
  markItemAsAvailable(notification.itemName);
});
```

## Testing

### Manual Testing

#### Test Scenario 1: Reservation Expires

1. Create a reservation with `ReservedFor` = current time + 5 minutes
2. Wait 35 minutes (5 min reservation time + 30 min grace period)
3. Wait up to 5 minutes for background service to run
4. **Expected**:
   - Reservation status = "Canceled"
   - Item status = "Available"
   - User receives SignalR notification
   - Activity log entry created

#### Test Scenario 2: Reservation Picked Up in Time

1. Create a reservation with `ReservedFor` = current time + 5 minutes
2. Within 35 minutes, update status to "Borrowed" (simulate pickup)
3. Wait 40 minutes
4. **Expected**:
   - Reservation status remains "Borrowed"
   - Item status remains "Borrowed"
   - No expiry notification sent

#### Test Scenario 3: Multiple Expired Reservations

1. Create 3 reservations with `ReservedFor` in the past
2. Wait for background service to run
3. **Expected**:
   - All 3 reservations canceled
   - All 3 items back to "Available"
   - 3 notifications sent
   - Background service logs "Canceled 3 expired reservation(s)"

### Unit Testing

See `BackendTechincalAssetsManagementTest/Services/LentItemsServiceTests.cs` for unit tests covering:

- `CancelExpiredReservationsAsync_ShouldCancelExpiredReservations`
- `CancelExpiredReservationsAsync_ShouldNotCancelPickedUpReservations`
- `CancelExpiredReservationsAsync_ShouldSendNotifications`
- `CancelExpiredReservationsAsync_ShouldLogCancellations`

## Monitoring

### Logs

**Background Service Logs**:

```
[Information] Reservation Expiry Background Service is starting.
[Information] Canceled 2 expired reservation(s).
[Information] Reservation Expiry Background Service is stopping.
```

**Notification Service Logs**:

```
[Information] Reservation expired notification sent for LentItem {LentItemId} (user: {UserId}, item: {ItemName})
[Error] Failed to send reservation expired notification for LentItem {LentItemId}
```

### Activity Logs

Query the `ActivityLogs` table:

```sql
SELECT * FROM "ActivityLogs"
WHERE "Category" = 'Canceled'
  AND "Action" LIKE '%Reservation expired%'
ORDER BY "CreatedAt" DESC;
```

### Health Checks

The background service runs continuously. If it stops, the application health check will still pass, but no expiry processing will occur.

**Monitor**:

- Check application logs for "Reservation Expiry Background Service is stopping"
- Monitor the count of expired reservations in the database

## Troubleshooting

### Issue: Reservations Not Expiring

**Possible Causes**:

1. Background service not running
2. Clock skew (server time vs database time)
3. `ReservedFor` not set on reservations

**Solutions**:

1. Check logs for "Reservation Expiry Background Service is starting"
2. Verify server and database are using UTC
3. Ensure `ReservedFor` is populated when creating reservations

### Issue: Notifications Not Received

**Possible Causes**:

1. Client not connected to SignalR hub
2. Client not joined to user group
3. Network issues

**Solutions**:

1. Check SignalR connection status in mobile app
2. Verify `JoinUserGroup(userId)` was called after connection
3. Check CORS configuration in `Program.cs`

### Issue: Items Not Released

**Possible Causes**:

1. Database transaction failed
2. Item already borrowed by another user

**Solutions**:

1. Check logs for database errors
2. Verify item status in database
3. Check for concurrent borrow operations

## Configuration Examples

### Shorter Grace Period (15 minutes)

```csharp
// src/Services/LentItemsService.cs
var graceMinutes = 15; // Changed from 30
```

### More Frequent Checks (Every 2 minutes)

```csharp
// src/Services/ReservationExpiryBackgroundService.cs
private readonly TimeSpan _checkInterval = TimeSpan.FromMinutes(2);
```

### Disable Expiry (Not Recommended)

```csharp
// Program.cs - Comment out this line:
// builder.Services.AddHostedService<ReservationExpiryBackgroundService>();
```

## Security Considerations

1. **Authorization**: Only the user who made the reservation receives the notification
2. **Data Privacy**: Notification includes only necessary information (no sensitive data)
3. **Rate Limiting**: Background service runs at fixed intervals to prevent overload
4. **Idempotency**: Multiple runs won't double-cancel the same reservation

## Performance

### Database Impact

- **Query Frequency**: Every 5 minutes
- **Query Complexity**: Simple filter on indexed fields
- **Write Operations**: Only for expired reservations (typically 0-5 per run)

### Optimization Tips

1. Add index on `ReservedFor` column if not already indexed
2. Add composite index on `(Status, ReservedFor, LentAt)` for faster filtering
3. Consider archiving old canceled reservations

## Future Enhancements

1. **Configurable Grace Period**: Allow per-item or per-category grace periods
2. **Warning Notifications**: Send reminder 10 minutes before expiry
3. **Retry Logic**: Retry failed notifications
4. **Metrics Dashboard**: Track expiry rates and patterns
5. **Email Notifications**: Send email in addition to push notification
6. **SMS Notifications**: Send SMS for high-priority items

## Related Documentation

- [SignalR Hub Documentation](../docs-api/NotificationHub.md)
- [LentItems API Documentation](../docs-api/LentItems.md)
- [Activity Logs Documentation](../docs-api/ActivityLogs.md)
- [Background Services Overview](../docs/BackgroundServices.md)
