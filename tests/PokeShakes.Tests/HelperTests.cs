using PokeShakes.Api.Helpers;
using PokeShakes.Api.Models;

namespace PokeShakes.Tests;

public class HelperTests
{
    [Fact]
    public void FlavorText_GetEnglishText_PicksEnglishAndCleans()
    {
        Pokemon pokemon = new Pokemon
        {
            Id = 1,
            Name = "bulbasaur",
            FlavorTextEntries =
            [
                new FlavorTextEntry { FlavorText = "Det\nher\ner\nen\nPokemon", Language = new Named { Name = "dk" } },
                new FlavorTextEntry { FlavorText = "This\nis\na\nPokemon", Language = new Named { Name = "en" } }
            ]
        };

        string text = pokemon.GetEnglishText();
        Assert.Equal("This is a Pokemon", text);
    }
    
}