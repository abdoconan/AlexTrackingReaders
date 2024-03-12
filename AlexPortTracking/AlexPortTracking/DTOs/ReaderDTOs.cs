using System.ComponentModel.DataAnnotations;

namespace AlexPortTracking.DTOs
{
    public record ReaderDTO(int? Id,
           [Required] string Name,
           [Required] string Signature,
           [Required][Range(1024, 20000, ErrorMessage = "Value must be between {1} and {2}.")] int PortNumber,
           [Required] int ReaderTypeId);


    public record ReaderWithTypeDTO (int? Id,
           [Required] string Name,
           [Required] string Signature,
           [Required][Range(1024, 20000, ErrorMessage = "Value must be between {1} and {2}.")] int PortNumber,
           [Required] int ReaderTypeId,
           ReaderTypeDTO ReaderType) : ReaderDTO (Id, Name, Signature, PortNumber, ReaderTypeId);
}
