using Carter;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Product_Catalog_API.Data;
using Product_Catalog_API.Extensions;
using Product_Catalog_API.Helpers;
using Product_Catalog_API.Services;
using Product_Catalog_API.Validators;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddCarter();
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});



builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<TokenService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthorization();
builder.Services.AddIdentityServices(builder.Configuration);


builder.Services.AddValidatorsFromAssemblyContaining<Program>();

var app = builder.Build();



app.UseAuthentication();
app.UseAuthorization();

app.MapCarter();
app.UseHttpsRedirection();



app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Product Catalog API v1");
    c.RoutePrefix = string.Empty;
});

app.Run();

