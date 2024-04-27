using domain.Common;
using domain.Interfaces;

namespace domain.Domains;

public class Order : BaseDomain, IOrder
{
    public long OrderNo { get; set; }
    
    public string SerialNo { get; set; } = string.Empty;
    
    public IEnumerable<IComponent> Components { get; }
    
    public OrderStatus Status { get; set; }
}