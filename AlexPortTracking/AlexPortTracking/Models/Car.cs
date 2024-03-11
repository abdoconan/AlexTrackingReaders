using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlexPortTracking.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string FrontTag { get; set; } = string.Empty;
        public string RearTag { get; set; } = string.Empty;
        public string PlateNumber { get; set; } = string.Empty;
        public string OwnerName { get; set; } = string.Empty;
        public  int NumberOfAxes { get; set; }

        // navigation properties
        public virtual ICollection<TransactionLog> TransactionLogs { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }

    }

    public class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.FrontTag).IsRequired().HasMaxLength(128);
            builder.HasIndex(c => c.FrontTag).IsUnique();
            builder.Property(c => c.RearTag).IsRequired().HasMaxLength(128);
            builder.HasIndex(c => c.RearTag).IsUnique();

            builder.Property(c => c.PlateNumber).HasMaxLength(128);
            builder.Property(c => c.OwnerName).HasMaxLength(512);
            builder.Property(c => c.NumberOfAxes).HasAnnotation("MinValue", 2);
            builder.Property(c => c.NumberOfAxes).HasAnnotation("MaxValue", 20);




        }
    }
}
