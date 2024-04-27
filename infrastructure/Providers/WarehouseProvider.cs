using System;
using System.Linq;
using System.Threading.Tasks;
using application.Interfaces;
using application.Interfaces.Providers.Requests;
using domain.Interfaces;
using infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Type = domain.Interfaces.Type;

namespace infrastructure.Providers;

public class WarehouseProvider(BContext context): IProvider<IWarehouseRequest, IComponent>
{
    public async Task<IComponent> ProvideAsync(IWarehouseRequest req)
    {
        var component = await context.Set<ComponentEntity>()
            .Where(f => f.OrderEntityId == null)
            .Where(f =>
                f.OptionPackId.Equals(req.BlueprintId) ||
                f.ChassisId.Equals(req.BlueprintId) ||
                f.EngineId.Equals(req.BlueprintId))
            .FirstOrDefaultAsync();
        
        component.BlueprintId = req.BlueprintId;

        IBlueprint blueprint = component.Type switch
        {
            Type.Chassis => await context.Set<ChassisEntity>().FirstOrDefaultAsync(f => f.Id.Equals(req.BlueprintId)),
            Type.Engine => await context.Set<EngineEntity>().FirstOrDefaultAsync(f => f.Id.Equals(req.BlueprintId)),
            Type.OptionPack => await context.Set<OptionPackEntity>()
                .FirstOrDefaultAsync(f => f.Id.Equals(req.BlueprintId)),
            _ => throw new ArgumentOutOfRangeException(nameof(component.Type), component.Type, null)
        };

        component.Blueprint = blueprint;

        return component;
    }
}