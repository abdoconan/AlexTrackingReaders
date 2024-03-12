using AlexPortTracking.Repos.ReaderType;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlexPortTracking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReaderTypeController : ControllerBase
    {
        private readonly IReaderTypeRepo readerType;

        public ReaderTypeController(IReaderTypeRepo readerType)
        {
            this.readerType = readerType;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
            => Ok(await readerType.Get());
    }
}
