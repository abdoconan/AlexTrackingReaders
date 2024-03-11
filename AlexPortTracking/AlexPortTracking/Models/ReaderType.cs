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
            builder.HasKey(rt => rt.Id);
            builder.Property(rt => rt.Name).IsRequired().HasMaxLength(128);
            builder.Property(rt => rt.Description).IsRequired().HasMaxLength(512);


            builder.HasData(
                new ReaderType { Id = 1, Name = "in", Description = "This is used for in lanes"},
                new ReaderType { Id = 2, Name = "out", Description = "This is used for out lanes"},
                new ReaderType { Id = 3, Name = "scale", Description = "This is used for weight lanes"}
                );

        }
    }
}
