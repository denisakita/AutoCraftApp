using System.Collections.Generic;
using domain.Interfaces;
using MediatR;

namespace application.Requests;

public class FetchBlueprints: IRequest<IEnumerable<IBlueprint>>
{
    public IEnumerable<string> Codes { get; set; }
}