using AlexPortTracking.DTOs;
using AlexPortTracking.Repos.CarClass;
using AlexPortTracking.Repos.Governorate;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlexPortTracking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GovernorateController : ControllerBase
    {
        private readonly IGovernorateRepo governorateRepo;

        public GovernorateController(IGovernorateRepo governorateRepo)
        {
            this.governorateRepo = governorateRepo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
            => Ok(await governorateRepo.Get());

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById(int Id)
            => Ok(await governorateRepo.GetById(Id));

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] GovernorateDTO governorate)
            => Created("", await governorateRepo.Create(governorate));

        [HttpPut("{Id}")]
        public async Task<IActionResult> Update(int Id, [FromBody] GovernorateDTO governorate)
           => Ok(await governorateRepo.Update(Id, governorate));

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            await governorateRepo.Delete(Id);
            return NoContent();
        }
    }
}
