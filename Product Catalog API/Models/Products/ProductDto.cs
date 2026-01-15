namespace Product_Catalog_API.Models.Products;

public class ProductDto : BaseDto
{
    public string Name { get; set; }
    public string Description { get; set; } 
    public string Category { get; set; } 
    public decimal Price { get; set; }
}