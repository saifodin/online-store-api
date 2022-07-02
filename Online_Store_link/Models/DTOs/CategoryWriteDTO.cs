using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Online_Store_link.Models.DTOs;

public class CategoryWriteDTO
{
    public Guid CategoryID { get; set; }

    [Required(ErrorMessage = "Category {0} is Must")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "Category {0} is Must")]
    public string? Description { get; set; }

    public Guid? ParentCategoryID { get; set; }
}
