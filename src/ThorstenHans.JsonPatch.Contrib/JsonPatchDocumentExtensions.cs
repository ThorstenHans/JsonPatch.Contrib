using Microsoft.AspNetCore.JsonPatch;

namespace ThorstenHans.JsonPatch.Contrib;

public static class JsonPatchDocumentExtensions
{
    public static string ToJsonPatch<T>(this JsonPatchDocument<T> doc) where T : class
    {
        return doc.Operations == null
            ? "[]"
            : System.Text.Json.JsonSerializer.Serialize(doc.Operations.Select(o => new { o.path, o.op, o.value }));
    }
}
