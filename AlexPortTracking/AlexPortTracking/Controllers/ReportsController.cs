using AlexPortTracking.Repos.Reports;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace AlexPortTracking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly IReportsRepo reportsRepo;

        public ReportsController(IReportsRepo reportsRepo)
        {
            this.reportsRepo = reportsRepo;
        }


        [HttpGet("DailyTransactions")]
        public async Task<IActionResult> GetDailyTransactions([FromQuery] [Required] DateTime date) =>
            Ok(await reportsRepo.GetDailyTransactions(date));

        [HttpGet("FilteredTransactions")]
        public async Task<IActionResult> GetFilteredTransactions([FromQuery] [Required] DateTime? day, int? readerId, int? readerTypeId, string? ownerName, string? plateNumber, string? tag, int? carClassId, int? carTypeId) =>
            Ok(await reportsRepo.GetFilteredTransactions(day, readerId, readerTypeId, ownerName, plateNumber, tag, carClassId, carTypeId));
    }
}
