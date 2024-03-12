using AlexPortTracking.Data;
using AlexPortTracking.DTOs;
using AlexPortTracking.Models;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace AlexPortTracking.Repos.Car
{
    public class CarRepo : ICarRepo
    {
        private readonly AlexPortTrackingDbContext context;

        public CarRepo(AlexPortTrackingDbContext context)
        {
            this.context = context;
        }
        public async Task<CarDTO> Create(CarDTO newCar)
        {
            var car = newCar.Adapt<AlexPortTracking.Models.Car>();
            await context.AddAsync(car);
            await context.SaveChangesAsync();
            return (await context.Cars.FirstOrDefaultAsync(c => c.Id == car.Id)).Adapt<CarDTO>();
        }

        public async Task<bool> Delete(int Id)
        {
            var delCar = await context.Cars.FirstOrDefaultAsync(c => c.Id == Id); 
            if (delCar != null) 
            {
                throw new Exception("Not A Valid Object Id");
            }
            context.Cars.Remove(delCar);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<IList<CarDTO>> Get() =>
            (await context.Cars.ToListAsync()).Adapt<List<CarDTO>>();

        public async Task<CarDTO> GetById(int Id) =>
            (await context.Cars.FirstOrDefaultAsync(c => c.Id  == Id)).Adapt<CarDTO>();

        public async Task<CarDTO> Update(int Id, CarDTO updateCar)
        {
            var car =  context.Cars.FirstOrDefault(c => c.Id == Id);
            if (car is null)
                throw new Exception("Not A Valid Object Id");
            car.FrontTag = updateCar.FrontTag;
            car.RearTag = updateCar.RearTag;
            car.PlateNumber = updateCar.PlateNumber;
            car.OwnerName = updateCar.OwnerName;
            car.NumberOfAxes = updateCar.NumberOfAxes;
            car.WeightInTon = updateCar.WeightInTon;
            car.CarModel = updateCar.CarModel;
            car.LicenceExpiryDate = updateCar.LicenceExpiryDate;
            await context.SaveChangesAsync();

            return (await context.Cars.FirstOrDefaultAsync(c => c.Id == Id)).Adapt<CarDTO>();

        }
    }
}
