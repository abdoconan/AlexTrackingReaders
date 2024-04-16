using AlexPortTracking.DTOs;
using AlexPortTracking.Repos.CarClass;
using Microsoft.AspNetCore.Mvc;

namespace AlexPortTracking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarClassController : ControllerBase
    {
        private readonly ICarClassRepo carClassRepo;

        public CarClassController(ICarClassRepo carClassRepo)
        {
            this.carClassRepo = carClassRepo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
            => Ok(await carClassRepo.Get());

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById(int Id)
            => Ok(await carClassRepo.GetById(Id));

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CarClassDTO carClass)
            => Created("", await carClassRepo.Create(carClass));

        [HttpPut("{Id}")]
        public async Task<IActionResult> Update(int Id, [FromBody] CarClassDTO carClass)
           => Ok(await carClassRepo.Update(Id, carClass));

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            await carClassRepo.Delete(Id);
            return NoContent();
        }
    }
}
