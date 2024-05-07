using AlexPortTracking.DTOs;

namespace AlexPortTracking.Repos.Reports
{
    public interface IReportsRepo
    {
        Task<List<CarDailyTransactionDTO>> GetDailyTransactions(DateTime date);
    }
}
