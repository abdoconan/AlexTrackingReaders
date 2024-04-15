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
}
