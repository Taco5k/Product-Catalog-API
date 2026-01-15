namespace Product_Catalog_API.Entities;

public class User : BaseEntity
{
    
    public string Email { get; set; }
    public string PasswordHash { get; set; }
}