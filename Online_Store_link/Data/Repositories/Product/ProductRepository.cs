using Microsoft.EntityFrameworkCore;
using Online_Store_link.Data.Context;
using Online_Store_link.Models.DBModels;

namespace Online_Store_link.Data.Repositories;

public class ProductRepository : GenericRepository<Product>, IProductRepository
{
    private readonly OnlineStoreContext context;

    public ProductRepository(OnlineStoreContext context) : base(context)
    {
        this.context = context;
    }

    public List<Product>? GetProductsByCategoryID(Guid id)
    {
        return context.Products?.Where(p => p.CategoryID == id).ToList();
    }

    public List<Product>? GetProductsFullInfromation()
    {
        var x = context.Products?.Include("Category").Include("Vendor").ToList()
            .OrderBy(p => p.Category.Name).ThenBy(p => p.Name).ToList();
        return x;
    }

    public Product? GetProductById(Guid id)
    {
        return context.Products?.Include("Category").Include("Vendor").FirstOrDefault(p => p.ProductID == id);
    }

    public List<Product> GetProductsByName(string name)
    {
        return context.Products.Where(p => p.Name.ToLower().Contains(name.Trim().ToLower())).ToList();
    }

    public List<Product>? GetProductsPerPage(int productsPerPage, int pageNumber)
    {
        if (productsPerPage < 1 || pageNumber < 1)
            return null;

        var total = GetCount();
        int skip = productsPerPage * (pageNumber - 1);

        if (skip >= total)
            return null;

        return GetProductsFullInfromation()?.Skip(skip).Take(productsPerPage).ToList();            ;
    }

}
