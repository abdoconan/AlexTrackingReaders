using AlexPortTracking.Data;
using AlexPortTracking.DTOs;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace AlexPortTracking.Repos.ReaderType
{
    public class ReaderTypeRepo : IReaderTypeRepo
    {
        private readonly AlexPortTrackingDbContext context;

        public ReaderTypeRepo(AlexPortTrackingDbContext context)
        {
            this.context = context;
        }
        public async Task<List<ReaderTypeDTO>> Get() =>
              (await context.ReaderTypes.ToListAsync()).Adapt<List<ReaderTypeDTO>>();

    }
}
