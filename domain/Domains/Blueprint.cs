using domain.Common;
using domain.Interfaces;
using Type = domain.Interfaces.Type;

namespace domain.Domains;

public abstract class Blueprint(Type type) : BaseDomain, IBlueprint
{
    public string Prefix { get ; } = type switch
    {
        Type.Engine => "ENG",
        Type.Chassis => "CHASS",
        Type.OptionPack => "OPT",
        _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
    };

    public decimal Price { get; set; }
    public string Code { get; set; } = string.Empty;
    public Type Type { get; } = type;
}