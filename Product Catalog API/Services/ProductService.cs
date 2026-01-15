using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Product_Catalog_API.Data;
using Product_Catalog_API.Endpoints.Common;
using Product_Catalog_API.Entities;
using Product_Catalog_API.Helpers;
using Product_Catalog_API.Models.Products;

namespace Product_Catalog_API.Services;

public class ProductService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public ProductService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

 
    public async Task<ProductDto> Create(ProductForm form)
    {
        var product = _mapper.Map<Product>(form);
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
        return _mapper.Map<ProductDto>(product);
    }

    
    public async Task<PagedResult<ProductDto>> GetAll(ProductFilter filter)
    {
        var productsQuery = _context.Products
            .Where(p =>
                filter.search == null ||
                p.Name.ToLower().Contains(filter.search.ToLower()))

            .Where(p =>
                filter.category == null ||
                p.Category.ToLower().Contains(filter.category.ToLower()))

            .Where(p =>
                filter.minPrice == null ||
                p.Price >= filter.minPrice)

            .Where(p =>
                filter.maxPrice == null ||
                p.Price <= filter.maxPrice)

            .OrderByDescending(p => p.CreatedAt);

        return await PaginationHelper.PaginateAsync<Product, ProductDto>(
            productsQuery,
            _mapper,
            filter.pageNumber ?? 1,
            filter.pageSize ?? 10);



    }

 
    public async Task<ProductDto?> GetById(Guid id)
    {
        var product = await _context.Products.FindAsync(id);
        return product == null ? null : _mapper.Map<ProductDto>(product);
    }


    public async Task<ProductDto?> Update( Guid id,ProductUpdate form)
    {
        var product = await _context.Products.FindAsync(id);
        if (product == null) return null;

        _mapper.Map(form, product);
        await _context.SaveChangesAsync();
        return _mapper.Map<ProductDto>(product);
    }

    public async Task<bool> Delete(Guid id)
    {
        var product = await _context.Products.FindAsync(id);
        if (product == null) return false;

        _context.Products.Remove(product);
        await _context.SaveChangesAsync();
        return true;
    }
}