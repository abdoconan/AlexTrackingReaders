using AlexPortTracking.DTOs;

namespace AlexPortTracking.Repos.Transaction
{
    public interface ITransactionRepo
    {
        Task<IList<TransactionDTO>> GetLatestTransaction(int readerId, int? LatestedId);

        Task<IList<TransactionLogDTO>> GetLatestTagRead(int readerId, int? LatestedId);
    }
}
