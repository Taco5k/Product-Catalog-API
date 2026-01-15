using Carter;
using Product_Catalog_API.Helpers;
using Product_Catalog_API.Models;
using Product_Catalog_API.Services;

namespace Product_Catalog_API.Endpoints;

public class AuthEndpoints : CarterModule
{
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
     
        app.MapPost("/auth/register", async (
            RegisterForm req,
            AuthService service) =>
        {
            try
            {
                var userDto = await service.Register(req);
                return Results.Ok(userDto);
            }
            catch (Exception ex)
            {
                return Results.BadRequest(new { message = ex.Message });
            }
        }).WithTags("Auth")
        .AddEndpointFilter<ValidationFilter<RegisterForm>>();
        
        
        app.MapPost("/auth/login", async (
            LoginForm req,
            AuthService service) =>
        {
            try
            {
                var userDto = await service.Login(req);
                return Results.Ok(userDto);
            }
            catch (Exception ex)
            {
                return Results.Unauthorized();
            }
        }).WithTags("Auth")
        .AddEndpointFilter<ValidationFilter<LoginForm>>();
    }
}