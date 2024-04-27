using domain.Interfaces;
using Type = domain.Interfaces.Type;

namespace domain.Domains;

public class Engine() : Blueprint(Type.Engine), IEngine
{
    public decimal Capacity { get; set; }
    public byte CylinderNo { get; set; }
}