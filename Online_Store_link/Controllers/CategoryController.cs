using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Online_Store_link.Data.UnitOfWork;
using Online_Store_link.Models.DBModels;
using Online_Store_link.Models.DTOs;

namespace Online_Store_link.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public CategoryController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    [HttpGet]
    public ActionResult<IEnumerable<CategoryReadDTO>> GetCategories()
    {
        return mapper.Map<List<CategoryReadDTO>>(unitOfWork.CategoryRepository.GetAll());
    }

    [HttpGet("{categoriesPerPage}/{pageNumber}")]
    public ActionResult<IEnumerable<CategoryReadDTO>> GetProducts(int categoriesPerPage, int pageNumber)
    {
        var result = unitOfWork.CategoryRepository.GetCategoriesPerPage(categoriesPerPage, pageNumber);
        if (result is null)
            BadRequest("you entered invalid parameters");

        return mapper.Map<List<CategoryReadDTO>>(result);
    }

    [HttpGet("DirectChild/{id}")]
    public ActionResult<IEnumerable<CategoryReadDTO>> GetDirectChildCategories(Guid id)
    {
        return mapper.Map<List<CategoryReadDTO>>(unitOfWork.CategoryRepository.GetDirectChildCategories(id));
    }
   
    [HttpGet("parents")]
    public ActionResult<IEnumerable<CategoryReadDTO>> GetParentCategories()
    {
        return mapper.Map<List<CategoryReadDTO>>(unitOfWork.CategoryRepository.GetParentCategories());
    }

    [HttpGet("{id}")]
    public ActionResult<CategoryReadDTO> GetCategoryByID(Guid id)
    {
        Category? category = unitOfWork.CategoryRepository.GetById(id);
        if (category is null)
            return NotFound("This Category not exist to get it");

        return mapper.Map<CategoryReadDTO>(category);
    }

    [HttpGet("count")]
    public ActionResult<int> GetCountOfCategories()
    {
        return unitOfWork.CategoryRepository.GetCount();
    }

    [HttpPut("{id}")]
    public ActionResult UpdateCategory(Guid id, CategoryWriteDTO updatedCategory)
    {
        if (updatedCategory.CategoryID != id)
            return BadRequest($"id in object doesn't match with id in Parameters");

        if (updatedCategory.ParentCategoryID is not null && !unitOfWork.CategoryRepository.IsFound((Guid)updatedCategory.ParentCategoryID))
            return BadRequest("ParentCategoryID not found, can't Add this category under it");

        var categoryToUpdate = unitOfWork.CategoryRepository.GetById(id);
        if (categoryToUpdate is null)
            return NotFound($"can't found Category with id {id}");

        mapper.Map(updatedCategory, categoryToUpdate);

        unitOfWork.CategoryRepository.Update(categoryToUpdate);
        bool somthingChange = unitOfWork.CategoryRepository.SaveChanges();

        string returnMessage = "No Category Updated, You didn't change any data";
        if (somthingChange) returnMessage = "Category Updated Successfully";

        return Ok(returnMessage);
    }

    [HttpGet("leaves")]
    public ActionResult<IEnumerable<CategoryChildReadDTO>> GetLeafCategories()
    {
        return mapper.Map<List<CategoryChildReadDTO>>(unitOfWork.CategoryRepository.GetLeafCategories());
    }

    [HttpGet("withProducts")]
    public ActionResult<IEnumerable<CategoryWithProductsReadDTO>> GetCategoriesWithProducts()
    {
        return mapper.Map<List<CategoryWithProductsReadDTO>>(unitOfWork.CategoryRepository?.GetCategoriesWithListOfProductst());
    }    
    
    [HttpGet("canBeParent")]
    public ActionResult<IEnumerable<CategoryReadDTO>> GetCategoriesCanBeParent()
    {
        return mapper.Map<List<CategoryReadDTO>>(unitOfWork.CategoryRepository?.GetCategoriesCanBeParent());
    }



    [HttpPost]
    public ActionResult PostCateogry(CategoryWriteDTO newCategory)
    {
        if (newCategory.ParentCategoryID is not null && !unitOfWork.CategoryRepository.IsFound((Guid)newCategory.ParentCategoryID))
            return BadRequest("ParentCategoryID not found, can't Add this category under it");

        newCategory.CategoryID = Guid.NewGuid();
        unitOfWork.CategoryRepository.Add(mapper.Map<Category>(newCategory));
        unitOfWork.CategoryRepository.SaveChanges();

        return CreatedAtAction(
            actionName: nameof(GetCategoryByID),
            routeValues: new { id = newCategory.CategoryID },
            value: "Added Category successfully"
       );
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteCategory(Guid id)
    {
        bool isDeleted = unitOfWork.CategoryRepository.Delete(id);
        unitOfWork.CategoryRepository.SaveChanges();

        if (isDeleted)
            return Ok("Category Deleted successfully");
        else
            return NotFound("can't found the Category to delete it");
    }
}
