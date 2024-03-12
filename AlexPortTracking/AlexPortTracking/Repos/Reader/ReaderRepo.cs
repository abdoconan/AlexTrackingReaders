using AlexPortTracking.Data;
using AlexPortTracking.DTOs;
using AlexPortTracking.Models;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace AlexPortTracking.Repos.Reader
{
    public class ReaderRepo : IReaderRepo
    {
        private readonly AlexPortTrackingDbContext context;

        public ReaderRepo(AlexPortTrackingDbContext context)
        {
            this.context = context;
        }
        public async Task<ReaderWithTypeDTO> Create(ReaderDTO reader)
        {
            var reader_ = reader.Adapt<AlexPortTracking.Models.Reader>();
            await context.AddAsync(reader_);
            await context.SaveChangesAsync();
            return (await context.Readers.Include(r => r.ReaderType).FirstOrDefaultAsync(r => r.Id == reader_.Id)).Adapt<ReaderWithTypeDTO>();
        }

        public async Task<bool> Delete(int Id)
        {
            var delReader = await context.Readers.FirstOrDefaultAsync(r => r.Id == Id); 
            if (delReader != null) 
            {
                throw new Exception("Not A Valid Object Id");
            }
            context.Readers.Remove(delReader);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<IList<ReaderWithTypeDTO>> Get() =>
            (await context.Readers.Include(r => r.ReaderType).ToListAsync()).Adapt<List<ReaderWithTypeDTO>>();

        public async Task<ReaderWithTypeDTO> GetById(int Id) =>
            (await context.Readers.FirstOrDefaultAsync(r => r.Id  == Id)).Adapt<ReaderWithTypeDTO>();

        public async Task<ReaderWithTypeDTO> Update(int Id, ReaderDTO reader)
        {
            var reader_ =  context.Readers.Include(r => r.ReaderType).FirstOrDefault(r => r.Id == Id);
            if (reader_ is null)
                throw new Exception("Not A Valid Object Id");
            reader_.Name =  reader.Name;
            reader_.Signature = reader.Signature;
            reader_.PortNumber = reader.PortNumber;
            reader_.ReaderTypeId = reader.ReaderTypeId;
            await context.SaveChangesAsync();

            return (await context.Readers.Include(r => r.ReaderType).FirstOrDefaultAsync(r => r.Id == Id)).Adapt<ReaderWithTypeDTO>();

        }
    }
}
