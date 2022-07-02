using System.ComponentModel.DataAnnotations;

namespace Online_Store_link.Models.DTOs;

// from angular to server, make client write in server
// remove schema only, not DataAnnotations

public record ProductWriteDTO
{
    public Guid? ProductID { get; set; }

    [Required(ErrorMessage = "Product Name is Must")]
    [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "Use English letters only please")]
    public string? Name { get; init; }

    [Required(ErrorMessage = "{0} is Must")]
    [RegularExpression(@"^[\u0621-\u064A\s]+$", ErrorMessage = "Use Arabic characters only please")]
    public string? ArabicName { get; init; }

    [Required(ErrorMessage = "Product {0} is Must")]
    public string? Description { get; init; }

    [Required(ErrorMessage = "Product {0} is Must")]
    [Range(0, 100000, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
    // without nullable "?" , if user not enter Price, no error, will add with 0
    // with nullabe "?", if user not enter Price, Bad request, because it's required
    public double? Price { get; init; }

    [Required(ErrorMessage = "Product {0} is Must")]
    [Range(0, 10000, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
    public int? Quantity { get; init; }

    [Required(ErrorMessage = "Product {0} is Must")]
    public Guid? CategoryID { get; set; }

    [Required(ErrorMessage = "Product {0} is Must")]
    public Guid? VendorID { get; set; }

    [Required(ErrorMessage = "Product Image is Must")]
    public string? ImagePath { get; set; }
}
