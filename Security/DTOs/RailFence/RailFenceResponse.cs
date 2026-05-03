namespace Security.DTOs.RailFence
{
    public record RailFenceResponse(
        string Result,
        string operation,
        string algorithm,
        int keyUsed
        );
}
