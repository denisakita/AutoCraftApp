namespace domain.Interfaces;

public interface IEngine : IBlueprint
{
    public decimal Capacity { get; set; }
    
    public byte CylinderNo { get; set; }
}