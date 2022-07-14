namespace Online_Store_link.Models.DTOs;

public class OrderReadDTO
{
    public Guid OrderId { get; set; }
    public string? CustomerId { get; set; }
    public string? Country { get; set; }
    public string? City { get; set; }
    public string? Address { get; set; }
    public string? Phone { get; set; }
    public string? PaymentMethod { get; set; }
    public int ItemsCount { get; set; }
    public double TotatlPrice { get; set; }
}
