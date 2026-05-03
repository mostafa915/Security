namespace Security.DTOs.Playfair
{
    public record PlayfairResponse(
        string Result,
        string operation,
        string algorithm,
        string keyUsed
        );
}
