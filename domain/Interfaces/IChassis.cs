namespace domain.Interfaces;

public interface IChassis : IBlueprint
{
    public string Material { get; set; }
    public decimal Weight { get; set; }
    public decimal Length { get; set; }
    public decimal Width { get; set; }
    public decimal Height { get; set; }
}