namespace domain.Interfaces;

public interface IComponent : IDomain
{
    // component serial no.
    public string SerialNo { get; set; }
    
    public IOrder Order { get; set; }
    
    public Guid? OrderId { get; set; }
    
    // component code (the actual component blueprint)
    public string Code { get; set; }

    // if it is in warehouse, it should have a code
    public string Warehouse { get; set; }
    
    public Type Type { get; }
    
    // if it is manufactured, it has a date, every component is manufactured otherwise, they don't exist
    public DateTime Manufactured{ get; set; }
    
    public Guid BlueprintId { get; set; }

    public IBlueprint Blueprint { get; set; }

    public DateTime? UsedAt { get; set; }
}