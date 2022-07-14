using Online_Store_link.Models.DBModels;
using Online_Store_link.Models.DTOs;

namespace Online_Store_link.Data.Repositories;

public interface ICartRepository: IGenericRepository<Cart>
{
    bool AddOneToCart(string customerId, Guid productId);
    bool RemoveFromCart(string customerId, Guid productId);
    bool RmoveOneFromCart(string customerId, Guid productId);
    List<Cart>? GetAllInCart(string customerId);
    bool AddToCartWithQuantity(string customerId, Guid productId, int quantity);
    bool ClearCart(string customerId);
    CartInfoReadDTO GetCoutnAndTotalPrice(string customerId);
    List<ProductAndQuantityDTO> CheckProductsAvailability(string customerId);
    List<OrderProduct> GetProductAndQuantityInCart(string customerId, Guid orderId);
}
