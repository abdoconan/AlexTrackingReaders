using System.ComponentModel.DataAnnotations;

namespace AlexPortTracking.DTOs
{
    public record CarDTO(int? Id,
        [Required][MaxLength(128)] string FrontTag,
        [Required][MaxLength(128)] string RearTag,
        [MaxLength(128)] string PlateNumber,
        [MaxLength(512)] string OwnerName,
        int NumberOfAxes,
        float WeightInTon,
        int CarModel,
        DateTime LicenceExpiryDate);



}
