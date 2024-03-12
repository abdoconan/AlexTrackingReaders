using AlexPortTracking.DTOs;

namespace AlexPortTracking.Repos.Reader
{
    public interface IReaderRepo
    {
        Task<IList<ReaderWithTypeDTO>> Get();
        Task<ReaderWithTypeDTO> GetById(int Id);
        Task<ReaderWithTypeDTO> Create(ReaderDTO reader);
        Task<ReaderWithTypeDTO> Update(int Id, ReaderDTO reader);
        Task<bool> Delete(int Id);
    }
}
