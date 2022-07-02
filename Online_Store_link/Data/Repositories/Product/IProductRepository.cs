using Online_Store_link.Models.DBModels;

namespace Online_Store_link.Data.Repositories;

public interface IProductRepository: IGenericRepository<Product>
{
    List<Product>? GetProductsByCategoryID(Guid id);
    List<Product>? GetProductsFullInfromation();
    List<Product>? GetProductsPerPage(int productsPerPage, int pageNumber);
    Product? GetProductById(Guid id);
}
