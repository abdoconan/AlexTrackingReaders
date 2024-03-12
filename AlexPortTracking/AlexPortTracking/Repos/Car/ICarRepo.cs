using AlexPortTracking.DTOs;

namespace AlexPortTracking.Repos.Car
{
    public interface ICarRepo
    {
        Task<IList<CarDTO>> Get();
        Task<CarDTO> GetById(int Id);
        Task<CarDTO> Create(CarDTO newCar);
        Task<CarDTO> Update(int Id, CarDTO updateCar);
        Task<bool> Delete(int Id);
    }
}
