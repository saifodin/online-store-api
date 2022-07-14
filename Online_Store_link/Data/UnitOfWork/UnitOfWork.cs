using Online_Store_link.Data.Repositories;

namespace Online_Store_link.Data.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    public IProductRepository ProductRepository { get; }
    public ICategoryRepository CategoryRepository { get; }
    public IVendorRepository VendorRepository { get; }
    public ICustomerRepository CustomerRepository { get; }
    public ICartRepository CartRepository { get; }
    public IOrderRepository OrderRepository { get; }

    public UnitOfWork(
        IProductRepository productRepository,
        ICategoryRepository categoryRepository,
        IVendorRepository vendorRepository,
        ICustomerRepository customerRepository,
        ICartRepository cartRepository,
        IOrderRepository orderRepository)
    {
        ProductRepository = productRepository;
        CategoryRepository = categoryRepository;
        VendorRepository = vendorRepository;
        CustomerRepository = customerRepository;
        CartRepository = cartRepository;
        OrderRepository = orderRepository;
    }
}
