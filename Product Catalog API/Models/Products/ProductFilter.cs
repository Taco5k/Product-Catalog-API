namespace Product_Catalog_API.Models.Products;

public class ProductFilter : BaseFilter
{
    public string? search { get; set; }
    public string? category { get; set; }
    public decimal? minPrice { get; set; }
    public decimal? maxPrice { get; set; }

   
}
