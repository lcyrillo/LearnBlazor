using Microsoft.EntityFrameworkCore;
using ShopOnline.API.Data;
using ShopOnline.API.Entities;
using ShopOnline.API.Repositories.Contracts;

namespace ShopOnline.API.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly ShopOnlineDbContext _shopOnlineDbContext;

    public ProductRepository(ShopOnlineDbContext context)
    {
        _shopOnlineDbContext = context;
    }

    public async Task<IEnumerable<ProductCategory>> GetCategories()
    {
        var categories = await _shopOnlineDbContext.ProductCategories.ToListAsync();

        return categories;
    }

    public async Task<ProductCategory> GetCategory(int id)
    {

        var category = await _shopOnlineDbContext.ProductCategories.Where(predicate => predicate.Id == id).SingleAsync();

        return category;
    }

    public async Task<Product> GetItem(int id)
    {
        var product = await _shopOnlineDbContext.Products.Where(predicate => predicate.Id == id).SingleAsync();

        return product;
    }

    public async Task<IEnumerable<Product>> GetItems()
    {
        var products = await _shopOnlineDbContext.Products.ToListAsync();

        return products;
    }
}

