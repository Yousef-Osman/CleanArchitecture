namespace CleanArchitecture.Domain.Common;
public abstract class CreationAuditedEntity<TKey> : BaseEntity<TKey> where TKey : IComparable
{
    public virtual DateTime Created { get; set; }
    public virtual string? CreatedBy{ get; set; }

    protected CreationAuditedEntity()
    {
        Created = DateTime.UtcNow;
    }
}
