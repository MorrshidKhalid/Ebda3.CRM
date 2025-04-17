using AutoMapper;
using Ebda3.CRM.Categories;
using Ebda3.CRM.Products;

namespace Ebda3.CRM;

public class CRMApplicationAutoMapperProfile : Profile
{
    public CRMApplicationAutoMapperProfile()
    {
        CreateMap<CreateUpdateProductDto, Product>();
        CreateMap<Product, ProductDto>();
        CreateMap<Category, CategoryLookupDto>();
        CreateMap<CreateUpdateCategoryDto, Category>();
        CreateMap<Category, CategoryDto>();
    }
}
