
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Product_Catalog_API.Data;
using Product_Catalog_API.Entities;
using Product_Catalog_API.Models;

namespace Product_Catalog_API.Services;

public class AuthService
{
    private readonly DataContext _context;
    private readonly TokenService _tokenService;
    private readonly IMapper _mapper;
 

    public AuthService(DataContext context, IConfiguration config, TokenService tokenService, IMapper mapper)
    {
        _context = context;
        _tokenService = tokenService;
        _mapper = mapper;
       
    }

    public async Task<Object> Register(RegisterForm registerForm)
    {
        if (await _context.Users.AnyAsync(x => x.Email == registerForm.Email))
            throw new Exception("Email already exists");

        var user = new User
        {
            Email = registerForm.Email,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(registerForm.Password)
        };

        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        
        return new
        {
            Message = "User registered successfully"
        };
    }
    public async Task<UserDto> Login(LoginForm loginForm)
    {
        var user = await _context.Users.SingleOrDefaultAsync(x => x.Email == loginForm.Email);
        if (user == null || !BCrypt.Net.BCrypt.Verify(loginForm.Password, user.PasswordHash))
            throw new Exception("Invalid email or password");

        var userDto = _mapper.Map<UserDto>(user);
        var TokenDto = _mapper.Map<TokenDto>(user);
        userDto.Token = _tokenService.CreateToken(TokenDto);
        return userDto;
    }
}
