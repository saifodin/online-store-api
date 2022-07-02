namespace Online_Store_link.Models.DTOs;

public class PorductChildReadDTO
{
    public Guid ProductID { get; init; }
    public string? Name { get; init; }
    public string? ArabicName { get; init; }
    public string? Description { get; init; }
    public double Price { get; init; }
    public int Quantity { get; init; }
    public VendorReadDTO? Vendor { get; set; }
}
