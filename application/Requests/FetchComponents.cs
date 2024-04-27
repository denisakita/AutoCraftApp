using System;
using System.Collections.Generic;
using domain.Interfaces;
using MediatR;

namespace application.Requests;

public class FetchComponents : IRequest<IEnumerable<IComponent>>
{
    public IEnumerable<Guid> BlueprintIds { get; set; }
}