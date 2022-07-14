using System.ComponentModel.DataAnnotations;

namespace Online_Store_link.Models.DTOs;

public class OrderWriteDTO
{
    [Required(ErrorMessage = "{0} Field is Must")]
    public string? Country { get; set; }

    [Required(ErrorMessage = "{0} Field is Must")]
    public string? City { get; set; }

    [Required(ErrorMessage = "{0} Field is Must")]
    public string? Address { get; set; }

    [Required(ErrorMessage = "{0} Field is Must")]
    [RegularExpression(@"^([0-9]{11})*$", ErrorMessage = "Phone is invalid")]
    public string? Phone { get; set; }

    //[RegularExpression(@"^('Cash on delivery'|'Vodafone cash')$", ErrorMessage = "Not Recognize this PaymentMethod")]
    [Required(ErrorMessage = "Product {0} is Must")]
    public string? PaymentMethod { get; set; }
}
