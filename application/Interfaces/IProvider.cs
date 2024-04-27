using System.Threading.Tasks;
using application.Interfaces.Providers.Requests;

namespace application.Interfaces;

public interface IProvider<TReq, TRes> where TReq : IProviderRequest
{
    public Task<TRes> ProvideAsync(TReq req) ; 
}