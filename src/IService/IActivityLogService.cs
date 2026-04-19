using BackendTechnicalAssetsManagement.src.DTOs.ActivityLog;
using static BackendTechnicalAssetsManagement.src.Classes.Enums;

namespace BackendTechnicalAssetsManagement.src.IService
{
    public interface IActivityLogService
    {
        /// <summary>Returns all logs, optionally filtered by category and date range.</summary>
        Task<IEnumerable<ActivityLogDto>> GetAllAsync(ActivityLogFilterDto filter);

        /// <summary>Returns borrow-specific logs with full status-transition detail.</summary>
        Task<IEnumerable<BorrowLogDto>> GetBorrowLogsAsync(DateTime? from, DateTime? to, Guid? userId, Guid? itemId);

        /// <summary>Returns a single log entry by ID.</summary>
        Task<ActivityLogDto?> GetByIdAsync(Guid id);

        /// <summary>
        /// Records a new activity log entry. Called internally by other services
        /// when a status transition occurs (e.g., Borrowed → Returned).
        /// </summary>
        Task<ActivityLogDto> LogAsync(
            ActivityLogCategory category,
            string action,
            Guid? actorUserId,
            string actorName,
            string actorRole,
            Guid? itemId,
            string itemName,
            string? itemSerialNumber,
            Guid? lentItemId,
            string? previousStatus,
            string? newStatus,
            DateTime? borrowedAt,
            DateTime? returnedAt,
            DateTime? reservedFor,
            string? remarks);

        Task<bool> SaveChangesAsync();
    }
}
