namespace Online_Store_link.Models.DTOs;

public class CategoryReadDTO
{
    public Guid CategoryID { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public Guid? ParentCategoryID { get; set; }
}
