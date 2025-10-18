// src/Services/SummaryNotificationService.cs
using BackendTechnicalAssetsManagement.src.Hubs;
using BackendTechnicalAssetsManagement.src.IService;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace BackendTechnicalAssetsManagement.src.Services
{
    public class SummaryNotificationService : ISummaryNotificationService
    {
        private readonly IHubContext<SummaryHub> _hubContext;
        private readonly ISummaryService _summaryService;

        public SummaryNotificationService(IHubContext<SummaryHub> hubContext, ISummaryService summaryService)
        {
            _hubContext = hubContext;
            _summaryService = summaryService;
        }

        public async Task NotifyItemSummaryUpdated()
        {
            var summary = await _summaryService.GetItemCountAsync();
            await _hubContext.Clients.All.SendAsync("ReceiveItemSummaryUpdate", summary);
        }

        public async Task NotifyLentItemSummaryUpdated()
        {
            var summary = await _summaryService.GetLentItemsCountAsync();
            await _hubContext.Clients.All.SendAsync("ReceiveLentItemSummaryUpdate", summary);
        }

        public async Task NotifyUserSummaryUpdated()
        {
            var summary = await _summaryService.GetActiveUserCountAsync();
            await _hubContext.Clients.All.SendAsync("ReceiveUserSummaryUpdate", summary);
        }

        public async Task NotifyOverallSummaryUpdated()
        {
            var summary = await _summaryService.GetOverallSummaryAsync();
            await _hubContext.Clients.All.SendAsync("ReceiveOverallSummaryUpdate", summary);
        }
    }
}