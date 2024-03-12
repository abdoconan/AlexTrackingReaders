using System.ComponentModel.DataAnnotations;

namespace AlexPortTracking.DTOs
{
    public record ReaderTypeDTO(int? Id, [Required] string Name , string? Description);
}
