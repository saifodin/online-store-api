using Online_Store_link.Models.DBModels;
using Online_Store_link.Models.DTOs;

namespace Online_Store_link.Data.Repositories;

public interface IOrderRepository: IGenericRepository<Order>
{
    void MakeOrder(string customerId, 
        Guid orderId,
        OrderWriteDTO order,
        CartInfoReadDTO cartInfo,
        List<OrderProduct> productAndQuantityInCart);

    List<Order> GetAllOrders(string customerId);

    List<OrderProduct>? GetOrderDetail(Guid orderId, string customerId);
}
