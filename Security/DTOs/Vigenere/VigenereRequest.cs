namespace Security.DTOs.Vigenere
{
    public record VigenereRequest(
        string Text,
        string Key
        );
}
