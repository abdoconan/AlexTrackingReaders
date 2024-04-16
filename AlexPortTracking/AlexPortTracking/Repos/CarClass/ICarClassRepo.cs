using AlexPortTracking.DTOs;

namespace AlexPortTracking.Repos.CarClass
{
    public interface ICarClassRepo
    {
        Task<IList<CarClassDTO>> Get();
        Task<CarClassDTO> GetById(int Id);
        Task<CarClassDTO> Create(CarClassDTO newCarClass);
        Task<CarClassDTO> Update(int Id, CarClassDTO updateCarClass);
        Task<bool> Delete(int Id);
    }
}
