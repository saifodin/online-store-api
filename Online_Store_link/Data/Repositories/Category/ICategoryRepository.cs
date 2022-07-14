using Online_Store_link.Models.DBModels;
using Online_Store_link.Models.DTOs;

namespace Online_Store_link.Data.Repositories;

public interface ICategoryRepository: IGenericRepository<Category>
{
    List<Category>? GetLeafCategories();
    bool IsFound(Guid id);
    bool IsLeaf(Guid id);
    List<Category>? GetDirectChildCategories(Guid id);
    List<Category>? GetParentCategories();
    List<Category>? GetCategoriesSorte();
    List<Category>? GetCategoriesPerPage(int categoriesPerPage, int pageNumber);
    List<Category>? GetCategoriesCanBeParent();
    List<Category>? GetCategoriesWithListOfProductst();
    List<Category>? GetCategoriesWithParents(int categoriesPerPage, int pageNumber);
    Category GetCategoryWithParentById(Guid id);
}
