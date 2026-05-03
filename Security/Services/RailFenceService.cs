using Security.DTOs.Caesar;
using Security.DTOs.RailFence;
using Security.DTOs.Vigenere;
using Security.Enums;
using System.Text;

namespace Security.Services
{
    public class RailFenceService : IRailFenceService
    {
        public RailFenceResponse Encrypt(RailFenceRequest request)
        {
            string text = request.Text.Replace(" ", "").ToUpper();
            int rails = request.Key;
            char[,] fence = new char[rails, text.Length];

            bool descending = false;
            int row = 0;

            for (int i = 0; i < text.Length; i++)
            {
                if (row == 0 || row == rails - 1) descending = !descending;
                fence[row, i] = text[i];
                row += descending ? 1 : -1;
            }

            StringBuilder result = new StringBuilder();
            for (int i = 0; i < rails; i++)
            {
                for (int j = 0; j < text.Length; j++)
                {
                    if (fence[i, j] != '\0') result.Append(fence[i, j]);
                }
            }

            return new RailFenceResponse(result.ToString(), Operation.Encryption.ToString(), Algorithm.RailFence.ToString(), request.Key);
        }

        public RailFenceResponse Decrypt(RailFenceRequest request)
        {
            string cipherText = request.Text.ToUpper();
            int rails = request.Key;
            char[,] fence = new char[rails, cipherText.Length];

            bool descending = false;
            int row = 0;
            for (int i = 0; i < cipherText.Length; i++)
            {
                if (row == 0 || row == rails - 1) descending = !descending;
                fence[row, i] = '*';
                row += descending ? 1 : -1;
            }

            int index = 0;
            for (int i = 0; i < rails; i++)
            {
                for (int j = 0; j < cipherText.Length; j++)
                {
                    if (fence[i, j] == '*' && index < cipherText.Length)
                    {
                        fence[i, j] = cipherText[index++];
                    }
                }
            }

            StringBuilder result = new StringBuilder();
            descending = false;
            row = 0;
            for (int i = 0; i < cipherText.Length; i++)
            {
                if (row == 0 || row == rails - 1) descending = !descending;
                result.Append(fence[row, i]);
                row += descending ? 1 : -1;
            }

            return new RailFenceResponse(result.ToString(), Operation.Decryption.ToString(), Algorithm.RailFence.ToString(), request.Key);
        }
    }
}