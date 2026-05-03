namespace Security.DTOs.Vigenere
{
    public record VigenereResponse(
        string Result,
        string operation,
        string algorithm,
        string keyUsed
        );
}
