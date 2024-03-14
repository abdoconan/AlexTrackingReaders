using AlexPortTracking.Repos.Transaction;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlexPortTracking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionRepo transactionRepo;

        public TransactionController(ITransactionRepo transactionRepo)
        {
            this.transactionRepo = transactionRepo;
        }

        [HttpGet("{readerId}")]
        public async Task<IActionResult> GetTransaction([FromRoute] int readerId, [FromQuery] int? LastedTransaction) =>
            Ok(await transactionRepo.GetLatestTransaction(readerId, LastedTransaction));
    }
}
