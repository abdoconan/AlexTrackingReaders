using AlexPortTracking.Data;
using AlexPortTracking.DTOs;
using AlexPortTracking.Models;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace AlexPortTracking.Repos.Governorate
{
    public class GovernorateRepo : IGovernorateRepo
    {
        private readonly AlexPortTrackingDbContext context;

        public GovernorateRepo(AlexPortTrackingDbContext context)
        {
            this.context = context;
        }
        public async Task<GovernorateDTO> Create(GovernorateDTO governorate)
        {
            var newGovernorate = governorate.Adapt<AlexPortTracking.Models.Governorate>();
            await context.AddAsync(newGovernorate);
            await context.SaveChangesAsync();

            return newGovernorate.Adapt<GovernorateDTO>();
        }

        public async Task<bool> Delete(int Id)
        {
            var governorate = await context.Governorates.FirstOrDefaultAsync(ct => ct.Id == Id);
            if (governorate == null)
                throw new Exception("Car Type Not Exists");

            context.Governorates.Remove(governorate);
            await context.SaveChangesAsync();

            return true;
        }

        public async Task<IList<GovernorateDTO>> Get()
        {
            return (await context.Governorates.ToListAsync()).Adapt<List<GovernorateDTO>>();
        }

        public async Task<GovernorateDTO> GetById(int Id)
        {
            return (await context.Governorates.FirstOrDefaultAsync(ct => ct.Id == Id)).Adapt<GovernorateDTO>();
        }

        public async Task<GovernorateDTO> Update(int Id, GovernorateDTO governorate)
        {
            var governorateToUpdate = await context.Governorates.FirstOrDefaultAsync(ct => ct.Id == Id);
            if (governorateToUpdate == null)
                throw new Exception("governorate Not Exists");

            governorateToUpdate.DescriptionAr = governorate.DescriptionAr;    
            governorateToUpdate.DescriptionEn = governorate.DescriptionEn;    
            await context.SaveChangesAsync();
            return governorate;
        }
    }
}
