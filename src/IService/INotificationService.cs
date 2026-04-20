namespace BackendTechnicalAssetsManagement.src.IService
{
    /// <summary>
    /// Service interface for sending real-time notifications via SignalR
    /// </summary>
    public interface INotificationService
    {
        /// <summary>
        /// Send a notification when a new pending request is created
        /// </summary>
        Task SendNewPendingRequestNotificationAsync(Guid lentItemId, string itemName, string borrowerName, DateTime? reservedFor);

        /// <summary>
        /// Send a notification when an item is borrowed instantly via RFID scan.
        /// Notifies the borrower (confirmation) and admin/staff (awareness).
        /// </summary>
        Task SendItemBorrowedNotificationAsync(Guid lentItemId, Guid? userId, string itemName, string borrowerName);

        /// <summary>
        /// Send a notification when a lent item status changes from Pending to Approved
        /// </summary>
        Task SendApprovalNotificationAsync(Guid lentItemId, Guid? userId, string itemName, string borrowerName);

        /// <summary>
        /// Send a notification when a lent item status changes
        /// </summary>
        Task SendStatusChangeNotificationAsync(Guid lentItemId, Guid? userId, string itemName, string oldStatus, string newStatus);

        /// <summary>
        /// Send a notification to all connected clients
        /// </summary>
        Task SendBroadcastNotificationAsync(string message, object? data = null);

        /// <summary>
        /// Send a notification to a user when their reservation expired because they did not
        /// pick up the item within the allowed time window.
        /// </summary>
        Task SendReservationExpiredNotificationAsync(Guid lentItemId, Guid? userId, string itemName, string borrowerName, DateTime reservedFor);
    }
}
