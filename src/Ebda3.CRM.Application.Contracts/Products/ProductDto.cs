using System;
using Volo.Abp.Application.Dtos;

namespace Ebda3.CRM.Products;

//Inherit [AuditedEntity] to bring Auditing Fields that included in the Product Entity.
public class ProductDto : AuditedEntityDto<Guid>
{
    public Guid CategoryId { get; set; }
    public string CategoryName { get; set; }
    public string Name { get; set; }
    public float Price {  get; set; }
    public bool IsFreeCargo { get; set; }
    public DateTime ReleaseDate { get; set; }
    public ProductStockState StockState { get; set; }
}