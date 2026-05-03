using Security.DTOs.Playfair;

namespace Security.Services
{
    public interface IPlayfairService
    {
        PlayfairResponse Encrypt(PlayfairRequest request);
        PlayfairResponse Decrypt(PlayfairRequest request);

    }
}
