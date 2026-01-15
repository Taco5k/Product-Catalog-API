using AutoMapper;
using Product_Catalog_API.Entities;
using Product_Catalog_API.Models;
using Product_Catalog_API.Models.Products;

namespace Product_Catalog_API.Helpers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {     
        CreateMap<User, UserDto>();
        CreateMap<User, TokenDto>();
        CreateMap<Product, ProductDto>();
        CreateMap<ProductForm, Product>();
        CreateMap<ProductUpdate, Product>() 
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        
      
    }
}