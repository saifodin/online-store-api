using Online_Store_link.Data.Context;
using Online_Store_link.Models.DBModels;

namespace Online_Store_link.Data.Repositories;

public class CustomerRepository: GenericRepository<Customer>, ICustomerRepository
{
    private readonly OnlineStoreContext context;

    public CustomerRepository(OnlineStoreContext context) : base(context)
    {
        this.context = context;
    }

}
