namespace domain.Interfaces;

public interface IDomain
{
    // base id for every domain, enforced
    public Guid Id { get; set; }
    
    // base creation date
    public DateTime CreatedAt { get; set; }
    
    // soft-deletion
    public bool IsDeleted { get; set; }
}