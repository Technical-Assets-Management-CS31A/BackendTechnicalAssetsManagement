using AutoMapper;
using BackendTechnicalAssetsManagement.src.Classes;
using BackendTechnicalAssetsManagement.src.DTOs.ActivityLog;
using BackendTechnicalAssetsManagement.src.IRepository;
using BackendTechnicalAssetsManagement.src.IService;
using static BackendTechnicalAssetsManagement.src.Classes.Enums;

namespace BackendTechnicalAssetsManagement.src.Services
{
    public class ActivityLogService : IActivityLogService
    {
        private readonly IActivityLogRepository _repository;
        private readonly IMapper _mapper;

        public ActivityLogService(IActivityLogRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ActivityLogDto>> GetAllAsync(ActivityLogFilterDto filter)
        {
            var logs = await _repository.GetFilteredAsync(
                filter.Category,
                filter.From,
                filter.To,
                filter.ActorUserId,
                filter.ItemId,
                filter.Status);

            return _mapper.Map<IEnumerable<ActivityLogDto>>(logs);
        }

        public async Task<IEnumerable<BorrowLogDto>> GetBorrowLogsAsync(
            DateTime? from, DateTime? to, Guid? userId, Guid? itemId)
        {
            var logs = await _repository.GetFilteredAsync(
                category: ActivityLogCategory.BorrowedItem,
                from: from,
                to: to,
                actorUserId: userId,
                itemId: itemId,
                status: null);

            // Also include Returned logs so callers get the full borrow lifecycle
            var returnedLogs = await _repository.GetFilteredAsync(
                category: ActivityLogCategory.Returned,
                from: from,
                to: to,
                actorUserId: userId,
                itemId: itemId,
                status: null);

            var combined = logs.Concat(returnedLogs)
                               .OrderByDescending(l => l.CreatedAt);

            return _mapper.Map<IEnumerable<BorrowLogDto>>(combined);
        }

        public async Task<ActivityLogDto?> GetByIdAsync(Guid id)
        {
            var log = await _repository.GetByIdAsync(id);
            return log == null ? null : _mapper.Map<ActivityLogDto>(log);
        }

        public async Task<ActivityLogDto> LogAsync(
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
            string? remarks)
        {
            var log = new ActivityLog
            {
                Category = category,
                Action = action,
                ActorUserId = actorUserId,
                ActorName = actorName,
                ActorRole = actorRole,
                ItemId = itemId,
                ItemName = itemName,
                ItemSerialNumber = itemSerialNumber,
                LentItemId = lentItemId,
                PreviousStatus = previousStatus,
                NewStatus = newStatus,
                BorrowedAt = borrowedAt,
                ReturnedAt = returnedAt,
                ReservedFor = reservedFor,
                Remarks = remarks
            };

            await _repository.AddAsync(log);
            await _repository.SaveChangesAsync();

            return _mapper.Map<ActivityLogDto>(log);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _repository.SaveChangesAsync();
        }
    }
}
