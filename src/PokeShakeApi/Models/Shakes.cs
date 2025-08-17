using System.Text.Json.Serialization;

namespace PokeShakeApi.Models;

public class Shakes
{
    [JsonPropertyName("contents")]
    public ShakeContents Contents { get; init; } = new ();
}

public class ShakeContents
{
    [JsonPropertyName("translated")]
    public string Translated { get; set; } = "";
}