using Microsoft.EntityFrameworkCore;
using Online_Store_link.Models.DBModels;

namespace Online_Store_link.Data.Context;

public class OnlineStoreContext: DbContext
{
    public DbSet<Product>? Products { get; set; }
    public DbSet<Category>? Categories { get; set; }
    public DbSet<Vendor>? Vendors { get; set; }

    public OnlineStoreContext(DbContextOptions<OnlineStoreContext> options) : base(options) { }

    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        #region Vendors
        modelBuilder.Entity<Vendor>().HasData(
            new Vendor
            {
                VendorID = Guid.NewGuid(),
                Name = "Saifuddin Ibrahim",
                Address = "Cairo",
                Email = "saif@saif.com",
            },
            new Vendor
            {
                VendorID = Guid.NewGuid(),
                Name = "Ali Hamed",
                Address = "Cairo",
                Email = "ali@ali.com",
            },
            new Vendor
            {
                VendorID = Guid.NewGuid(),
                Name = "Islam Ahmed",
                Address = "Cairo",
                Email = "islam@islam.com",
            },
            new Vendor
            {
                VendorID = Guid.NewGuid(),
                Name = "Khaled Lotfy",
                Address = "Cairo",
                Email = "khaled@khaled.com",
            }
        );
        #endregion

        #region Products
        /*
        modelBuilder.Entity<Product>().HasData(
            new Product
            {
                ProductID = Guid.NewGuid(),
                Name = "PlayStation",
                ArabicName = "بلاي ستايشن",
                Description = "playStation 5 plack color come with 2 hadles",
                Price = 2200.5,
                Quantity = 5,
            },
            new Product
            {
                ProductID = Guid.NewGuid(),
                Name = "Mobile",
                ArabicName = "بلاي ستايشن",
                Description = "playStation 5 plack color come with 2 hadles",
                Price = 2200.5,
                Quantity = 5,
            },
            new Product
            {
                ProductID = Guid.NewGuid(),
                Name = "IPhone",
                ArabicName = "بلاي ستايشن",
                Description = "playStation 5 plack color come with 2 hadles",
                Price = 2200.5,
                Quantity = 5,
            },
            new Product
            {
                ProductID = Guid.NewGuid(),
                Name = "Tablet",
                ArabicName = "بلاي ستايشن",
                Description = "playStation 5 plack color come with 2 hadles",
                Price = 2200.5,
                Quantity = 5,
            }
            );
        */
        #endregion

        base.OnModelCreating(modelBuilder);
    }

}