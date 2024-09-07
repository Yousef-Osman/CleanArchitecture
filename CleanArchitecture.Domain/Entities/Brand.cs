using CleanArchitecture.Domain.Common;

namespace CleanArchitecture.Domain.Entities;
public class Brand: BaseEntity<long>
{
    public required string Name { get; set; }

    public string? Description { get; set; }

    public string? ImageUrl { get; set; }

    public IEnumerable<Product>? Products { get; set; }
}
