using System;
using System.Linq;
using System.Threading.Tasks;
using application.Interfaces;
using application.Interfaces.Providers.Requests;
using domain.Interfaces;
using infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace infrastructure.Providers;

public class OrderProvider(BContext context) : IProvider<IOrderRequest, IOrder>
{
    public async Task<IOrder> ProvideAsync(IOrderRequest req)
    {
        var componentIds = req.Components.Select(f => f.Id).ToList();
        var componentEntities =
            await context.Set<ComponentEntity>().Where(f => componentIds.Contains(f.Id)).ToListAsync();


        var order = new OrderEntity
        {
            Id = Guid.NewGuid(),
            Status = req.Components.All(c => !string.IsNullOrEmpty(c.Warehouse))
                ? OrderStatus.Completed
                : OrderStatus.Pending,
            CreatedAt = DateTime.Now,
            SerialNo = $"ORD-{Guid.NewGuid()}",
            OrderNo = new Random(100000000).Next(),
            ComponentEntities = componentEntities
        };

        await context.Set<OrderEntity>().AddAsync(order);

        componentEntities = componentEntities.Select(f =>
        {
            f.OrderEntityId = order.Id;
            return f;
        }).ToList();

        context.Update(componentEntities);
        await context.SaveChangesAsync();
        return order;
    }
}