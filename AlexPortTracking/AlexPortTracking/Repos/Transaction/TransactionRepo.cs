using AlexPortTracking.Data;
using AlexPortTracking.DTOs;
using AlexPortTracking.Models;
using Azure;
using Mapster;
using Microsoft.EntityFrameworkCore;
using System.Reflection.PortableExecutable;

namespace AlexPortTracking.Repos.Transaction
{
    public class TransactionRepo : ITransactionRepo
    {
        private readonly AlexPortTrackingDbContext context;

        public TransactionRepo(AlexPortTrackingDbContext context)
        {
            this.context = context;
        }

        public async Task<IList<TransactionLogDTO>> GetLatestTagRead(int readerId, int? LatestedId)
        {
            if (LatestedId != null)
                return (await context.TransactionLogs
                    .Include(t => t.Reader)
                    .Where(t => t.Id > LatestedId && t.ReaderId == readerId)
                    .OrderByDescending(t => t.Id).ToListAsync())
                    .Select(t =>
                    new TransactionLogDTO(t.Id, t.Tag.Substring(t.Reader.Signature.Length, t.Tag.Length - (2 * t.Reader.Signature.Length)).Substring(20, 5))
                    )
                    .ToList();

            var lastObject = await context.TransactionLogs
                .Include(t => t.Reader)
                .Where(t => t.ReaderId == readerId)
                .OrderByDescending(t => t.Id)
                .FirstOrDefaultAsync();
            if (lastObject != null)
                return new List<TransactionLogDTO>() { 
                    new TransactionLogDTO(lastObject.Id,
                    lastObject.Tag.Substring(lastObject.Reader.Signature.Length, lastObject.Tag.Length - (2 * lastObject.Reader.Signature.Length)).Substring(20, 5)
                    )};


            return new List<TransactionLogDTO>();
        }

        public async Task<IList<TransactionDTO>> GetLatestTransaction(int readerId, int? LatestedId)
        {
            if (LatestedId != null)
                return (await context.Transactions.Include(t => t.Car).Where(t => t.Id > LatestedId && t.ReaderId == readerId).ToListAsync()).Adapt<List<TransactionDTO>>();

            var lastObject = await context.Transactions.Include(t => t.Car)
                .Where(t => t.ReaderId == readerId)
                .OrderByDescending(t => t.Id)
                .FirstOrDefaultAsync();
            if (lastObject != null)
                return (new List<AlexPortTracking.Models.Transaction> {
                    lastObject
                    })
                .Adapt<List<TransactionDTO>>();

            return new List<TransactionDTO>();
        }
    }
}
