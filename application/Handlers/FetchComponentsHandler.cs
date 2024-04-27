using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using application.Interfaces;
using application.Interfaces.Providers.Requests;
using application.Requests;
using domain.Interfaces;
using MediatR;

namespace application.Handlers;

public class FetchComponentsHandler(
    IProvider<IWarehouseRequest, IComponent> warehouse, 
    IProvider<IFactoryRequest, IComponent> factory): IRequestHandler<FetchComponents, IEnumerable<IComponent>>
{
    public async Task<IEnumerable<IComponent>> Handle(FetchComponents request, CancellationToken cancellationToken)
    {
        return await Task.WhenAll(request.BlueprintIds.Select(FetchComponent).ToList());
    }

    private async Task<IComponent> FetchComponent(Guid blueprintId)
    {
        var warehouseComponent = await warehouse.ProvideAsync(new WarehouseRequest
        {
            BlueprintId = blueprintId
        });

        if (warehouseComponent != null) return warehouseComponent;

        var factoryComponent = await factory.ProvideAsync(new FactoryRequest
        {
            BlueprintId = blueprintId,
            
        });

        if (factoryComponent == null)
        {
            throw new ValidationException("Component couldn't be scheduled for manufacturing");
        }

        return factoryComponent;
    }
}