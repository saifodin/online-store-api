using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Online_Store_link.Data.UnitOfWork;
using Online_Store_link.Models.DTOs;

namespace Online_Store_link.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VendorController : ControllerBase
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public VendorController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    [HttpGet]
    public ActionResult<IEnumerable<VendorReadDTO>> GetVendors()
    {
        return mapper.Map<List<VendorReadDTO>>(unitOfWork.VendorRepository.GetAll());
    }
}
