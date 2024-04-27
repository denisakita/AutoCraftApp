using System.Collections.Generic;

namespace application.Interfaces.Providers.Requests;

public interface IBlueprintRequest : IProviderRequest
{
    public IEnumerable<string> Codes { get; set; }
}

public class BlueprintRequest : IBlueprintRequest
{
    public IEnumerable<string> Codes { get; set; }
}