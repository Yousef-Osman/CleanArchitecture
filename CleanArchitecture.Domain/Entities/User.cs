using CleanArchitecture.Domain.Common;

namespace CleanArchitecture.Domain.Entities;
public class User: BaseEntity<long>
{
    public string IdentityUserId { get; set; } = default!;

    public List<Product>? Products { get; set; }
}
