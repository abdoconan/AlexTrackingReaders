using AlexPortTracking.DTOs;

namespace AlexPortTracking.Repos.Reports
{
    public interface IReportsRepo
    {
        Task<IList<object>> GetDailyTransactions(DateTime date);
    }
}
