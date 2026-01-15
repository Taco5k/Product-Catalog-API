using Microsoft.EntityFrameworkCore;
using Product_Catalog_API.Entities;

namespace Product_Catalog_API.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }


    public DbSet<User> Users { get; set; }
    public DbSet<Product> Products { get; set; }
    


 
    public override int SaveChanges()
    {
        UpdateTimestamps();
        return base.SaveChanges();
    }

    
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        UpdateTimestamps();
        return base.SaveChangesAsync(cancellationToken);
    }
    
    private void UpdateTimestamps()
    {
        var entries = ChangeTracker
            .Entries<BaseEntity>()
            .Where(e => e.State == EntityState.Modified);

        foreach (var entry in entries)
        {
            entry.Entity.UpdatedAt = DateTime.UtcNow;
        }
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

      
        modelBuilder.Entity<Product>()
            .HasIndex(p => p.Name);
        modelBuilder.Entity<Product>()
            .HasIndex(p => p.Category); 
        modelBuilder.Entity<Product>()
            .HasIndex(p => p.Price);
        modelBuilder.Entity<Product>()
            .HasIndex(p => p.CreatedAt);
        
        
        modelBuilder.Entity<User>()
            .HasIndex(u => u.Email)
            .IsUnique();

         modelBuilder.Entity<Product>().HasData(
                new Product { Id = Guid.Parse("00000001-0000-0000-0000-000000000001"), Name = "Laptop Pro 15", Description = "High-end laptop for professionals", Category = "Electronics", Price = 1200m, CreatedAt = new DateTime(2026,1,15,0,0,0,DateTimeKind.Utc) },
                new Product { Id = Guid.Parse("00000002-0000-0000-0000-000000000002"), Name = "Wireless Mouse", Description = "Ergonomic wireless mouse", Category = "Electronics", Price = 25m, CreatedAt = new DateTime(2026,1,15,0,0,0,DateTimeKind.Utc) },
                new Product { Id = Guid.Parse("00000003-0000-0000-0000-000000000003"), Name = "Gaming Keyboard", Description = "Mechanical RGB keyboard", Category = "Electronics", Price = 75m, CreatedAt = new DateTime(2026,1,15,0,0,0,DateTimeKind.Utc) },
                new Product { Id = Guid.Parse("00000004-0000-0000-0000-000000000004"), Name = "Smartphone X", Description = "Latest smartphone with OLED display", Category = "Electronics", Price = 999m, CreatedAt = new DateTime(2026,1,15,0,0,0,DateTimeKind.Utc) },
                new Product { Id = Guid.Parse("00000005-0000-0000-0000-000000000005"), Name = "Bluetooth Headphones", Description = "Noise-cancelling over-ear headphones", Category = "Electronics", Price = 199m, CreatedAt = new DateTime(2026,1,15,0,0,0,DateTimeKind.Utc) },

                new Product { Id = Guid.Parse("00000006-0000-0000-0000-000000000006"), Name = "C# Programming", Description = "Comprehensive guide to C#", Category = "Books", Price = 40m, CreatedAt = new DateTime(2026,1,15,0,0,0,DateTimeKind.Utc) },
                new Product { Id = Guid.Parse("00000007-0000-0000-0000-000000000007"), Name = "ASP.NET Core in Action", Description = "Learn to build web APIs", Category = "Books", Price = 50m, CreatedAt = new DateTime(2026,1,15,0,0,0,DateTimeKind.Utc) },
                new Product { Id = Guid.Parse("00000008-0000-0000-0000-000000000008"), Name = "Mystery Novel", Description = "Engaging mystery story", Category = "Books", Price = 15m, CreatedAt = new DateTime(2026,1,15,0,0,0,DateTimeKind.Utc) },

                new Product { Id = Guid.Parse("00000009-0000-0000-0000-000000000009"), Name = "Men's T-Shirt", Description = "100% cotton casual T-shirt", Category = "Clothing", Price = 20m, CreatedAt = new DateTime(2026,1,15,0,0,0,DateTimeKind.Utc) },
                new Product { Id = Guid.Parse("0000000A-0000-0000-0000-00000000000A"), Name = "Women's Jeans", Description = "Slim fit denim jeans", Category = "Clothing", Price = 45m, CreatedAt = new DateTime(2026,1,15,0,0,0,DateTimeKind.Utc) },

                new Product { Id = Guid.Parse("0000000B-0000-0000-0000-00000000000B"), Name = "Coffee Table", Description = "Modern wooden coffee table", Category = "Home", Price = 120m, CreatedAt = new DateTime(2026,1,15,0,0,0,DateTimeKind.Utc) },
                new Product { Id = Guid.Parse("0000000C-0000-0000-0000-00000000000C"), Name = "LED Lamp", Description = "Desk lamp with adjustable brightness", Category = "Home", Price = 35m, CreatedAt = new DateTime(2026,1,15,0,0,0,DateTimeKind.Utc) },

                new Product { Id = Guid.Parse("0000000D-0000-0000-0000-00000000000D"), Name = "Football", Description = "Official size football", Category = "Sports", Price = 25m, CreatedAt = new DateTime(2026,1,15,0,0,0,DateTimeKind.Utc) },
                new Product { Id = Guid.Parse("0000000E-0000-0000-0000-00000000000E"), Name = "Tennis Racket", Description = "Professional tennis racket", Category = "Sports", Price = 80m, CreatedAt = new DateTime(2026,1,15,0,0,0,DateTimeKind.Utc) },

                new Product { Id = Guid.Parse("0000000F-0000-0000-0000-00000000000F"), Name = "Action Figure", Description = "Collectible action figure", Category = "Toys", Price = 25m, CreatedAt = new DateTime(2026,1,15,0,0,0,DateTimeKind.Utc) },
                new Product { Id = Guid.Parse("00000010-0000-0000-0000-000000000010"), Name = "Puzzle Game", Description = "500-piece jigsaw puzzle", Category = "Toys", Price = 15m, CreatedAt = new DateTime(2026,1,15,0,0,0,DateTimeKind.Utc) },
                new Product 
                { 
                    Id = Guid.Parse("00000011-0000-0000-0000-000000000011"), 
                    Name = "Smart LED TV 50\"", 
                    Description = "50-inch 4K Ultra HD Smart TV", 
                    Category = "Electronics", 
                    Price = 450m, 
                    CreatedAt = new DateTime(2026,1,15,0,0,0,DateTimeKind.Utc) 
                },
                new Product 
                { 
                    Id = Guid.Parse("00000012-0000-0000-0000-000000000012"), 
                    Name = "Electric Kettle", 
                    Description = "Fast boiling stainless steel kettle", 
                    Category = "Home", 
                    Price = 30m, 
                    CreatedAt = new DateTime(2026,1,15,0,0,0,DateTimeKind.Utc) 
                },
                new Product 
                { 
                    Id = Guid.Parse("00000013-0000-0000-0000-000000000013"), 
                    Name = "Running Shoes", 
                    Description = "Lightweight breathable running shoes", 
                    Category = "Clothing", 
                    Price = 60m, 
                    CreatedAt = new DateTime(2026,1,15,0,0,0,DateTimeKind.Utc) 
                },
                new Product 
                { 
                    Id = Guid.Parse("00000014-0000-0000-0000-000000000014"), 
                    Name = "Cookware Set 10pcs", 
                    Description = "Non-stick pots and pans set", 
                    Category = "Home", 
                    Price = 120m, 
                    CreatedAt = new DateTime(2026,1,15,0,0,0,DateTimeKind.Utc) 
                },
                new Product 
                { 
                    Id = Guid.Parse("00000015-0000-0000-0000-000000000015"), 
                    Name = "Board Game Classic", 
                    Description = "Fun family board game", 
                    Category = "Toys", 
                    Price = 35m, 
                    CreatedAt = new DateTime(2026,1,15,0,0,0,DateTimeKind.Utc) 
                }
        );
    }


  
}

