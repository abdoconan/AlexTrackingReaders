using AlexPortTracking.DTOs;

namespace AlexPortTracking.Repos.Governorate
{
    public interface IGovernorateRepo
    {
        Task<IList<GovernorateDTO>> Get();
        Task<GovernorateDTO> GetById(int Id);
        Task<GovernorateDTO> Create(GovernorateDTO governorate);
        Task<GovernorateDTO> Update(int Id, GovernorateDTO governorate);
        Task<bool> Delete(int Id);
    }
}
