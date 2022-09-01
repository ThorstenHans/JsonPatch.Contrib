using Newtonsoft.Json.Serialization;
using Xunit;

namespace ThorstenHans.JsonPatch.Contrib.Tests;

public class JsonPatchDocumentBuilderTests
{
    
    [Fact]
    public void ItMayNotReturnNull()
    {
        var actual = JsonPatchDocumentBuilder.BuildFor<TestModel>();
        Assert.NotNull(actual);
    }

    [Fact]
    public void ItShouldSetProperGenericType()
    {
        var actual = JsonPatchDocumentBuilder.BuildFor<TestModel>();
        Assert.Equal(typeof(TestModel), actual.GetType().GenericTypeArguments[0]);
    }
    
    [Fact]
    public void ItShouldSetContractResolverOnJsonPatchDocument()
    {
        var actual = JsonPatchDocumentBuilder.BuildFor<TestModel>();
        
        Assert.NotNull(actual.ContractResolver);
        Assert.IsType<DefaultContractResolver>(actual.ContractResolver);

        Assert.IsType<CamelCaseNamingStrategy>((actual.ContractResolver as DefaultContractResolver).NamingStrategy);
    }
}
