namespace Online_Store_link.Models.DTOs;

public class ProductAndQuantityDTO
{
    public ProductAndQuantityDTO(Guid productId, int quantity)
    {
        ProductId = productId;
        Quantity = quantity;
    }
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
}
