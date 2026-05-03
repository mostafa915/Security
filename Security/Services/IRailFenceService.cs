using Security.DTOs.RailFence;
using Security.DTOs.Vigenere;

namespace Security.Services
{
    public interface IRailFenceService
    {
        RailFenceResponse Encrypt(RailFenceRequest request);
        RailFenceResponse Decrypt(RailFenceRequest request);
    }
}
