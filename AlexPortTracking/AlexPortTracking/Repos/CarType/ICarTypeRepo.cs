using AlexPortTracking.DTOs;

namespace AlexPortTracking.Repos.CarType
{
    public interface ICarTypeRepo
    {
        Task<IList<CarTypeDTO>> Get();
        Task<CarTypeDTO> GetById(int Id);
        Task<CarTypeDTO> Create(CarTypeDTO newCarType);
        Task<CarTypeDTO> Update(int Id, CarTypeDTO updateCarType);
        Task<bool> Delete(int Id);
    }
}
