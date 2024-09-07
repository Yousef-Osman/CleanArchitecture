namespace CleanArchitecture.Domain.Common;
public abstract class AuditedEntity<TKey> : CreationAuditedEntity<TKey> where TKey : IComparable
{
    public virtual DateTime? LastModified { get; set; }
    public virtual string? LastModifiedBy { get; set; }
}
