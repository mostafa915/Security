namespace Security.DTOs.Caesar
{
    public record CaesarRequest(
        string Text,
        int ShiftKey
        );
}
