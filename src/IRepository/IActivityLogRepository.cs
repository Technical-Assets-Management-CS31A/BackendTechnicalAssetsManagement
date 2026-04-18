using BackendTechnicalAssetsManagement.src.Classes;
using static BackendTechnicalAssetsManagement.src.Classes.Enums;

namespace BackendTechnicalAssetsManagement.src.IRepository
{
    public interface IActivityLogRepository
    {
        Task<ActivityLog> AddAsync(ActivityLog log);
        Task<ActivityLog?> GetByIdAsync(Guid id);
        Task<IEnumerable<ActivityLog>> GetAllAsync();
        Task<IEnumerable<ActivityLog>> GetFilteredAsync(
            ActivityLogCategory? category,
            DateTime? from,
            DateTime? to,
            Guid? actorUserId,
            Guid? itemId,
            string? status);
        Task<bool> SaveChangesAsync();
    }
}
