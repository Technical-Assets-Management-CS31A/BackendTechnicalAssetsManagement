namespace BackendTechnicalAssetsManagement.src.IService
{
    public interface ISummaryNotificationService
    {
        Task NotifyItemSummaryUpdated();
        Task NotifyLentItemSummaryUpdated();
        Task NotifyUserSummaryUpdated();
        Task NotifyOverallSummaryUpdated();
    }
}
