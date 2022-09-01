# ThorstenHans.JsonPatch.Contrib

[![Release Build](https://github.com/ThorstenHans/JsonPatch.Contrib/actions/workflows/release.yml/badge.svg)](https://github.com/ThorstenHans/JsonPatch.Contrib/actions/workflows/release.yml)

The main purpose of this NuGet package is to simplify the usage of `JsonPatchDocument<T>` (`Microsoft.AspNetCore.JsonPatch`) when generating JSON patch expressions.

This is especially handy when working with SDKs like for example the official Kubernetes Client SDK for C#.

The package takes care about specifying proper `ContractResolvers` and producing valid JSON patch expressions as `string` by removing unsupported properties before serializing into a string.

```csharp
public class TestModel
{
    public string FirstName { get; set; }
    public int Age { get; set; }
}

public class Examples 
{

    public static void Sample1()
    {
        var doc = JsonPatchDocumentBuilder.BuildFor<TestModel>();
        doc.Replace(t => t.FirstName, "John");
        doc.Replace(t => t.Age, 42);

        var patchString = doc.ToJsonPatch();
        Console.WriteLine(patchString);
    }

}

```

Invoking `Examples.Sample1()` will print the following string to the console:

```json
[
    {
        "path":"/firstName",
        "op":"replace",
        "value":"John"
    },
    {
        "path":"/age",
        "op":"replace",
        "value":42
    }
]
```

## Install via `dotnet` CLI

You can easily install the package using `dotnet` CLI:

```bash
dotnet add package ThorstenHans.JsonPatch.Contrib
```
