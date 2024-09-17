using System.ComponentModel.DataAnnotations;

namespace CleanArchitecture.Domain.Common;
public abstract class BaseEntity<TKey> where TKey : IComparable
{
    [Key]
    public virtual TKey Id { get; set; } = default!;
}
