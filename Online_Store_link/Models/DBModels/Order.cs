using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Online_Store_link.Models.DBModels;

public class Order
{
    public Guid OrderId { get; set; }

    [ForeignKey("Customer")]
    [Required(ErrorMessage = "Product {0} is Must")]
    public string? CustomerId { get; set; }

    [Required(ErrorMessage = "{0} Field is Must")]
    public string? Country { get; set; }

    [Required(ErrorMessage = "{0} Field is Must")]
    public string? City { get; set; }

    [Required(ErrorMessage = "{0} Field is Must")]
    public string? Address { get; set; }

    [Required(ErrorMessage = "{0} Field is Must")]
    [RegularExpression(@"^([0-9]{11})*$", ErrorMessage = "Phone is invalid")]
    public string? Phone { get; set; }

    [RegularExpression(@"^('Cash on delivery'|'Vodafone cash')$", ErrorMessage = "Not Recognize this PaymentMethod")]
    [Required(ErrorMessage = "Product {0} is Must")]
    public string? PaymentMethod { get; set; }

    public int ItemsCount { get; set; }

    public double TotatlPrice { get; set; }

    public Customer? Customer { get; set; }
}
