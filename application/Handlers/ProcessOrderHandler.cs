using System;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using application.Interfaces;
using application.Interfaces.Providers.Requests;
using application.Requests;
using domain.Interfaces;
using MediatR;

namespace application.Handlers;

public class ProcessOrderHandler(IProvider<IOrderRequest, IOrder> provider) : IRequestHandler<ProcessOrder, IOrder>
{
    public async Task<IOrder> Handle(ProcessOrder request, CancellationToken cancellationToken)
    {
        try
        {
            var order = await provider.ProvideAsync(new OrderRequest
            {
                Components = request.Components
            });

            return order;
        }
        catch
        { 
            throw new ValidationException("Order failed to complete!");
        }
    }
}