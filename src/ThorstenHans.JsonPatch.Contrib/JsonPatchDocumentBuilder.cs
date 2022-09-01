using Microsoft.AspNetCore.JsonPatch;
using Newtonsoft.Json.Serialization;

namespace ThorstenHans.JsonPatch.Contrib;

public static class JsonPatchDocumentBuilder
{
    public static JsonPatchDocument<T> BuildFor<T>() where T : class
    {
        return new JsonPatchDocument<T>
        {
            ContractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            }
        };
    }
}
