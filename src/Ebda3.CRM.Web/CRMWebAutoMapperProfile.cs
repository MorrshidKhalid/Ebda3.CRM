using AutoMapper;
using Ebda3.CRM.Categories;
using Ebda3.CRM.Leads;
using Ebda3.CRM.Products;
using Ebda3.CRM.Web.Pages.Categories;
using Ebda3.CRM.Web.Pages.Contacts;
using Ebda3.CRM.Web.Pages.Products;

namespace Ebda3.CRM.Web;

public class CRMWebAutoMapperProfile : Profile
{
    public CRMWebAutoMapperProfile()
    {
        CreateMap<CreateEditProductViewModel, CreateUpdateProductDto>();
        CreateMap<CreateEditCategoryViewModel, CreateUpdateCategoryDto>();
        CreateMap<ProductDto, CreateEditProductViewModel>();
        CreateMap<CategoryDto, CreateEditCategoryViewModel>();
        CreateMap<CreateEditCategoryViewModel, Category>();
        CreateMap<CreateEditContactsViewModel, CreateUpdateLeadDto>();
    }
}
