using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlexPortTracking.Models
{
    public class ReaderType
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public virtual ICollection<Reader> Readers { get; set; }
    }

    public class ReaderTypeConfiguration : IEntityTypeConfiguration<ReaderType>
    {
        public void Configure(EntityTypeBuilder<ReaderType> builder)
        {
            builder.ToTable("ReaderTypes");
            builder.HasKey(rt => rt.Id);
            builder.Property(rt => rt.Name).IsRequired().HasMaxLength(128);
            builder.Property(rt => rt.Description).IsRequired().HasMaxLength(512);


            builder.HasData(
                new ReaderType { Id = 1, Name = "دخول", Description = "قارئ على بوابة دخول"},
                new ReaderType { Id = 2, Name = "خروج", Description = "قارئ على بوابة خروج"},
                new ReaderType { Id = 3, Name = "ميزان", Description = "قارئ على طريق ميزان"}
                );

        }
    }
}
