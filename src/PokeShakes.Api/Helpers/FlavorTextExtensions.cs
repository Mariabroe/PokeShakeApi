using PokeShakes.Api.Models;

namespace PokeShakes.Api.Helpers;

public static class FlavorTextExtensions
{
    public static string GetEnglishText(this Pokemon pokemon)
    {
        var englishFlavor = pokemon.FlavorTextEntries?
                                .FirstOrDefault(e => string.Equals(e.Language?.Name, "en"))
                            ?? throw new InvalidOperationException("No English description found.");

        return ReadableText.Normalize(englishFlavor.FlavorText);
    }
}