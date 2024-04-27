using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using application.Requests;
using domain.Interfaces;
using MediatR;

namespace application.Handlers;

public class PlaceOrderHandler(IMediator mediator) : IRequestHandler<PlaceOrder, IOrder>
{
    public async Task<IOrder> Handle(PlaceOrder request, CancellationToken cancellationToken)
    {
        var blueprintIds = (await mediator.Send(new FetchBlueprints
            {
                Codes = new[] { request.ChassisCode, request.EngineCode, request.OptionPackCode }
            }, cancellationToken))
            .Select(f => f.Id)
            .ToList();

        var components = await mediator.Send(new FetchComponents
        {
            BlueprintIds = blueprintIds
        }, cancellationToken);

        return await mediator.Send(new ProcessOrder
        {
            Components = components
        }, cancellationToken);
    }
}