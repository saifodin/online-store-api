using Microsoft.EntityFrameworkCore;
using Online_Store_link.Data.Context;
using Online_Store_link.Models.DBModels;

namespace Online_Store_link.Data.Repositories;

public class CategoryRepository: GenericRepository<Category>, ICategoryRepository
{
    private readonly OnlineStoreContext context;

    public CategoryRepository(OnlineStoreContext context) : base(context)
    {
        this.context = context;
    }

    public List<Category>? GetLeafCategories()
    {
        List<Category>? allCategories = context.Categories?.ToList();
        //if(allCategories is null || allCategories.Count == 0)
        //    return allCategories;

        List<Category>? categoriesHaveParent = context.Categories?.Where(c => c.ParentCategoryID != null).ToList();
        //if(categoriesHaveParent is null || categoriesHaveParent.Count == 0)
        //    return allCategories;

        HashSet<Category> categoriesNotLeaf = new();
        foreach (Category category in categoriesHaveParent)
        {
            Category caterogyNotLeaf = GetById((Guid)category.ParentCategoryID);
            categoriesNotLeaf.Add(caterogyNotLeaf);
        }
        List<Category> hList = categoriesNotLeaf.ToList();

        return allCategories.Except(categoriesNotLeaf).ToList();
    }

    public List<Category>? GetCategoriesWithListOfProductst()
    {
        return context.Categories?.Include("Products").ToList();
    }

    public List<Category>? GetCategoriesWithParents(int categoriesPerPage, int pageNumber)
    {
        if (categoriesPerPage < 1 || pageNumber < 1)
            return null;

        var total = GetCount();
        int skip = categoriesPerPage * (pageNumber - 1);

        if (skip >= total)
            return null;

        return context.Categories?.Include("ParentCategory").OrderBy(c => c.Name).ToList()?.Skip(skip).Take(categoriesPerPage).ToList(); ;
    }

    public List<Category>? GetCategoriesCanBeParent()
    {
        return GetCategoriesWithListOfProductst()?.Where(c => c.Products?.Count == 0).ToList();
    }

    public bool IsFound(Guid id)
    {
        return context.Categories?.FirstOrDefault(c => c.CategoryID == id) is not null;
    }

    public bool IsLeaf(Guid id)
    {
        return GetLeafCategories()?.FirstOrDefault(c => c.CategoryID == id) is not null;
    }

    public List<Category>? GetDirectChildCategories(Guid id)
    {
        return context.Categories?.Where(c => c.ParentCategoryID == id).ToList();
    }

    public List<Category>? GetParentCategories()
    {
        return context.Categories?.Where(c => c.ParentCategoryID == null).ToList();
    }

    public List<Category>? GetCategoriesSorte()
    {
        return context.Categories?.OrderBy(c => c.Name).ToList();
    }

    public List<Category>? GetCategoriesPerPage(int categoriesPerPage, int pageNumber)
    {
        if (categoriesPerPage < 1 || pageNumber < 1)
            return null;

        var total = GetCount();
        int skip = categoriesPerPage * (pageNumber - 1);

        if (skip >= total)
            return null;

        return GetCategoriesSorte()?.Skip(skip).Take(categoriesPerPage).ToList(); ;
    }

    public Category GetCategoryWithParentById(Guid id)
    {
       return context.Categories?.Include("Products").FirstOrDefault(c => c.CategoryID == id);
    }

    public List<Category> GetCategoriesWhichHaveProduct()
    {
        return context.Categories?.Where(c => c.Products.Count > 0).ToList();
    }
}
    