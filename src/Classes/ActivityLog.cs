using static BackendTechnicalAssetsManagement.src.Classes.Enums;

namespace BackendTechnicalAssetsManagement.src.Classes
{
    /// <summary>
    /// Represents a categorized activity log entry for auditing system events.
    /// </summary>
    public class ActivityLog
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        /// <summary>The category of this log entry (e.g., BorrowedItem, Return, Reservation).</summary>
        public ActivityLogCategory Category { get; set; }

        /// <summary>Human-readable description of the event.</summary>
        public string Action { get; set; } = string.Empty;

        // --- Actor (who performed the action) ---
        public Guid? ActorUserId { get; set; }
        public User? ActorUser { get; set; }
        public string ActorName { get; set; } = string.Empty;
        public string ActorRole { get; set; } = string.Empty;

        // --- Subject Item ---
        public Guid? ItemId { get; set; }
        public Item? Item { get; set; }
        public string ItemName { get; set; } = string.Empty;
        public string? ItemSerialNumber { get; set; }

        // --- Borrow-specific fields ---
        public Guid? LentItemId { get; set; }
        public LentItems? LentItem { get; set; }

        /// <summary>Status before the transition (e.g., "Pending").</summary>
        public string? PreviousStatus { get; set; }

        /// <summary>Status after the transition (e.g., "Borrowed").</summary>
        public string? NewStatus { get; set; }

        public DateTime? BorrowedAt { get; set; }
        public DateTime? ReturnedAt { get; set; }
        public DateTime? ReservedFor { get; set; }

        public string? Remarks { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
