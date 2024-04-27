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
using Type = domain.Interfaces.Type;

namespace application.Handlers;

public class FetchBlueprintsHandler(IProvider<IBlueprintRequest, IEnumerable<IBlueprint>> provider) : IRequestHandler<FetchBlueprints, IEnumerable<IBlueprint>>
{
    private static readonly IList<Type> Types = new List<Type>
    {
        Type.Chassis,
        Type.Engine,
        Type.OptionPack
    };

    public async Task<IEnumerable<IBlueprint>> Handle(FetchBlueprints request, CancellationToken cancellationToken)
    {
        IBlueprintRequest req = new BlueprintRequest
        {
            Codes = request.Codes
        };
        
        var blueprints = await provider.ProvideAsync(req);

        if (Types.All(type => blueprints.Any(bp => bp.Type.Equals(type))))
            throw new ValidationException("Blueprints should be different types");

        return blueprints;
    }
}