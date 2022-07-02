using Online_Store_link.Data.Repositories;

namespace Online_Store_link.Data.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    public IProductRepository ProductRepository { get; }
    public ICategoryRepository CategoryRepository { get; }
    public IVendorRepository VendorRepository { get; }


    public UnitOfWork(IProductRepository productRepository, ICategoryRepository categoryRepository, IVendorRepository vendorRepository)
    {
        ProductRepository = productRepository;
        CategoryRepository = categoryRepository;
        VendorRepository = vendorRepository;
    }
}
