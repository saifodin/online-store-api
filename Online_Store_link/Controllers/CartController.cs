using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Online_Store_link.Data.UnitOfWork;
using Online_Store_link.Models.DBModels;
using Online_Store_link.Models.DTOs;
using System.Security.Claims;

namespace Online_Store_link.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class CartController : ControllerBase
{
    private readonly IUnitOfWork unitOfWork;
    private readonly UserManager<Customer> userManager;
    private readonly IMapper mapper;

    public CartController(
        IUnitOfWork unitOfWork,
        UserManager<Customer> userManager,
        IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.userManager = userManager;
        this.mapper = mapper;
    }

    [HttpGet]
    public ActionResult<List<CartReadDTO>> GetAllCart()
    {
        string customerId = userManager.FindByNameAsync(User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value).Result.Id;
        return mapper.Map<List<CartReadDTO>>(unitOfWork.CartRepository.GetAllInCart(customerId));
    }

    [HttpPost("addOne/{productId}")]
    public ActionResult AddOneToCart(Guid productId)
    {
        string customerId = userManager.FindByNameAsync(User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value).Result.Id;

        if (unitOfWork.ProductRepository.GetById(productId) is null)
            return BadRequest("can't found this product to add to cart");

        unitOfWork.CartRepository.AddOneToCart(customerId, productId);

        bool isChange = unitOfWork.CartRepository.SaveChanges();
        if(!isChange)
            return BadRequest("no changes, please try again");

        return Ok("add one to cart successfully");
    }
    
    [HttpDelete("removeOne/{productId}")]
    public ActionResult RemoveOneFromCart(Guid productId)
    {
        string customerId = userManager.FindByNameAsync(User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value).Result.Id;

        if (unitOfWork.ProductRepository.GetById(productId) is null)
            return BadRequest("can't found this product to delete from cart");

        var isRemoveOne = unitOfWork.CartRepository.RmoveOneFromCart(customerId, productId);
        if (!isRemoveOne)
            return BadRequest("can't remove one, this product not exist you cart");

        bool isChange = unitOfWork.CartRepository.SaveChanges();
        if(!isChange)
            return BadRequest("no changes, please try again");

        return Ok("remove one from cart successfully");
    }

    [HttpPost("add/{productId}/{quantity}")]
    public ActionResult AddToCartWithQuantity(Guid productId, int quantity)
    {
        string customerId = userManager.FindByNameAsync(User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value).Result.Id;

        if(quantity < 1)
            return BadRequest("Quantity must be greater than 0");

        if (unitOfWork.ProductRepository.GetById(productId) is null)
            return BadRequest("can't found this product to add to cart");

        unitOfWork.CartRepository.AddToCartWithQuantity(customerId, productId, quantity);

        bool isChange = unitOfWork.CartRepository.SaveChanges();
        if (!isChange)
            return BadRequest("no changes, please try again");

        return Ok("update cart with specific quantity successfully");
    }

    [HttpDelete("deleteProduct/{productId}")]
    public ActionResult RemoveProductFromCart(Guid productId)
    {
        string customerId = userManager.FindByNameAsync(User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value).Result.Id;

        if (unitOfWork.ProductRepository.GetById(productId) is null)
            return BadRequest("can't found this product to delete from cart");

        var isRemoveOne = unitOfWork.CartRepository.RemoveFromCart(customerId, productId);
        if (!isRemoveOne)
            return BadRequest("can't remove product from cart, this product not exist you cart");

        bool isChange = unitOfWork.CartRepository.SaveChanges();
        if (!isChange)
            return BadRequest("no changes, please try again");

        return Ok("remove product from cart successfully");
    }

    [HttpDelete("clearCart")]
    public ActionResult ClearCart()
    {
        string customerId = userManager.FindByNameAsync(User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value).Result.Id;

        bool isHaveProductsInCart = unitOfWork.CartRepository.ClearCart(customerId);
        if (!isHaveProductsInCart)
            return BadRequest("Your Cart is already clear");

        bool isChange = unitOfWork.CartRepository.SaveChanges();
        if (!isChange)
            return BadRequest("no changes, please try again");

        return Ok("remove product from cart successfully");

        return Ok("Cart clear successfully");
    }

    [HttpGet("totalInfo")]
    public ActionResult<CartInfoReadDTO> GetCoutnAndTotalPrice()
    {
        string customerId = userManager.FindByNameAsync(User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value).Result.Id;

        return unitOfWork.CartRepository.GetCoutnAndTotalPrice(customerId);
    }





}
