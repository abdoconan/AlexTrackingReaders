using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlexPortTracking.Models
{
    public class CarClass
    {
        public int Id { get; set; }
        public string Description { get; set; }

        // navigation properties
        public ICollection<Car> Cars { get; set; }
    }

    public class CarClassConfiguration : IEntityTypeConfiguration<CarClass>
    {
        public void Configure(EntityTypeBuilder<CarClass> builder)
        {
            builder.ToTable("CarClass");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(256);
            builder.HasIndex(x => x.Description).IsUnique();
        }
    }
}
