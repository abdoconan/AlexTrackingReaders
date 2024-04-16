using AlexPortTracking.DTOs;

namespace AlexPortTracking.Repos.CarClass
{
    public interface ICarClassRepo
    {
        Task<IList<CarClassDTOs>> Get();
        Task<CarClassDTOs> GetById(int Id);
        Task<CarClassDTOs> Create(CarClassDTOs newCarClass);
        Task<CarClassDTOs> Update(int Id, CarClassDTOs updateCarClass);
        Task<bool> Delete(int Id);
    }
}
