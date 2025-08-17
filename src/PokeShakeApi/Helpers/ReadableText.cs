namespace PokeShakeApi.Helpers;

public static class ReadableText
{
    public static string Normalize(string? value)
    {
        if (string.IsNullOrWhiteSpace(value)) return string.Empty;

        var normalized = value
            .Replace('\n', ' ')
            .Replace('\r', ' ')
            .Replace('\f', ' ')
            .Replace('\t', ' ');

        return string.Join(' ', normalized.Split(' '));
    }
}