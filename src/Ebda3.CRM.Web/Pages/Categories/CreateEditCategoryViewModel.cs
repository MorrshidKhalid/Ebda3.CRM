using System.ComponentModel.DataAnnotations;
using Ebda3.CRM.Categories;

namespace Ebda3.CRM.Web.Pages.Categories;

public class CreateEditCategoryViewModel
{
    [Required]
    [StringLength(CategoryConsts.MaxNameLength)]
    public string Name { get; set; }
}