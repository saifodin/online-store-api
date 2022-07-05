namespace Online_Store_link.Models.DTOs;

public record TokenDTO
{
    public string? Token { get; init; }
    public DateTime ExpiryDate { get; set; }
}

