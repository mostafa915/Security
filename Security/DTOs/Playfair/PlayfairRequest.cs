namespace Security.DTOs.Playfair
{
    public record PlayfairRequest(
        string Text,
        string Key
        );
}
