using domain.Interfaces;

namespace domain.Common;

public abstract class BaseDomain : IDomain
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool IsDeleted { get; set; }
}