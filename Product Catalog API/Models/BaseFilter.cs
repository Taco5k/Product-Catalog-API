namespace Product_Catalog_API.Models;

public class BaseFilter
{
    public int? pageNumber { get; set; } = 1;
    public int? pageSize { get; set; } = 10;
}