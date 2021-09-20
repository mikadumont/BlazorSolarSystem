using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;

namespace SolarSystem;

internal record Astronomer(string FirstName, string LastName, string? MiddleName = null);

[JsonSourceGenerationOptions(GenerationMode = JsonSourceGenerationMode.Serialization)]
[JsonSerializable(typeof(Astronomer))]
internal partial class AstronomerJsonContext : JsonSerializerContext
{
    public override JsonTypeInfo? GetTypeInfo(Type type)
    {
        throw new NotImplementedException();
    }
}

class Program
{
    static void Main(string[] args)
    {
        using MemoryStream ms = new();
        using Utf8JsonWriter writer = new(ms);

        var astronomer = new Astronomer(FirstName: "Jane", LastName: "Doe");

        AstronomerJsonContext.Default.Astronomer.Serialize!(writer, astronomer);
        writer.Flush();
    }
}


