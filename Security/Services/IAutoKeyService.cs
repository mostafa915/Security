using Security.DTOs.AutoKey;
using Security.DTOs.Vigenere;

namespace Security.Services
{
    public interface IAutoKeyService
    {
        AutoKeyResponse Encrypt(AutoKeyRequest request);
        AutoKeyResponse Decrypt(AutoKeyRequest request);
    }
}
