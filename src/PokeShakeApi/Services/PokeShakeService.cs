
namespace PokeShakeApi.Services;

public interface IPokeShakeService
{
    Task<PokeShakeDto> GetPokeShake(string idOrName);
}

public class PokeShakeService(IHttpClientFactory httpFactory) : IPokeShakeService
{
    public async Task<PokeShakeDto> GetPokeShake(string idOrName)
    {
        var pokeClient = httpFactory.CreateClient("poke");
        
        var responseMessage = await pokeClient.GetAsync($"pokemon-species/{Uri.EscapeDataString(idOrName)}");
        responseMessage.EnsureSuccessStatusCode();

        var pokemon = await responseMessage.Content.ReadFromJsonAsync<Pokemon>()
                      ?? throw new HttpRequestException("no_data", null, HttpStatusCode.BadGateway);

        var english = pokemon.GetEnglishText();

        var shakeClient = httpFactory.CreateClient("shake");
        var shakespeare = await ShakespeareTranslation.TranslateAsync(shakeClient, english);

        return new PokeShakeDto
        {
            Id = pokemon.Id,
            Name = pokemon.Name,
            EnglishDescription = english,
            ShakespeareDescription = shakespeare
        };
    }
}