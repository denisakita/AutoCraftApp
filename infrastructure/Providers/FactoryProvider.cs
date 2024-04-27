using System;
using System.Linq;
using System.Threading.Tasks;
using application.Interfaces;
using application.Interfaces.Providers.Requests;
using domain.Domains;
using domain.Interfaces;
using infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace infrastructure.Providers;

public class FactoryProvider(BContext context) : IProvider<IFactoryRequest, IComponent>
{
    public async Task<IComponent> ProvideAsync(IFactoryRequest req)
    {
        IBlueprint engine = await context.Set<EngineEntity>().FirstOrDefaultAsync(f => f.Id.Equals(req.BlueprintId));
        IBlueprint optionPack = await context.Set<OptionPackEntity>().FirstOrDefaultAsync(f => f.Id.Equals(req.BlueprintId));
        IBlueprint chassis = await context.Set<ChassisEntity>().FirstOrDefaultAsync(f => f.Id.Equals(req.BlueprintId));

        var blueprint = engine ?? optionPack ?? chassis;

        var component = new ComponentEntity
        {
            BlueprintId = blueprint.Id,
            Blueprint = blueprint,
            Code = blueprint.Code,
            Id = Guid.NewGuid(),
            CreatedAt = DateTime.UtcNow,
            Type = blueprint.Type,
            IsDeleted = false,
            Manufactured = DateTime.UtcNow,
            SerialNo = $"{blueprint.Prefix}-{Guid.NewGuid().ToString()}",
            EngineId = engine?.Id,
            ChassisId = chassis?.Id,
            OptionPackId = optionPack?.Id
        };

        await context.Set<ComponentEntity>().AddAsync(component);
        await context.SaveChangesAsync();

        return component;
    }
}