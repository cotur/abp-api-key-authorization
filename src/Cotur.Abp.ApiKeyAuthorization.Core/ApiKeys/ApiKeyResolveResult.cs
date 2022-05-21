namespace Cotur.Abp.ApiKeyAuthorization.Core.ApiKeys;

public class ApiKeyResolveResult
{
    public string ApiKeyValue { get; set; }

    public List<string> AppliedResolvers { get; }

    public ApiKeyResolveResult()
    {
        AppliedResolvers = new List<string>();
    }
}