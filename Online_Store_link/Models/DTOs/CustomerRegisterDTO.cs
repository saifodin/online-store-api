using System.ComponentModel.DataAnnotations;

namespace Online_Store_link.Models.DTOs;

public class CustomerRegisterDTO
{
    [Required(ErrorMessage = "Category {0} is Must")]
    public string? FirstName { get; set; }

    [Required(ErrorMessage = "Category {0} is Must")]
    public string? LastName { get; set; }

    public string? Email { get; set; }
    public string? Password { get; init; }
}
