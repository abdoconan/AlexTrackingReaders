using AlexPortTracking.DTOs;
using AlexPortTracking.Repos.Car;
using Microsoft.AspNetCore.Mvc;

namespace AlexPortTracking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarRepo carRepo;

        public CarController(ICarRepo carRepo)
        {
            this.carRepo = carRepo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
            => Ok(await carRepo.Get());

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById(int Id)
            => Ok(await carRepo.GetById(Id));

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CarDTO newCar)
            => Created("", await carRepo.Create(newCar));

        [HttpPut("{Id}")]
        public async Task<IActionResult> Update(int Id, [FromBody] CarDTO UpdateCar)
           => Ok(await carRepo.Update(Id, UpdateCar));

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            await carRepo.Delete(Id);
            return NoContent();
        }
    }
}
