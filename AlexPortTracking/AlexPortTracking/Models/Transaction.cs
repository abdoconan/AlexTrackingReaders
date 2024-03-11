using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlexPortTracking.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public string Tag { get; set; } = string.Empty;
        public int ReaderId { get; set; }
        public int CarId { get; set; }
        public int Count { get; set; }
        public DateTime LogTime { get; set; }
        public DateTime LastLogTime { get; set; }


        // navigation properties
        public virtual Car Car { get; set; }
        public virtual Reader Reader { get; set; }
    }

    public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.HasKey(t => t.Id);
            builder.HasOne(t => t.Car)
                .WithMany(c => c.Transactions)
                .HasForeignKey(t => t.CarId)
                .IsRequired();
            builder.HasOne(t => t.Reader)
                .WithMany(r => r.Transactions)
                .HasForeignKey(t => t.ReaderId)
                .IsRequired();

            builder.Property(t => t.LogTime).HasDefaultValue(DateTime.Now);
            builder.Property(t => t.Tag).HasMaxLength(128).IsRequired();    
        }
    }


}
