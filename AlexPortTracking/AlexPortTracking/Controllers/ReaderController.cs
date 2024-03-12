using AlexPortTracking.DTOs;
using AlexPortTracking.Repos.Reader;
using Microsoft.AspNetCore.Mvc;

namespace AlexPortTracking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReaderController : ControllerBase
    {
        private readonly IReaderRepo readerRepo;

        public ReaderController(IReaderRepo readerRepo)
        {
            this.readerRepo = readerRepo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
            => Ok(await readerRepo.Get());

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById(int Id)
            => Ok(await readerRepo.GetById(Id));

        [HttpPost]
        public async Task<IActionResult> Create(ReaderDTO newReader)
            => Created("", await readerRepo.Create(newReader));

        [HttpPut("{Id}")]
        public async Task<IActionResult> Update(int Id, [FromBody] ReaderDTO newReader)
           => Ok(await readerRepo.Update(Id, newReader));

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            await readerRepo.Delete(Id);
            return NoContent();
        }
           
    }
}
