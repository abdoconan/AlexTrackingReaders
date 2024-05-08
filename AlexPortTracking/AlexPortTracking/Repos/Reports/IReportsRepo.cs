using AlexPortTracking.DTOs;

namespace AlexPortTracking.Repos.Reports
{
    public interface IReportsRepo
    {
        Task<IList<object>> GetDailyTransactions(DateTime date);
        Task<IList<object>> GetFilteredTransactions(DateTime? day, int? readerId, int? readerTypeId, string? ownerName, string? plateNumber, string? tag, int? carClassId, int? carTypeId);
    }
}
