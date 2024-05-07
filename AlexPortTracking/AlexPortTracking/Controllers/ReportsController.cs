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
        public async Task<IActionResult> Get([FromQuery] [Required] DateTime date) =>
            Ok(await reportsRepo.GetDailyTransactions(date));
    }
}
