using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Online_Store_link.Data.UnitOfWork;
using Online_Store_link.Models.DBModels;
using Online_Store_link.Models.DTOs;
using System.Net;
using System.Net.Http.Headers;

namespace Online_Store_link.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;
    private readonly IWebHostEnvironment hostingEnvironment;

    public ProductController(IWebHostEnvironment hostingEnvironment,IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
        this.hostingEnvironment = hostingEnvironment;
    }

    [HttpGet]
    [Authorize(AuthenticationSchemes = "myAuth")]
    public ActionResult<IEnumerable<ProductReadDTO>> GetProducts()
    {
        return mapper.Map<List<ProductReadDTO>>(unitOfWork.ProductRepository.GetProductsFullInfromation());
    }

    [Authorize(AuthenticationSchemes = "adminAuth")]
    [HttpGet("{prductsPerPage}/{pageNumber}")]
    public ActionResult<IEnumerable<ProductReadDTO>> GetProducts(int prductsPerPage,int pageNumber)
    {
        var result = unitOfWork.ProductRepository.GetProductsPerPage(prductsPerPage, pageNumber);
        if (result is null)
            BadRequest("you entered invalid parameters");

        return mapper.Map<List<ProductReadDTO>>(result);
    }

    [Authorize(AuthenticationSchemes = "adminAuth")]
    [HttpGet("count")]
    public ActionResult<int> GetCountOfProducts()
    {
        return unitOfWork.ProductRepository.GetCount();
    }

    [Authorize(AuthenticationSchemes = "adminAuth")]
    [Authorize(AuthenticationSchemes = "myAuth")]
    [HttpGet("{id}")]
    public ActionResult<ProductReadDTO> GetProductById(Guid id)
    {
        Product? product = unitOfWork.ProductRepository.GetProductById(id);
        if (product is null)
            return NotFound("This Product not exist to get it");

        return mapper.Map<ProductReadDTO>(product);
    }

    [HttpPut("{id}")]
    [Authorize(AuthenticationSchemes = "adminAuth")]
    public ActionResult PutProduct(Guid id, ProductWriteDTO updatedProduct)
    {
        if (updatedProduct.ProductID != id)
            return BadRequest("id in object doesn't match with id in Parameters");

        var productToUpdate = unitOfWork.ProductRepository.GetById(id);
        if (productToUpdate is null)
            return NotFound($"can't found product with id {id}");

        if (!unitOfWork.VendorRepository.IsFound((Guid)updatedProduct.VendorID))
            return BadRequest("can't found vendorId");

        ActionResult? actionAftercheckCategory = CheckCategory(updatedProduct.CategoryID);
        if (actionAftercheckCategory is not null)
            return actionAftercheckCategory;

        mapper.Map(updatedProduct, productToUpdate); //change doctorToUpdate props

        unitOfWork.ProductRepository.Update(productToUpdate); //empty function, we can comment this line
        bool somthingChange = unitOfWork.ProductRepository.SaveChanges();

        string returnMessage = "No Product Updated, You didn't change any data";
        if (somthingChange) returnMessage = "Product Updated Successfully";

        return Ok(returnMessage);
    }

    [HttpPost]
    [Authorize(AuthenticationSchemes = "adminAuth")]
    public ActionResult PostProduct(ProductWriteDTO newProduct)
    {
        if (!unitOfWork.VendorRepository.IsFound((Guid)newProduct.VendorID))
            return BadRequest("can't found vendorId");

        ActionResult? actionAftercheckCategory = CheckCategory(newProduct.CategoryID);
        if (actionAftercheckCategory is not null)
            return actionAftercheckCategory;

        newProduct.ProductID = Guid.NewGuid();
        unitOfWork.ProductRepository.Add(mapper.Map<Product>(newProduct));
        unitOfWork.ProductRepository.SaveChanges();

        return CreatedAtAction(
            actionName: nameof(GetProductById),
            routeValues: new { id = newProduct.ProductID },
            value: "Added Product successfully"
       );
    }

    [HttpPost("image")]
    [Authorize(AuthenticationSchemes = "adminAuth")]
    public ActionResult UploadImage()
    {
        try
        {
            var file = Request.Form.Files[0];
            if(file.Length > 1_000_000)
                return  BadRequest("Size must be not exceed 1M");

            string fileExtwnsion = Path.GetExtension(file.FileName).ToLower();
            if (fileExtwnsion != ".gif" && fileExtwnsion != ".jpg" && fileExtwnsion != ".bmp" && fileExtwnsion != ".png")
                return BadRequest("Allow only images with extensions .gif, .jpg, .bmp, .png ");

            var folderName = Path.Combine("Resources", "Images");
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
            if (file.Length > 0)
            {
                var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                var fullPath = Path.Combine(pathToSave, fileName);
                var dbPath = Path.Combine(folderName, fileName);
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                return Ok(new { dbPath });
            }
            else
            {
                return BadRequest();
            }
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex}");
        }
    }

    [HttpDelete("image/{fileName}")]
    [Authorize(AuthenticationSchemes = "adminAuth")]
    public ActionResult DeleteImage(string fileName)
    {
        var folderName = Path.Combine("Resources", "Images");
        var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
        string _imageToBeDeleted = Path.Combine(pathToSave, fileName);
        if ((System.IO.File.Exists(_imageToBeDeleted)))
        {
            System.IO.File.Delete(_imageToBeDeleted);
            return Ok("Image deleted successfully");
        }
        return NotFound("Image not exist to delete it");
    }

    [HttpDelete("{id}")]
    [Authorize(AuthenticationSchemes = "adminAuth")]
    public ActionResult DeleteProduct(Guid id)
    {
        bool isDeleted = unitOfWork.ProductRepository.Delete(id);
        unitOfWork.ProductRepository.SaveChanges();

        if (isDeleted)
            return Ok("Product Deleted successfully");
        else
            return NotFound("can't found the product to delete it");
    }

    [HttpGet("category/{id}")]
    [Authorize(AuthenticationSchemes = "adminAuth")]
    [Authorize(AuthenticationSchemes = "myAuth")]
    public ActionResult<IEnumerable<ProductReadDTO>> GetProductsByCategoryId(Guid id)
    {
        if (!unitOfWork.CategoryRepository.IsLeaf(id))
            return NotFound("This Category not exist or not a leaf Category");
        List<Product>? productsInThisCategory = unitOfWork.ProductRepository.GetProductsByCategoryID(id);

        return mapper.Map<List<ProductReadDTO>>(productsInThisCategory);
    }

    [HttpGet("getByName/{ownerName}")]
    public ActionResult<IEnumerable<ProductReadDTO>> SearchByName(string ownerName)
    {
        if (string.IsNullOrWhiteSpace(ownerName))
            return Ok();
        return mapper.Map<List<ProductReadDTO>>(unitOfWork.ProductRepository.GetProductsByName(ownerName));
    }

    private ActionResult? CheckCategory(Guid? id)
    {
        if (id is not null && !unitOfWork.CategoryRepository.IsFound((Guid)id))
            return BadRequest("Can't found this category, to put this product under it");

        if (id is not null && !unitOfWork.CategoryRepository.IsLeaf((Guid)id))
            return BadRequest("Can't put this product under not leaf category");

        return null;
    }
}
