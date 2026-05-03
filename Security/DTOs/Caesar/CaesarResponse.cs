using System.Text;

namespace Security.DTOs.Caesar
{
    public record CaesarResponse(
        string Result,
        string operation,
        string algorithm,
        int keyUsed
        );
}
