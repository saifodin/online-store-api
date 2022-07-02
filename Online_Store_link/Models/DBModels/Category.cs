using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Online_Store_link.Models.DBModels;

public class Category
{
    public Guid CategoryID { get; set; }

    [Required(ErrorMessage = "Category {0} is Must")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "Category {0} is Must")]
    public string? Description { get; set; }

    [ForeignKey("ParentCategory")]
    public Guid? ParentCategoryID { get; set; }


    public Category? ParentCategory { get; set; }
    public ICollection<Product>? Products { get; set; }
}
    