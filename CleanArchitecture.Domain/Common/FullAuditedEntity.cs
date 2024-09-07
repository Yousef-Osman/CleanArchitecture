namespace CleanArchitecture.Domain.Common;
public abstract class FullAuditedEntity<TKey>: AuditedEntity<TKey> where TKey : IComparable
{
    public virtual bool IsDeleted { get; set; }
    public virtual DateTime? Deleted { get; set; }
    public virtual string? DeletedBy { get; set; }
}
