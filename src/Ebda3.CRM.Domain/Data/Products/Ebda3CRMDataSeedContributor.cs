using System;
using System.Threading.Tasks;
using Ebda3.CRM.Categories;
using Ebda3.CRM.Products;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace Ebda3.CRM.Data.Products;

public class Ebda3CRMDataSeedContributor :
    IDataSeedContributor, ITransientDependency
{
    private readonly IRepository<Product, Guid> _productRepository;
    private readonly IRepository<Category, Guid> _categoryRepository;

    public Ebda3CRMDataSeedContributor(IRepository<Product, Guid> productRepository, IRepository<Category, Guid> categoryRepository)
    {
        _productRepository = productRepository;
        _categoryRepository = categoryRepository;
    }


    public async Task SeedAsync(DataSeedContext context)
    {
        if (await _categoryRepository.CountAsync() > 0)
        {
            return;
        }
        
        var electronics = new Category { Name = "Electronics" };
        var laptop = new Category { Name = "laptop" };
            
            
        await _categoryRepository.InsertManyAsync([electronics, laptop]);
        
        
        var product1 = new Product
        {
            Name = "UPS",
            Category = electronics, 
            Price = 19.5f,
            ReleaseDate = new DateTime(2019, 05, 24),
            StockState = ProductStockState.InStock
        };
        
        var product2 = new Product
        {
            Name = "UPS-S",
            Category = electronics, 
            Price = 50,
            ReleaseDate = new DateTime(2025,01, 29),
            StockState = ProductStockState.InStock
        };
        
        var product3 = new Product
        {
            Name = "Razer 18",
            Category = laptop, 
            Price = 2550,
            ReleaseDate = new DateTime(2024,09, 05),
            StockState = ProductStockState.InStock
        };
        
        await _productRepository.InsertManyAsync([product1, product2, product3]);
    }
}