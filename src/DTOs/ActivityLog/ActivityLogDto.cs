using System.Text.Json.Serialization;
using static BackendTechnicalAssetsManagement.src.Classes.Enums;

namespace BackendTechnicalAssetsManagement.src.DTOs.ActivityLog
{
    /// <summary>
    /// General-purpose activity log DTO returned by the API.
    /// </summary>
    public class ActivityLogDto
    {
        public Guid Id { get; set; }

        public ActivityLogCategory Category { get; set; }
        public string Action { get; set; } = string.Empty;

        // Actor
        public Guid? ActorUserId { get; set; }
        public string ActorName { get; set; } = string.Empty;
        public string ActorRole { get; set; } = string.Empty;

        // Item
        public Guid? ItemId { get; set; }
        public string ItemName { get; set; } = string.Empty;
        public string? ItemSerialNumber { get; set; }

        // Borrow context
        public Guid? LentItemId { get; set; }
        public string? PreviousStatus { get; set; }
        public string? NewStatus { get; set; }

        [JsonIgnore]
        public DateTime? BorrowedAt { get; set; }
        [JsonPropertyName("borrowedAt")]
        public string? BorrowedAtFormatted => BorrowedAt?.ToString("yyyy-MM-dd HH:mm");

        [JsonIgnore]
        public DateTime? ReturnedAt { get; set; }
        [JsonPropertyName("returnedAt")]
        public string? ReturnedAtFormatted => ReturnedAt?.ToString("yyyy-MM-dd HH:mm");

        [JsonIgnore]
        public DateTime? ReservedFor { get; set; }
        [JsonPropertyName("reservedFor")]
        public string? ReservedForFormatted => ReservedFor?.ToString("yyyy-MM-dd HH:mm");

        public string? Remarks { get; set; }

        [JsonIgnore]
        public DateTime CreatedAt { get; set; }
        [JsonPropertyName("createdAt")]
        public string CreatedAtFormatted => CreatedAt.ToString("yyyy-MM-dd HH:mm");
    }
}
