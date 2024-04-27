using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using application.Interfaces;
using application.Interfaces.Providers.Requests;
using domain.Interfaces;
using infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace infrastructure.Providers;

public class BlueprintProvider(BContext context) : IProvider<IBlueprintRequest, IEnumerable<IBlueprint>>
{
    public async Task<IEnumerable<IBlueprint>> ProvideAsync(IBlueprintRequest req)
    {
        IEnumerable<IBlueprint> engines = await context.Set<EngineEntity>().Where(f => req.Codes.Contains(f.Code)).ToListAsync();
        IEnumerable<IBlueprint> chassis = await context.Set<ChassisEntity>().Where(f => req.Codes.Contains(f.Code)).ToListAsync();
        IEnumerable<IBlueprint> optionPacks = await context.Set<OptionPackEntity>().Where(f => req.Codes.Contains(f.Code)).ToListAsync();

        return engines.Concat(chassis).Concat(optionPacks);
    }
}