using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Online_Store_link.Models.DBModels;

public class Customer : IdentityUser
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
}
