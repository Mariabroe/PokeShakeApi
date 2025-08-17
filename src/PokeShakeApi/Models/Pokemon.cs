using System.Text.Json.Serialization;

namespace PokeShakeApi.Models;

public class Pokemon
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; } = "";

    [JsonPropertyName("flavor_text_entries")]
    public List<FlavorTextEntry> FlavorTextEntries { get; set; } = new();
}

public class FlavorTextEntry
{
    [JsonPropertyName("flavor_text")]
    public string FlavorText { get; set; } = "";

    [JsonPropertyName("language")]
    public Named Language { get; set; } = new();
}

public class Named
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = "";
}