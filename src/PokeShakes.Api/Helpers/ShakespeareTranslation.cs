namespace PokeShakes.Api.Helpers;

public static class ShakespeareTranslation
{
    public static async Task<string> TranslateAsync(HttpClient shakespeareClient, string englishText)
    {
        var body = new FormUrlEncodedContent(new Dictionary<string, string>
        {
            ["text"] = englishText
        });

        var responseMessage = await shakespeareClient.PostAsync("/translate/shakespeare.json", body);
        responseMessage.EnsureSuccessStatusCode();

        var shakespeareText= await responseMessage.Content.ReadFromJsonAsync<Shakes>()
                              ?? throw new InvalidOperationException("No English Text Found");

        return shakespeareText.Contents.Translated;
    }
}