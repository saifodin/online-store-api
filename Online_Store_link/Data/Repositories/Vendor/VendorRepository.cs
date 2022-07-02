using Online_Store_link.Data.Context;
using Online_Store_link.Models.DBModels;

namespace Online_Store_link.Data.Repositories;

public class VendorRepository: GenericRepository<Vendor>, IVendorRepository
{
    private readonly OnlineStoreContext context;

    public VendorRepository(OnlineStoreContext context) : base(context)
    {
        this.context = context;
    }

    public bool IsFound(Guid id)
    {
        return context.Vendors?.FirstOrDefault(c => c.VendorID == id) is not null;
    }
}
