namespace domain.Interfaces;

public interface IOrder : IDomain
{
    public IEnumerable<IComponent> Components { get; }
    public long OrderNo { get; set; }
    public string SerialNo { get; set; }
    public OrderStatus Status { get; set; }
}

public enum OrderStatus
{
    Pending,
    InProgress,
    Completed,
    Cancelled
}