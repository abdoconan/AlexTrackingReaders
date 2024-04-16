using AlexPortTracking.Data;
using AlexPortTracking.DTOs;
using AlexPortTracking.Models;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace AlexPortTracking.Repos.CarClass
{
    public class CarClassRepo : ICarClassRepo
    {
        private readonly AlexPortTrackingDbContext context;

        public CarClassRepo(AlexPortTrackingDbContext context)
        {
            this.context = context;
        }
        public async Task<CarClassDTO> Create(CarClassDTO newCarClass)
        {
            var newCarClassToCreate = newCarClass.Adapt<AlexPortTracking.Models.CarClass>();
            await context.AddAsync(newCarClassToCreate);
            await context.SaveChangesAsync();

            return newCarClassToCreate.Adapt<CarClassDTO>();
        }

        public async Task<bool> Delete(int Id)
        {
            var carClassToDelete = await context.CarClasses.FirstOrDefaultAsync(ct => ct.Id == Id);
            if (carClassToDelete == null)
                throw new Exception("Car Class Not Exists");

            context.CarClasses.Remove(carClassToDelete);
            await context.SaveChangesAsync();

            return true;
        }

        public async Task<IList<CarClassDTO>> Get()
        {
            return (await context.CarClasses.ToListAsync()).Adapt<List<CarClassDTO>>();
        }

        public async Task<CarClassDTO> GetById(int Id)
        {
            return (await context.CarClasses.FirstOrDefaultAsync(ct => ct.Id == Id)).Adapt<CarClassDTO>();
        }

        public async Task<CarClassDTO> Update(int Id, CarClassDTO updateCarClass)
        {
            var carClassToUpdate = await context.CarClasses.FirstOrDefaultAsync(ct => ct.Id == Id);
            if (carClassToUpdate == null)
                throw new Exception("Car Class Not Exists");

            carClassToUpdate.Description = updateCarClass.Description;    
            await context.SaveChangesAsync();
            return updateCarClass;
        }
    }
}
