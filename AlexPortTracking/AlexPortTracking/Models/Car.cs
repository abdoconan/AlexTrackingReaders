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
        public int? CarClassId { get; set; }
        public int? CarTypeId { get; set; }
        public int? GovernorateId { get; set; }
        public int NumberOfAxes { get; set; }
        public float WeightInTon { get; set; }
        public float MaxLoadedWeight { get; set; }
        public int CarModel { get; set; }
        public float Length { get; set; }
        public DateTime LicenceExpiryDate { get; set; }
        public bool IsActive { get; set; }

        // navigation properties
        public virtual ICollection<TransactionLog> TransactionLogs { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
        public virtual CarClass CarClass { get; set; }
        public virtual CarType CarType { get; set; }
        public virtual Governorate Governorate { get; set; }

    }

    public class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.ToTable("Cars");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.FrontTag).IsRequired().HasMaxLength(128);
            builder.HasIndex(c => c.FrontTag).IsUnique();
            builder.Property(c => c.RearTag).IsRequired().HasMaxLength(128);
            builder.HasIndex(c => c.RearTag).IsUnique();

            builder.Property(c => c.PlateNumber).HasMaxLength(128);
            builder.Property(c => c.OwnerName).HasMaxLength(512);
            builder.Property(c => c.CarModel).HasAnnotation("MinValue", 1950).HasAnnotation("MaxValue", 2040); ;
            builder.Property(c => c.WeightInTon).HasColumnType("DECIMAL(10, 4)");
            builder.Property(c => c.NumberOfAxes).HasAnnotation("MinValue", 2).HasAnnotation("MaxValue", 20);

            builder.HasOne(c => c.CarClass)
                .WithMany(cc => cc.Cars)
                .HasForeignKey(c => c.CarClassId)
                .OnDelete(DeleteBehavior.SetNull);
                ;

            builder.HasOne(c => c.CarType)
                .WithMany(ct => ct.Cars)
                .HasForeignKey(c => c.CarTypeId)
                .OnDelete(DeleteBehavior.SetNull);
            ;

            builder.HasOne(c => c.Governorate)
                .WithMany(g => g.Cars)
                .HasForeignKey(c => c.GovernorateId)
                .OnDelete(DeleteBehavior.SetNull);
            ;


        }
    }
}
