using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Ebda3.CRM.Products;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace Ebda3.CRM.Web.Pages.Products;

public class CreateEditProductViewModel
{
    [SelectItems("Categories")]
    [DisplayName("Category")]
    public Guid CategoryId { get; set; }

    [Required]
    [StringLength(ProductsConsts.MaxNameLength)]
    public string Name { get; set; }
    public float Price { get; set; }
    public bool IsFreeCargo { get; set; }
    [DataType(DataType.Date)]
    public DateTime ReleaseDate { get; set; }
    public ProductStockState StockState { get; set; }
}