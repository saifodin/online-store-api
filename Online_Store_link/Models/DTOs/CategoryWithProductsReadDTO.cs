namespace Online_Store_link.Models.DTOs;

public class CategoryWithProductsReadDTO
{
    public Guid CategoryID { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public Guid? ParentCategoryID { get; set; }
    public ICollection<PorductChildReadDTO>? Products { get; set; }
}
