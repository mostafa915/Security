namespace Security.DTOs.AutoKey
{
    public record AutoKeyResponse(
        string Result,
        string operation,
        string algorithm,
        string keyUsed
        );
}
