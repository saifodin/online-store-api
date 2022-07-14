namespace Online_Store_link.Models.DTOs;

public class OrderProductReadDTO
{
    public int Quantity { get; set; }
    public ProductReadDTO? Product { get; set; }
}
