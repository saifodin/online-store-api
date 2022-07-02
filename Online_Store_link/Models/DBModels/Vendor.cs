using System.ComponentModel.DataAnnotations;

namespace Online_Store_link.Models.DBModels;

public class Vendor
{
    public Guid VendorID { get; set; }

    [Required(ErrorMessage = "{0} is Must")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "{0} is Must")]
    public string? Address { get; set; }

    [Required(ErrorMessage = "{0} is Must")]
    public string? Email { get; set; }

    public ICollection<Product>? Products { get; set; }
}
