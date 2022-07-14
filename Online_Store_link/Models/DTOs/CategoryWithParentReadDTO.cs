using Online_Store_link.Models.DBModels;

namespace Online_Store_link.Models.DTOs;

public class CategoryWithParentReadDTO
{
    public Guid CategoryID { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public Guid? ParentCategoryID { get; set; }


    public CategoryChildReadDTO? ParentCategory { get; set; }
}
