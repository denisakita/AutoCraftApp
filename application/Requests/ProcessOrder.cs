using System.Collections.Generic;
using domain.Interfaces;
using MediatR;

namespace application.Requests;

public class ProcessOrder : IRequest<IOrder>
{
    public IEnumerable<IComponent> Components { get; set; }
}