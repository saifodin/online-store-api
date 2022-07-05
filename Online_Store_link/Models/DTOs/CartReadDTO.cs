namespace Online_Store_link.Models.DTOs;

public record CartReadDTO
{
    public Guid? ProductId { get; init; }
    public string? CustomerId { get; init; }
    public int Quantity { get; init; }
    public ProductReadDTO? Product { get; init; }

}
