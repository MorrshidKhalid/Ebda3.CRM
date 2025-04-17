using System;
using System.ComponentModel.DataAnnotations;

namespace Ebda3.CRM.Products;

public class CreateUpdateProductDto
{
    [Required]
    public Guid CategoryId { get; set; }
    
    [Required]
    [StringLength(ProductsConsts.MaxNameLength)]
    public required string Name { get; set; }
    
    [Required]
    [Range(1, float.MaxValue)]
    public float Price { get; set; }
    
    public bool IsFreeCargo { get; set; }
    
    [Required]
    public DateTime ReleaseDate { get; set; }
    
    [Required]
    [Range(0, 255)]
    public ProductStockState StockState { get; set; }
}