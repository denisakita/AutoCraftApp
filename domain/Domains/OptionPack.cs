using domain.Interfaces;
using Type = domain.Interfaces.Type;

namespace domain.Domains;

public class OptionPack() : Blueprint(Type.OptionPack), IOptionPack
{
    public string Name { get; set; } = string.Empty;
}