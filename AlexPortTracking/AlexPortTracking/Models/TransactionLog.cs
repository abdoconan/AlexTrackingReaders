using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlexPortTracking.Models
{
    public class TransactionLog
    {
        public int Id { get; set; }
        public int ReaderId { get; set; }
        public int? CarId { get; set; }
        public string Tag { get; set; } = string.Empty;
        public DateTime LogTime { get; set; }

        public Reader Reader { get; set; }
        public Car? Car { get; set; }
    }

    public class TransactionLogConfiguration : IEntityTypeConfiguration<TransactionLog>
    {
        public void Configure(EntityTypeBuilder<TransactionLog> builder)
        {
            builder.HasKey(tl => tl.Id);
            builder.HasOne(tl => tl.Reader)
                .WithMany(r => r.TransactionLogs)
                .HasForeignKey(tl => tl.ReaderId)
                .IsRequired();

            builder.HasOne(tl => tl.Car)
                .WithMany(c => c.TransactionLogs)
                .HasForeignKey(tl => tl.CarId);

            builder.Property(tl => tl.Tag).HasMaxLength(128);
            builder.Property(tl => tl.LogTime).HasDefaultValue(DateTime.Now);
        }
    }
}
