using Security.DTOs.Monoalphabetic;

namespace Security.Services
{
    public interface IMonoalphabeticService
    {
        monoalphabeticResponse Encrypt(monoalphabeticRequest request);
        public monoalphabeticResponse Decrypt(monoalphabeticRequest request);
    }
}
