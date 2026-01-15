namespace Product_Catalog_API.Models;

public class UserDto :BaseDto
{
    public string Email { get; set; }
    public string Token { get; set; }
}