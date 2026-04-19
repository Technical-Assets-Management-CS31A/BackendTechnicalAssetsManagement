using BackendTechnicalAssetsManagement.src.DTOs.ActivityLog;
using BackendTechnicalAssetsManagement.src.IService;
using BackendTechnicalAssetsManagement.src.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static BackendTechnicalAssetsManagement.src.Classes.Enums;

namespace BackendTechnicalAssetsManagement.src.Controllers
{
    [ApiController]
    [Route("api/v1/activity-logs")]
    [Authorize(Policy = "AdminOrStaff")]
    public class ActivityLogController : ControllerBase
    {
        private readonly IActivityLogService _service;

        public ActivityLogController(IActivityLogService service)
        {
            _service = service;
        }

        /// <summary>
        /// GET api/v1/activity-logs
        /// Returns all activity logs with optional filtering by category, date range, actor, item, and status.
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<ApiResponse<IEnumerable<ActivityLogDto>>>> GetAll(
            [FromQuery] ActivityLogCategory? category,
            [FromQuery] DateTime? from,
            [FromQuery] DateTime? to,
            [FromQuery] Guid? actorUserId,
            [FromQuery] Guid? itemId,
            [FromQuery] string? status)
        {
            var filter = new ActivityLogFilterDto
            {
                Category = category,
                From = from,
                To = to,
                ActorUserId = actorUserId,
                ItemId = itemId,
                Status = status
            };

            var logs = await _service.GetAllAsync(filter);
            return Ok(ApiResponse<IEnumerable<ActivityLogDto>>.SuccessResponse(logs, "Activity logs retrieved successfully."));
        }

        /// <summary>
        /// GET api/v1/activity-logs/{id}
        /// Returns a single activity log entry by ID.
        /// </summary>
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ApiResponse<ActivityLogDto>>> GetById(Guid id)
        {
            var log = await _service.GetByIdAsync(id);
            if (log == null)
                return NotFound(ApiResponse<ActivityLogDto>.FailResponse($"Activity log with ID '{id}' not found."));

            return Ok(ApiResponse<ActivityLogDto>.SuccessResponse(log, "Activity log retrieved successfully."));
        }

        /// <summary>
        /// GET api/v1/activity-logs/borrow-logs
        /// Returns borrow-specific logs (Borrowed + Returned) with full status-transition detail.
        /// Supports filtering by date range, borrower user ID, and item ID.
        /// </summary>
        [HttpGet("borrow-logs")]
        public async Task<ActionResult<ApiResponse<IEnumerable<BorrowLogDto>>>> GetBorrowLogs(
            [FromQuery] DateTime? from,
            [FromQuery] DateTime? to,
            [FromQuery] Guid? userId,
            [FromQuery] Guid? itemId)
        {
            var logs = await _service.GetBorrowLogsAsync(from, to, userId, itemId);
            return Ok(ApiResponse<IEnumerable<BorrowLogDto>>.SuccessResponse(logs, "Borrow logs retrieved successfully."));
        }
    }
}
