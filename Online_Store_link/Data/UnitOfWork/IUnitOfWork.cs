using Online_Store_link.Data.Repositories;

namespace Online_Store_link.Data.UnitOfWork;

public interface IUnitOfWork
{
    IProductRepository ProductRepository { get; }
    ICategoryRepository CategoryRepository { get; } 
    IVendorRepository VendorRepository { get; } 
}
