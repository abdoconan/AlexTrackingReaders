using AlexPortTracking.DTOs;
using AlexPortTracking.Repos.CarType;
using Microsoft.AspNetCore.Mvc;

namespace AlexPortTracking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarTypeController : ControllerBase
    {
        private readonly ICarTypeRepo carTypeRepo;

        public CarTypeController(ICarTypeRepo carTypeRepo)
        {
            this.carTypeRepo = carTypeRepo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
            => Ok(await carTypeRepo.Get());

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById(int Id)
            => Ok(await carTypeRepo.GetById(Id));

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CarTypeDTO carType)
            => Created("", await carTypeRepo.Create(carType));

        [HttpPut("{Id}")]
        public async Task<IActionResult> Update(int Id, [FromBody] CarTypeDTO carType)
           => Ok(await carTypeRepo.Update(Id, carType));

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            await carTypeRepo.Delete(Id);
            return NoContent();
        }
    }
}
