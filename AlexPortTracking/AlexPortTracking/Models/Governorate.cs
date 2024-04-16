using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlexPortTracking.Models
{
    public class Governorate
    {
        public int Id { get; set; }
        public string DescriptionAr { get; set; }
        public string DescriptionEn { get; set; }

        // navigation proporites
        public ICollection<Car> Cars { get; set; }
    }


    public class GovernorateConfiguration : IEntityTypeConfiguration<Governorate>
    {
        public void Configure(EntityTypeBuilder<Governorate> builder)
        {
            builder.ToTable("Governorate");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.DescriptionAr).IsRequired().HasMaxLength(256);
            builder.HasIndex(x => x.DescriptionEn).IsUnique();
        }
    }
}
