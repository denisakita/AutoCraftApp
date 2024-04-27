using domain.Interfaces;
using Type = domain.Interfaces.Type;

namespace domain.Domains;

public class Chassis() : Blueprint(Type.Chassis), IChassis
{
    public string Material { get; set; } = string.Empty;
    public decimal Weight { get; set; }
    public decimal Length { get; set; }
    public decimal Width { get; set; }
    public decimal Height { get; set; }
}