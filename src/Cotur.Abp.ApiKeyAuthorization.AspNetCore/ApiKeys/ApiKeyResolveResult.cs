namespace Cotur.Abp.ApiKeyAuthorization.Http.ApiKeys;

public class ApiKeyResolveResult
{
    public string ApiKeyValue { get; set; }

    public List<string> AppliedResolvers { get; }

    public ApiKeyResolveResult()
    {
        AppliedResolvers = new List<string>();
    }
}