using static BackendTechnicalAssetsManagement.src.Classes.Enums;

namespace BackendTechnicalAssetsManagement.src.DTOs.ActivityLog
{
    /// <summary>
    /// Query parameters for filtering activity logs.
    /// </summary>
    public class ActivityLogFilterDto
    {
        public ActivityLogCategory? Category { get; set; }
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
        public Guid? ActorUserId { get; set; }
        public Guid? ItemId { get; set; }
        public string? Status { get; set; }
    }
}
