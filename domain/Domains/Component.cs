using domain.Common;
using domain.Interfaces;
using Type = domain.Interfaces.Type;

namespace domain.Domains;

public class Component : BaseDomain, IComponent
{
    // component serial no.
    public string SerialNo { get; set; } = string.Empty;
    
    public Type Type { get; set; }

    // order if any
    public IOrder Order { get; set; }
    
    public Guid? OrderId { get; set; }

    // component code (the actual component blueprint)
    public string Code { get; set; } = string.Empty;
    
    // if it is in warehouse, it should have a code
    public string Warehouse { get; set; } = string.Empty;
    
    // if it is manufactured, it has a date, every component is manufactured otherwise, they don't exist
    public DateTime Manufactured { get; set; }
    
    public Guid BlueprintId { get; set; }

    public IBlueprint Blueprint { get; set; }

    public DateTime? UsedAt { get; set; }
}