namespace Online_Store_link.Models.DTOs;

//from server to angular, make client read from server
// remove DataAnnotations and schema
public record ProductReadDTO
{
    public Guid ProductID { get; init; }
    public string? Name { get; init; }
    public string? ArabicName { get; init; }
    public string? Description { get; init; }
    public double Price { get; init; }
    public int Quantity { get; init; }
    public string? ImagePath { get; set; }

    public CategoryChildReadDTO? Category { get; set; }
    public VendorReadDTO? Vendor { get; set; }
}
