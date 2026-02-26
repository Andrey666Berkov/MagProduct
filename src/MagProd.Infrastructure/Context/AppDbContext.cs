using MagProduct.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MagProd.Infrastructure;

public class AppDbContext : DbContext
{
    public DbSet<Product> Products { get; set; } = null!;
    
   
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }

    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    // {
    //     optionsBuilder.UseNpgsql("Host=localhost;Port=5435;Database=productdb;Username=postgres;Password=postgres");
    // }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        modelBuilder.ApplyConfiguration(new ProductConfiguration());
    }
}

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("products");
        builder.Property(c=>c.Price).IsRequired();
        builder.Property(c => c.Title).IsRequired();
        builder.OwnsOne(c => c.Rating, c =>
        {
            c.Property(p=>p.Count).HasColumnName("Rating_Count");
            c.Property(p=>p.Rate).HasColumnName("Rating_Rate");
        });

    }
}
public class RatingConfiguration : IEntityTypeConfiguration<Rating>
{
    public void Configure(EntityTypeBuilder<Rating> builder)
    {
        builder.ToTable("Rating");
    }
}


public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    
    public AppDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

        optionsBuilder.UseNpgsql("Host=localhost;Port=5435;Database=productdb;Username=postgres;Password=postgres");

        return new AppDbContext(optionsBuilder.Options);
    }
}