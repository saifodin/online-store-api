using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Online_Store_link.Models.DBModels;

public class Product
{
    public Guid ProductID { get; set; }

    [Required(ErrorMessage = "Product {0} is Must")]
    [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "Use English letters only please")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "{0} is Must")]
    [RegularExpression(@"^[\u0621-\u064A\s]+$", ErrorMessage = "Use Arabic characters only please")]
    public string? ArabicName { get; set; }

    [Required(ErrorMessage = "Product {0} is Must")]
    public string? Description { get; set; }

    [Required(ErrorMessage = "Product {0} is Must")]
    [Range(0, 100000, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
    [Column(TypeName = "money")]
    public double Price { get; set; }

    [Required(ErrorMessage = "Product {0} is Must")]
    [Range(0, 10000, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
    public int Quantity { get; set; }

    [ForeignKey("Category")]
    [Required(ErrorMessage = "Product {0} is Must")]
    public Guid? CategoryID { get; set; }

    [ForeignKey("Vendor")]
    [Required(ErrorMessage = "Product {0} is Must")]
    public Guid? VendorID { get; set; }

    [Required(ErrorMessage = "Product Image is Must")]
    public string? ImagePath{ get;set; }


    public Category? Category { get; set; }
    public Vendor? Vendor { get; set; }
}
