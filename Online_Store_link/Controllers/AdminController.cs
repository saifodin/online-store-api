using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Online_Store_link.Models.DBModels;
using Online_Store_link.Models.DTOs;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Online_Store_link.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AdminController : ControllerBase
{
    private readonly IConfiguration configuration;
    private readonly UserManager<Admin> userManager;


    public AdminController(IConfiguration configuration, UserManager<Admin> userManager)
    {
        this.configuration = configuration;
        this.userManager = userManager;
    }


    [HttpPost]
    [Route("Register")]
    public async Task<ActionResult> RegisterAdmin()
    {
        #region CreateUser
        var newAdmin = new Admin
        {
            UserName = "admin@admin.com",
            Email = "admin@admin.com",
            FirstName = "Islam",
            LastName = "Adel"
        };

        var createUserResult = await userManager.CreateAsync(newAdmin, "admin@admin.com");
        if (!createUserResult.Succeeded)
        {
            return BadRequest(new { ErrorServer = "The email address is already in use by another account." });
        }
        #endregion

        #region CreateClaims
        var createClaimsResult = await userManager.AddClaimsAsync(newAdmin, new List<Claim>
        {
            new Claim (ClaimTypes.NameIdentifier, newAdmin.UserName),
            new Claim(ClaimTypes.Email, newAdmin.Email),
            new Claim("FirstName", newAdmin.FirstName),
            new Claim("LastName", newAdmin.LastName)
        });
        if (!createClaimsResult.Succeeded)
        {
            await userManager.DeleteAsync(newAdmin);
            return StatusCode(StatusCodes.Status500InternalServerError, new { ErrorServer = "Server Error Please Tray Later" });
        }
        #endregion

        return StatusCode(StatusCodes.Status201Created, new { SuccessServer = "Customer Created Successfully" });
    }

    [HttpPost]
    [Route("login")]
    public async Task<ActionResult<TokenDTO>> Login(LoginDTO loginDTO)
    {
        Admin user = await userManager.FindByNameAsync(loginDTO.UserName);

        #region user Unauthorized
        if (user is null)
            return Unauthorized(new { ErrorServer = "Sorry, we don't recognize that email or password. Please try again." });


        bool isLocked = await userManager.IsLockedOutAsync(user);
        if (isLocked)
            return Unauthorized(new { ErrorServer = "You're Locked. Please try again later" });


        bool isPasswordCorrect = await userManager.CheckPasswordAsync(user, loginDTO.Password);
        if (!isPasswordCorrect)
        {
            await userManager.AccessFailedAsync(user);
            return Unauthorized(new { ErrorServer = "Sorry, we don't recognize that email or password. Please try again." });
        }
        #endregion

        #region Create Token
        //HashingAlgorithm.Claims.HashingResult
        //key + Claims + HashingAlgorithm => HashingResult

        //Claims
        var userClaims = await userManager.GetClaimsAsync(user);

        //key
        string secretKeyString = configuration.GetValue<string>("SecretKey");
        byte[] secretKeyBytes = Encoding.ASCII.GetBytes(secretKeyString);

        //key + HashingAlgorithm - using package (microsoft.identitymodel.tokens)
        SymmetricSecurityKey secretKey = new(secretKeyBytes);
        SigningCredentials secretKeyAndAlgorithm = new(secretKey, SecurityAlgorithms.HmacSha256Signature);

        // HashingAlgorithm + Claims + HashingResult - using package (System.IdentityModel.Tokens.Jwt)
        JwtSecurityToken tokenObj = new(
            claims: userClaims,
            signingCredentials: secretKeyAndAlgorithm,
            notBefore: DateTime.Now,
            //expires: DateTime.Now.AddSeconds(15),
            expires: DateTime.Now.AddDays(1),
            issuer: "admin-issuer",
            audience: "admin-audience"
            );
        string token = new JwtSecurityTokenHandler().WriteToken(tokenObj);

        #endregion

        return new TokenDTO
        {
            Token = token,
            ExpiryDate = tokenObj.ValidTo,
            UserType = "Admin"
        };
    }

    [HttpGet]
    [Route("data")]
    [Authorize(AuthenticationSchemes = "adminAuth")]
    public ActionResult Get()
    {
        var customer = userManager.FindByNameAsync(User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value);
        return Ok(new { Customer = customer, CustomerId = customer.Result.Id });
    }

}
