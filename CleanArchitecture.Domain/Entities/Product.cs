using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Interfaces;

namespace CleanArchitecture.Domain.Entities;
public class Product : FullAuditedEntity<long>
{
    public required string Name { get; set; }

    public string? Description { get; set; }

    public decimal Price { get; set; }

    public int Stock { get; set; }

    public required string ImageUrl { get; set; }

    public long BrandId { get; set; }

    public required string VendorId { get; set; }

    public Brand? Brand { get; set; }
    //public required IUser Vendor { get; set; }
}
