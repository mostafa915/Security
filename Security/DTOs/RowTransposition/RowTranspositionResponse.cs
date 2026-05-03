namespace Security.DTOs.RowTransposition
{
    public record RowTranspositionResponse(
        string Result,
        string operation,
        string algorithm,
        string keyUsed
        );
}
