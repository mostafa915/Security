using Security.DTOs.Caesar;
using Security.DTOs.Vigenere;

namespace Security.Services
{
    public interface IVigenereService
    {
        VigenereResponse Encrypt(VigenereRequest request);
        VigenereResponse Decrypt(VigenereRequest request);
    }
}
