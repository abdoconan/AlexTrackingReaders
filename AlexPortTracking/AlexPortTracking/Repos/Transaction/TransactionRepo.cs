using AlexPortTracking.Data;
using AlexPortTracking.DTOs;
using AlexPortTracking.Models;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace AlexPortTracking.Repos.Transaction
{
    public class TransactionRepo : ITransactionRepo
    {
        private readonly AlexPortTrackingDbContext context;

        public TransactionRepo(AlexPortTrackingDbContext context)
        {
            this.context = context;
        }
        public async Task<IList<TransactionDTO>> GetLatestTransaction(int readerId, int? LatestedId)
        {
            if (LatestedId != null)
                return (await context.Transactions.Include(t => t.Car).Where(t => t.Id > LatestedId && t.ReaderId == readerId).ToListAsync()).Adapt<List<TransactionDTO>>();

            return (new List<AlexPortTracking.Models.Transaction> {await context.Transactions.Include(t => t.Car)
                .Where(t => t.ReaderId  == readerId)
                .OrderByDescending(t => t.Id)
                .FirstOrDefaultAsync()
                    })
                .Adapt<List<TransactionDTO>>();
        }
    }
}
