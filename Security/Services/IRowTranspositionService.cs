using Security.DTOs.RowTransposition;

namespace Security.Services
{
    public interface IRowTranspositionService
    {
        RowTranspositionResponse Encrypt(RowTranspositionRequest request);
        RowTranspositionResponse Decrypt(RowTranspositionRequest request);
    }
}
