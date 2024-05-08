
using AlexPortTracking.Data;
using AlexPortTracking.DTOs;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace AlexPortTracking.Repos.Reports
{
    public class ReportsRepo : IReportsRepo
    {
        private readonly AlexPortTrackingDbContext _context;

        public ReportsRepo(AlexPortTrackingDbContext context)
        {
            _context = context;
        }

        public async Task<IList<object>> GetDailyTransactions(DateTime date)
        {
            var query = await (from t in _context.Transactions
                               where t.LogTime.Date == date.Date
                               join r in _context.Readers on t.ReaderId equals r.Id
                               join rt in _context.ReaderTypes on r.ReaderTypeId equals rt.Id
                               join c in _context.Cars on t.CarId equals c.Id
                               join cc in _context.CarClasses on c.CarClassId equals cc.Id
                               join ct in _context.CarTypes on c.CarTypeId equals ct.Id
                               join g in _context.Governorates on c.GovernorateId equals g.Id
                               select new
                               {
                                   TransactionId = t.Id,
                                   TransactionLogTime = t.LogTime,
                                   ReaderId = r.Id,
                                   ReaderName = r.Name,
                                   ReaderTypeId = rt.Id,
                                   ReaderTypeName = rt.Name
                               })
                               .GroupBy(x => new { x.ReaderName, x.ReaderTypeName })
                               .Select(g => new
                               {
                                   ReaderId = g.First().ReaderId,
                                   ReaderName = g.Key.ReaderName,
                                   ReaderTypeId = g.First().ReaderTypeId,
                                   ReaderType = g.Key.ReaderTypeName,
                                   TransactionCount = g.Count()
                               })
                               .ToListAsync();

            return query.Cast<object>().ToList();
        }

        public async Task<IList<object>> GetFilteredTransactions(DateTime? day, int? readerId, int? readerTypeId, string? ownerName, string? plateNumber, string? tag, int? carClassId, int? carTypeId)
        {
            var query = await (from t in _context.Transactions
                               where (!day.HasValue || t.LogTime.Date == day.Value.Date) &&
                                     (!readerId.HasValue || t.ReaderId == readerId.Value) &&
                                     (!readerTypeId.HasValue || t.Reader.ReaderTypeId == readerTypeId.Value) &&
                                     (string.IsNullOrEmpty(ownerName) || t.Car.OwnerName == ownerName) &&
                                     (string.IsNullOrEmpty(plateNumber) || t.Car.PlateNumber == plateNumber) &&
                                     (string.IsNullOrEmpty(tag) || t.Car.FrontTag == tag || t.Car.RearTag == tag) &&
                                     (!carClassId.HasValue || t.Car.CarClassId == carClassId.Value) &&
                                     (!carTypeId.HasValue || t.Car.CarTypeId == carTypeId.Value)
                               join r in _context.Readers on t.ReaderId equals r.Id
                               join rt in _context.ReaderTypes on r.ReaderTypeId equals rt.Id
                               join c in _context.Cars on t.CarId equals c.Id
                               join cc in _context.CarClasses on c.CarClassId equals cc.Id
                               join ct in _context.CarTypes on c.CarTypeId equals ct.Id
                               join g in _context.Governorates on c.GovernorateId equals g.Id
                               select new
                               {
                                   TransactionId = t.Id,
                                   LogTime = t.LogTime,
                                   ReaderName = r.Name,
                                   ReaderTypeName = rt.Name,
                                   CarOwnerName = c.OwnerName,
                                   CarPlateNumber = c.PlateNumber,
                                   CarFrontTag = c.FrontTag,
                                   CarRearTag = c.RearTag,
                                   CarClassName = cc.Description,
                                   CarTypeName = ct.Description,
                                   GovernorateName = g.DescriptionAr
                               }).ToListAsync();

            return query.Cast<object>().ToList();
        }

        public async Task<IList<object>> GetDailyTransactionsPerReaderType(DateTime date)
        {
            var query = await (from t in _context.Transactions
                               where t.LogTime.Date == date.Date
                               join r in _context.Readers on t.ReaderId equals r.Id
                               join rt in _context.ReaderTypes on r.ReaderTypeId equals rt.Id
                               select new
                               {
                                   TransactionId = t.Id,
                                   ReaderTypeId = rt.Id,
                                   ReaderTypeName = rt.Name
                               })
                               .GroupBy(x => new {  x.ReaderTypeName })
                               .Select(g => new
                               {
                                   ReaderTypeId = g.First().ReaderTypeId,
                                   ReaderType = g.Key.ReaderTypeName,
                                   TransactionCount = g.Count()
                               })
                               .ToListAsync();

            return query.Cast<object>().ToList();
        }
    }
}
