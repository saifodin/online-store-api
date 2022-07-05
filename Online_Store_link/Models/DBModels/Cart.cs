using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Online_Store_link.Models.DBModels;

public class Cart
{
    [ForeignKey("Product")]
    [Required(ErrorMessage = "Product {0} is Must")]
    public Guid? ProductId { get; set; }

    [ForeignKey("Customer")]
    [Required(ErrorMessage = "Product {0} is Must")]
    public string? CustomerId { get; set; }

    [Required(ErrorMessage = "Product {0} is Must")]
    [Range(0, 10000, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
    public int Quantity { get; set; }

    public Product? Product { get; set; }
    public Customer? Customer { get; set; }
}
