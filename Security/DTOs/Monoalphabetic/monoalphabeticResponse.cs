namespace Security.DTOs.Monoalphabetic
{
    public record monoalphabeticResponse(
        string Result,
        string operation,
        string algorithm,
        string keyUsed
        );
}
