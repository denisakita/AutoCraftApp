using domain.Interfaces;
using MediatR;

namespace application.Requests;

public class PlaceOrder : IRequest<IOrder>
{
    public string EngineCode { get; set; }
    
    public string ChassisCode { get; set; }
    
    public string OptionPackCode { get; set; }
}