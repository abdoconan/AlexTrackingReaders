using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace AlexPortTracking.Models
{
    public class CarType
    {
        public int Id { get; set; }

        public string Description { get; set; }

        // navigation properties
        public ICollection<Car> Cars { get; set; }
    }

    public class CarTypeConfiguration : IEntityTypeConfiguration<CarType>
    {
        public void Configure(EntityTypeBuilder<CarType> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(256);
            builder.HasIndex(x => x.Description).IsUnique();
        }
    }
}
