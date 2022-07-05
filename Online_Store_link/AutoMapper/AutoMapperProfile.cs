using AutoMapper;
using Online_Store_link.Models.DBModels;
using Online_Store_link.Models.DTOs;

namespace Online_Store_link.AutoMapper;

public class AutoMapperProfile: Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Product, ProductReadDTO>();
        CreateMap<Product, PorductChildReadDTO>();
        CreateMap<ProductWriteDTO, Product>();

        CreateMap<Category, CategoryReadDTO>();
        CreateMap<Category, CategoryChildReadDTO>();
        CreateMap<Category, CategoryWithProductsReadDTO>();
        CreateMap<CategoryWriteDTO, Category> ();

        CreateMap<Vendor, VendorReadDTO>();

        CreateMap<Cart, CartReadDTO>();
    }
}
