using Microsoft.AspNetCore.Identity;

namespace Online_Store_link.Models.DBModels;

public class User : IdentityUser
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
}
