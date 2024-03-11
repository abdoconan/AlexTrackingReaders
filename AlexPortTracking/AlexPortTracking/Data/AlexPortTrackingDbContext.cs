using AlexPortTracking.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace AlexPortTracking.Data
{
    public class AlexPortTrackingDbContext: IdentityDbContext
    {
        public AlexPortTrackingDbContext(DbContextOptions<AlexPortTrackingDbContext> opt):  base(opt)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(AlexPortTrackingDbContext).Assembly);
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Reader> Readers { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<TransactionLog> TransactionLogs { get; set; }
        public DbSet<ReaderType> ReaderTypes { get; set; }
    }
}
