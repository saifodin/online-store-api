using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Online_Store_link.Models.DBModels;

namespace Online_Store_link.Data.Context;

public class OnlineStoreContext: IdentityDbContext<User>
{
    public DbSet<Product>? Products { get; set; }
    public DbSet<Category>? Categories { get; set; }
    public DbSet<Vendor>? Vendors { get; set; }
    public DbSet<Cart>? Carts { get; set; }
    public DbSet<Order>? Orders { get; set; }
    public DbSet<OrderProduct>? OrderProducts { get; set; }

    public OnlineStoreContext(DbContextOptions<OnlineStoreContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        #region Add Composite Primary Key For Some Tables
        modelBuilder.Entity<Cart>().HasKey(c => new { c.ProductId, c.CustomerId });
        modelBuilder.Entity<OrderProduct>().HasKey(o => new { o.ProductId, o.OrderId });
        #endregion

        #region Add Static Data Into Vendor Table
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

        base.OnModelCreating(modelBuilder);

        #region Rename Identity Tables
        modelBuilder.Entity<Customer>().ToTable("Customer");
        modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("CustomerClaims");

        modelBuilder.Entity<Admin>().ToTable("Admin");
        //modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("AdminClaims");
        #endregion
    }

}