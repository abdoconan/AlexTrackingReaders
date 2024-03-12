using AlexPortTracking.DTOs;

namespace AlexPortTracking.Repos.ReaderType
{
    public interface IReaderTypeRepo
    {
        Task<List<ReaderTypeDTO>> Get();
    }
}
