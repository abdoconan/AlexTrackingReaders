
using AlexPortTracking.Data;
using AlexPortTracking.DTOs;
using AlexPortTracking.Models;
using Mapster;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace AlexPortTracking.Repos.Reports
{
    public class ReportsRepo : IReportsRepo
    {
        private readonly AlexPortTrackingDbContext context;

        public ReportsRepo(AlexPortTrackingDbContext context)
        {
            this.context = context;
        }
        public async Task<List<CarDailyTransactionDTO>> GetDailyTransactions(DateTime date)
        {

            using var _conn = new SqlConnection(context.Database.GetConnectionString());

            using (var cmd = new SqlCommand("SELECT Id FROM CarCountPerDay", _conn))
            {
                bool isOpen = _conn.State == ConnectionState.Open;
                if (!isOpen)
                    _conn.Open();

                //cmd.CommandType = CommandType.Text;

                //cmd.Parameters.Clear();
                //cmd.Parameters.Add(new SqlParameter("@DocumentID", dto.DocumentID));
                //cmd.Parameters.Add(new SqlParameter("@Button_ID", dto.ButtonID));
                //cmd.Parameters.Add(new SqlParameter("@ServiceID", dto.ServiceID));
                //cmd.Parameters.Add(new SqlParameter("@User_ID", dto.UserID));
                //cmd.Parameters.Add(new SqlParameter("@Role_ID", dto.RoleId));
                //cmd.Parameters.Add(new SqlParameter("@Debug", dto.Debug));

                //cmd.Parameters.Add(new SqlParameter("@Expiry_Date_Value", dto.ExpiryDateValue is null ? DBNull.Value : dto.ExpiryDateValue));
                //cmd.Parameters.Add(new SqlParameter("@InstanceID", dto.InstanceID is null ? DBNull.Value : dto.InstanceID));
                //cmd.Parameters.Add(new SqlParameter("@Price", dto.Price is null ? DBNull.Value : dto.Price));
                //cmd.Parameters.Add(new SqlParameter("@CurrentStatusFlow", dto.CurrentStatusFlow));
                //cmd.Parameters.Add(new SqlParameter("@Original_Document", dto.Original_Document is null ? DBNull.Value : dto.Original_Document));
                //cmd.Parameters.Add(new SqlParameter("@FieldsTable", fieldsTable));
                //cmd.Parameters.Add(new SqlParameter("@SectionHidden", sectionHidden));
                //cmd.Parameters.Add(new SqlParameter("@FeildsHidden", fieldsHidden));

                var resultTable = new DataTable();
                using (var dataReader = await cmd.ExecuteReaderAsync())
                {
                    resultTable.Load(dataReader);
                }
            }

                
                return (await context.CarCountPerDay.ToListAsync()).Adapt<List<CarDailyTransactionDTO>>();

        }
    }
}
