using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlexPortTracking.Models
{
    public class Reader
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Signature { get; set; } = string.Empty;
        public int PortNumber { get; set; }
        public int ReaderTypeId { get; set; }


        // Navigation Properties
        public virtual ReaderType ReaderType { get; set; }
        public virtual ICollection<TransactionLog> TransactionLogs { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
    }

    public class ReaderConfiguration : IEntityTypeConfiguration<Reader>
    {
        public void Configure(EntityTypeBuilder<Reader> builder)
        {
            builder.ToTable("Readers");
            builder.HasKey(r => r.Id);
            builder.Property(r => r.Name).IsRequired().HasMaxLength(128);
            builder.Property(r => r.Signature).IsRequired().HasMaxLength(128);
            builder.Property(r => r.PortNumber).IsRequired().HasAnnotation("MinValue", 1024);
            builder.HasOne(r => r.ReaderType)
                .WithMany(rl => rl.Readers)
                .HasForeignKey(r => r.ReaderTypeId)
                .IsRequired();

        }
    }
}
