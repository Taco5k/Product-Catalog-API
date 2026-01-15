using Carter;
using Product_Catalog_API.Helpers;
using Product_Catalog_API.Models.Products;
using Product_Catalog_API.Services;

namespace Product_Catalog_API.Endpoints;

public class ProductEndpoints : CarterModule
{
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
       
        app.MapPost("/products", async (
                ProductForm form,
                ProductService service) =>
            {
                var product = await service.Create(form);
                
                return Results.Created($"/products/{product.Id}", product);

            })
            .RequireAuthorization()
            .WithTags("Products")
            .AddEndpointFilter<ValidationFilter<ProductForm>>();

      
        app.MapGet("/products", async ( [AsParameters]ProductFilter filter,ProductService service) =>
            {
                var products = await service.GetAll(filter);
            return Results.Ok(products);
        })
        .WithTags("Products");

       
        app.MapGet("/products/{id}", async (Guid id, ProductService service) =>
        {
            var product = await service.GetById(id);
            return product == null ? Results.NotFound() : Results.Ok(product);
        }).WithTags("Products");

    
        app.MapPut("/products/{id}", async (Guid id,ProductUpdate form, ProductService service) =>
        {
            var updated = await service.Update(id,form);
            return updated == null ? Results.NotFound() : Results.Ok(updated);
        })
        .RequireAuthorization()
        .WithTags("Products")
        .AddEndpointFilter<ValidationFilter<ProductUpdate>>();

     
        app.MapDelete("/products/{id}", async (Guid id, ProductService service) =>
            {
                var deleted = await service.Delete(id);
                return deleted ? Results.NoContent() : Results.NotFound();
            })
            .RequireAuthorization()
            .WithTags("Products");

    }
}