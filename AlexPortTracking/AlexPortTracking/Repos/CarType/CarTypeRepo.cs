using AlexPortTracking.Data;
using AlexPortTracking.DTOs;
using AlexPortTracking.Models;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace AlexPortTracking.Repos.CarType
{
    public class CarTypeRepo : ICarTypeRepo
    {
        private readonly AlexPortTrackingDbContext context;

        public CarTypeRepo(AlexPortTrackingDbContext context)
        {
            this.context = context;
        }
        public async Task<CarTypeDTO> Create(CarTypeDTO newCarType)
        {
            var newCarTypeToCreate = newCarType.Adapt<AlexPortTracking.Models.CarType>();
            await context.AddAsync(newCarTypeToCreate);
            await context.SaveChangesAsync();

            return newCarTypeToCreate.Adapt<CarTypeDTO>();
        }

        public async Task<bool> Delete(int Id)
        {
            var carTypeToDelete = await context.CarTypes.FirstOrDefaultAsync(ct => ct.Id == Id);
            if (carTypeToDelete == null)
                throw new Exception("Car Type Not Exists");

            context.CarTypes.Remove(carTypeToDelete);
            await context.SaveChangesAsync();

            return true;
        }

        public async Task<IList<CarTypeDTO>> Get()
        {
            return (await context.CarTypes.ToListAsync()).Adapt<List<CarTypeDTO>>();
        }

        public async Task<CarTypeDTO> GetById(int Id)
        {
            return (await context.CarTypes.FirstOrDefaultAsync(ct => ct.Id == Id)).Adapt<CarTypeDTO>();
        }

        public async Task<CarTypeDTO> Update(int Id, CarTypeDTO updateCarType)
        {
            var carTypeToUpdate = await context.CarTypes.FirstOrDefaultAsync(ct => ct.Id == Id);
            if (carTypeToUpdate == null)
                throw new Exception("Car Type Not Exists");

            carTypeToUpdate.Description = updateCarType.Description;    
            await context.SaveChangesAsync();
            return updateCarType;
        }
    }
}
