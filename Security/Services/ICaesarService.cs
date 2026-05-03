using Security.Abstractions;
using Security.DTOs.Caesar;

namespace Security.Services
{
    public interface ICaesarService
    {
        CaesarResponse Encrypt(CaesarRequest request);
        CaesarResponse Decrypt(CaesarRequest request);
    }
}
