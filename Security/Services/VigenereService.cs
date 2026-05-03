using Security.DTOs.Caesar;
using Security.DTOs.Vigenere;
using Security.Enums;
using System.Text;

namespace Security.Services
{
    public class VigenereService : IVigenereService
    {
        public VigenereResponse Encrypt(VigenereRequest request)
        {
            string text = request.Text.ToUpper();
            string key = request.Key.ToUpper();
            StringBuilder result = new StringBuilder();

            for (int i = 0, j = 0; i < text.Length; i++)
            {
                char c = text[i];
                if (char.IsLetter(c))
                {
                    int p = c - 'A';
                    int k = key[j % key.Length] - 'A';
                    int cipherChar = (p + k) % 26;
                    result.Append((char)(cipherChar + 'A'));
                    j++;
                }
                else
                {
                    result.Append(c);
                }
            }

            return new VigenereResponse(result.ToString(), Operation.Encryption.ToString(), Algorithm.Vigenere.ToString(), request.Key);
        }

        public VigenereResponse Decrypt(VigenereRequest request)
        {
            string text = request.Text.ToUpper();
            string key = request.Key.ToUpper();
            StringBuilder result = new StringBuilder();

            for (int i = 0, j = 0; i < text.Length; i++)
            {
                char c = text[i];
                if (char.IsLetter(c))
                {
                    int cipherChar = c - 'A';
                    int k = key[j % key.Length] - 'A';
                    int plainChar = (cipherChar - k + 26) % 26;
                    result.Append((char)(plainChar + 'A'));
                    j++;
                }
                else
                {
                    result.Append(c);
                }
            }

            return new VigenereResponse(result.ToString(), Operation.Decryption.ToString(), Algorithm.Vigenere.ToString(), request.Key);
        }
    }
}