using System;

namespace application.Interfaces.Providers.Requests;

public interface IComponentRequest : IProviderRequest
{
    public Guid BlueprintId { get; set; }
}

public interface IFactoryRequest : IComponentRequest
{
    public Type Type { get; set; }
}

public interface IWarehouseRequest : IComponentRequest;

public class ComponentRequestBase : IComponentRequest
{
    public Guid BlueprintId { get; set; }
}
public class FactoryRequest: ComponentRequestBase, IFactoryRequest
{
    public Type Type { get; set; }
}

public class WarehouseRequest: ComponentRequestBase, IWarehouseRequest;