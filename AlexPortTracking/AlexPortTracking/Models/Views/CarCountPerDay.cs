using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlexPortTracking.Models.Views
{
    public class CarCountPerDay
    {

        public int Id { get; set; }
        public int CarId { get; set; }
        public int ReaderId { get; set; }
        public int ReaderTypeId { get; set; }
        public string ReaderName { get; set; }
        public string ReaderTypeName { get; set; }
        public DateTime DayDate { get; set; }
    }

    public class CarCountPerDayConfiguration : IEntityTypeConfiguration<CarCountPerDay>
    {
        public void Configure(EntityTypeBuilder<CarCountPerDay> builder)
        {
            builder.ToView("CarCountPerDay");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CarId).HasColumnName("CarId");
            builder.Property(x => x.ReaderTypeId).HasColumnName("ReaderTypeId");
            builder.Property(x => x.ReaderId).HasColumnName("ReaderId");
            builder.Property(x => x.ReaderName).HasColumnName("ReaderName");
            builder.Property(x => x.ReaderTypeName).HasColumnName("ReaderTypeName");
            builder.Property(x => x.DayDate).HasColumnName("DayDate");
        }
    }

}
