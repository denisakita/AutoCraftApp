using System.Collections.Generic;
using domain.Interfaces;

namespace application.Interfaces.Providers.Requests;

public interface IOrderRequest : IProviderRequest
{
    public IEnumerable<IComponent> Components { get; set; }
}

public class OrderRequest : IOrderRequest
{
    public IEnumerable<IComponent> Components { get; set; }
}