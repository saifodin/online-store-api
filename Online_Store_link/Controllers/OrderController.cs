using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Online_Store_link.Data.UnitOfWork;
using Online_Store_link.Models.DBModels;
using Online_Store_link.Models.DTOs;
using System.Security.Claims;

namespace Online_Store_link.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class OrderController : ControllerBase
{
    private readonly IUnitOfWork unitOfWork;
    private readonly UserManager<Customer> userManager;
    private readonly IMapper mapper;

    public OrderController(
        IUnitOfWork unitOfWork,
        UserManager<Customer> userManager,
        IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.userManager = userManager;
        this.mapper = mapper;
    }

    [HttpPost]
    public ActionResult PostOrder(OrderWriteDTO order)
    {
        string customerId = userManager.FindByNameAsync(User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value).Result.Id;

        List<ProductAndQuantityDTO> productsInCartNotAvailable = unitOfWork.CartRepository.CheckProductsAvailability(customerId);
        if (productsInCartNotAvailable.Count > 0)
            return BadRequest("Can't make order, some of product out of stock");

        Guid orderId = Guid.NewGuid();

        var cartInfo = unitOfWork.CartRepository.GetCoutnAndTotalPrice(customerId);
        List<OrderProduct> productAndQuantityInCart = unitOfWork.CartRepository.GetProductAndQuantityInCart(customerId, orderId);

        unitOfWork.OrderRepository.MakeOrder(customerId, orderId, order, cartInfo, productAndQuantityInCart);

        unitOfWork.CartRepository.ClearCart(customerId);
        unitOfWork.CartRepository.SaveChanges();

        return Ok("create order successfully");
    }

    [HttpGet]
    public ActionResult<List<OrderReadDTO>> GetAllOrders()
    {
        string customerId = userManager.FindByNameAsync(User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value).Result.Id;
        return mapper.Map<List<OrderReadDTO>>(unitOfWork.OrderRepository.GetAllOrders(customerId));
    }

    [HttpGet("orderDetails/{orderId}")]
    public ActionResult<List<OrderProductReadDTO>>? GetOrderDetils(Guid orderId)
    {
        string customerId = userManager.FindByNameAsync(User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value).Result.Id;

        List<OrderProduct> orderDetails = unitOfWork.OrderRepository.GetOrderDetail(orderId, customerId);
        if (orderDetails is null)
            return null;

        return mapper.Map<List<OrderProductReadDTO>>(orderDetails);
    }


}
