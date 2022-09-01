using System.Text.Json.Nodes;
using Xunit;

namespace ThorstenHans.JsonPatch.Contrib.Tests;

public class ToJsonPatchDocumentTests
{
    [Fact]
    public void ItShouldReturnEmptyArrayWhenMissingOperations()
    {
        var doc = JsonPatchDocumentBuilder.BuildFor<TestModel>();
        Assert.Equal("[]", doc.ToJsonPatch());
    }

    [Fact]
    public void EveryOperationShouldOnlyContainValidProperties()
    {
        var doc = JsonPatchDocumentBuilder.BuildFor<TestModel>();
        doc.Replace(t => t.Foo, 2);
        var actual = doc.ToJsonPatch();
        var operations = System.Text.Json.JsonSerializer.Deserialize<JsonArray>(actual);

        Assert.Single(operations!);

        var operation = operations![0].AsObject();

        Assert.True(operation.ContainsKey("path"));
        Assert.True(operation.ContainsKey("op"));
        Assert.True(operation.ContainsKey("value"));
        Assert.False(operation.ContainsKey("from"));
        Assert.False(operation.ContainsKey("OperationType"));
    }
}
