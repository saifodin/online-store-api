namespace Online_Store_link.Models.DTOs;

public record LoginDTO
{
    public string? UserName { get; init; }
    public string? Password { get; init; }
}

