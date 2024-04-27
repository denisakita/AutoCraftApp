namespace domain.Interfaces;

public interface IBlueprint : IDomain
{
    public string Prefix { get ;}
    public decimal Price { get; set; }
    public string Code { get; set; }
    public Type Type { get; }
}

public enum Type
{
    Engine,
    Chassis,
    OptionPack
}