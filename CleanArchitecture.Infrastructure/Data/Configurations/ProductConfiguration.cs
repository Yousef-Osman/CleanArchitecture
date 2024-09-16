using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infrastructure.Data.Configurations;
public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasOne<AppUser>()
            .WithMany(u => u.Products)
            .HasForeignKey(p => p.VendorId);
    }
}
