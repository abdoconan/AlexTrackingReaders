using AlexPortTracking.Repos.Reports;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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


        [HttpGet]
        public IActionResult Get([FromQuery] DateTime date) =>
            Ok(reportsRepo.GetDailyTransactions(date));
    }
}
