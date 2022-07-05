using Microsoft.EntityFrameworkCore;
using Online_Store_link.Data.Context;
using Online_Store_link.Models.DBModels;
using Online_Store_link.Models.DTOs;

namespace Online_Store_link.Data.Repositories;

public class CartRepository: GenericRepository<Cart>, ICartRepository
{
    private readonly OnlineStoreContext context;

    public CartRepository(OnlineStoreContext context) : base(context)
    {
        this.context = context;
    }

    public List<Cart> GetAllInCart(string customerId)
    {
        return context.Carts.Include("Product").Include("Product.Category").Include("Product.Vendor").Where(c => c.CustomerId == customerId).ToList();
    }

    private Cart? GetProductInCart(string customerId, Guid productId)
    {
        return context.Carts?.FirstOrDefault(c => c.CustomerId == customerId && c.ProductId == productId);
    }

    public bool AddOneToCart(string customerId, Guid productId)
    {
        Cart? cart = GetProductInCart(customerId, productId);
        if (cart is null)
        { 
            Add(new Cart { CustomerId = customerId, ProductId = productId, Quantity = 1 });
        }
        else
        {
            cart.Quantity++;
            Update(cart);
        }
        return true;
    }

    public bool RemoveFromCart(string customerId, Guid productId)
    {
        Cart? cart = GetProductInCart(customerId, productId);
        if (cart is null)
            return false;

        context.Carts?.Remove(cart);
        return true;
    }

    public bool RmoveOneFromCart(string customerId, Guid productId)
    {
        Cart? cart = GetProductInCart(customerId, productId);
        if (cart is null)
            return false;

        if (cart.Quantity > 1)
            cart.Quantity--;
        else if(cart.Quantity == 1)
            context.Carts?.Remove(cart);

        return true;
    }

    public bool AddToCartWithQuantity(string customerId, Guid productId, int quantity)
    {
        Cart? cart = GetProductInCart(customerId, productId);
        if (cart is null)
        {
            Add(new Cart { CustomerId = customerId, ProductId = productId, Quantity = quantity });
        }
        else
        {
            cart.Quantity = quantity;
            Update(cart);
        }
        return true;
    }

    public bool ClearCart(string customerId)
    {
        Cart? firstProductInCart = context.Carts?.FirstOrDefault(c => c.CustomerId == customerId);
        if (firstProductInCart is null)
            return false;

        var allCart = context.Carts.Where(c => c.CustomerId == customerId).ToList();
        context.Carts.RemoveRange(allCart);

        return true;
    }

    public CartInfoReadDTO GetCoutnAndTotalPrice(string customerId)
    {
        var cartCount = context.Carts.Where(c => c.CustomerId == customerId).Sum(c => c.Quantity);
        var cartTotalPrice = context.Carts.Where(c => c.CustomerId == customerId).Sum(c => c.Quantity * c.Product.Price);
        return new CartInfoReadDTO()
        {
            CartCount = cartCount,
            CartTotalPrice = cartTotalPrice,
        };      
    }
}
