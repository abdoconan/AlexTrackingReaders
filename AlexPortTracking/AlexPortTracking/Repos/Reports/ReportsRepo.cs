
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
        //public async Task<List<CarDailyTransactionDTO>> GetDailyTransactions(DateTime date)
        //{

        //    using var _conn = new SqlConnection(context.Database.GetConnectionString());

        //    using (var cmd = new SqlCommand("SELECT Id FROM CarCountPerDay", _conn))
        //    {
        //        bool isOpen = _conn.State == ConnectionState.Open;
        //        if (!isOpen)
        //            _conn.Open();

        //        //cmd.CommandType = CommandType.Text;

        //        //cmd.Parameters.Clear();
        //        //cmd.Parameters.Add(new SqlParameter("@DocumentID", dto.DocumentID));
        //        //cmd.Parameters.Add(new SqlParameter("@Button_ID", dto.ButtonID));
        //        //cmd.Parameters.Add(new SqlParameter("@ServiceID", dto.ServiceID));
        //        //cmd.Parameters.Add(new SqlParameter("@User_ID", dto.UserID));
        //        //cmd.Parameters.Add(new SqlParameter("@Role_ID", dto.RoleId));
        //        //cmd.Parameters.Add(new SqlParameter("@Debug", dto.Debug));

        //        //cmd.Parameters.Add(new SqlParameter("@Expiry_Date_Value", dto.ExpiryDateValue is null ? DBNull.Value : dto.ExpiryDateValue));
        //        //cmd.Parameters.Add(new SqlParameter("@InstanceID", dto.InstanceID is null ? DBNull.Value : dto.InstanceID));
        //        //cmd.Parameters.Add(new SqlParameter("@Price", dto.Price is null ? DBNull.Value : dto.Price));
        //        //cmd.Parameters.Add(new SqlParameter("@CurrentStatusFlow", dto.CurrentStatusFlow));
        //        //cmd.Parameters.Add(new SqlParameter("@Original_Document", dto.Original_Document is null ? DBNull.Value : dto.Original_Document));
        //        //cmd.Parameters.Add(new SqlParameter("@FieldsTable", fieldsTable));
        //        //cmd.Parameters.Add(new SqlParameter("@SectionHidden", sectionHidden));
        //        //cmd.Parameters.Add(new SqlParameter("@FeildsHidden", fieldsHidden));

        //        var resultTable = new DataTable();
        //        using (var dataReader = await cmd.ExecuteReaderAsync())
        //        {
        //            resultTable.Load(dataReader);
        //        }
        //    }


        //        return (await context.CarCountPerDay.ToListAsync()).Adapt<List<CarDailyTransactionDTO>>();

        //}

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
    }
}
