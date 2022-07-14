using Microsoft.EntityFrameworkCore;
using Online_Store_link.Data.Context;
using Online_Store_link.Models.DBModels;
using Online_Store_link.Models.DTOs;

namespace Online_Store_link.Data.Repositories;

public class OrderRepository: GenericRepository<Order>, IOrderRepository
{
    private readonly OnlineStoreContext context;

    public OrderRepository(OnlineStoreContext context) : base(context)
    {
        this.context = context;
    }

    private void ChangeProductQuantity(Guid productId, int subtractQuantity)
    {
        var product = context.Products?.First(p => p.ProductID == productId);
        product.Quantity = product.Quantity - subtractQuantity;
    }

    public void MakeOrder(string customerId, 
        Guid orderId,
        OrderWriteDTO order,
        CartInfoReadDTO cartInfo,
        List<OrderProduct> productAndQuantityInCart)
    {
        //Add Order Details into Orders Table
        context.Orders.Add(new Order
        {
            OrderId = orderId,
            CustomerId = customerId,
            Address = order.Address,
            City = order.City,
            Country = order.Country,
            Phone = order.Phone,
            PaymentMethod = order.PaymentMethod,
            TotatlPrice = cartInfo.CartTotalPrice,
            ItemsCount = cartInfo.CartCount
        });
        context.SaveChanges();

        //Add Product Details into OrderProduct Table
        context.OrderProducts.AddRange(productAndQuantityInCart);
        context.SaveChanges();

        //Subtract the Quantity in the stock
        foreach (var product in productAndQuantityInCart)
        {
            ChangeProductQuantity((Guid)product.ProductId, product.Quantity);
        }
        context.SaveChanges();







    }

    public List<Order> GetAllOrders(string customerId)
    {
        return context.Orders.Where(o => o.CustomerId == customerId).ToList();
    }

    public List<OrderProduct>? GetOrderDetail(Guid orderId, string customerId)
    {
        var order = context.Orders.FirstOrDefault(o => o.OrderId == orderId);

        // make sure that this order in customer account
        if(order.CustomerId == customerId)
        {
            return context.OrderProducts.Include("Product").Where(o => o.OrderId == orderId).ToList();
        }

        return null;
    }



}
