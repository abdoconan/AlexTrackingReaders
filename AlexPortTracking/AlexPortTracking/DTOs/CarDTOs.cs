
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
        float  MaxLoadedWeight,
        float Length,
        int CarModel,
        DateTime LicenceExpiryDate,
        int? CarClassId,
        int? CarTypeId,
        int? GovernorateId);

    public record CarDetailsDTO
        (int? Id,
        [Required][MaxLength(128)] string FrontTag,
        [Required][MaxLength(128)] string RearTag,
        [MaxLength(128)] string PlateNumber,
        [MaxLength(512)] string OwnerName,
        int NumberOfAxes,
        float WeightInTon,
        float MaxLoadedWeight,
        float Length,
        int CarModel,
        DateTime LicenceExpiryDate,
        int? CarClassId,
        int? CarTypeId,
        int? GovernorateId,
        CarClassDTOs CarClass, 
        CarTypeDTO CarType,
        GovernorateDTO Governorate
        ) 
            : 
        CarDTO(Id
            , FrontTag
            , RearTag
            , PlateNumber
            , OwnerName
            , NumberOfAxes
            , WeightInTon
            , MaxLoadedWeight
            , Length
            , CarModel
            , LicenceExpiryDate
            , CarClassId
            , CarTypeId
            , GovernorateId);




}
