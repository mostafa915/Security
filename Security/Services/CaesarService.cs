using Security.Abstractions;
using Security.DTOs.Caesar;
using Security.Enums;
using System.Text;

namespace Security.Services
{
    public class CaesarService : ICaesarService
    {
        public CaesarResponse Encrypt(CaesarRequest request)
        {
            StringBuilder cipherText = new StringBuilder();
            int normalizedShift = request.ShiftKey % 26;
            
            foreach (char character in request.Text)
            {
                if (char.IsLetter(character))
                {
                    char offset = char.IsUpper(character) ? 'A' : 'a';
                    int charIndex = (character - offset + normalizedShift + 26) % 26;
                    cipherText.Append((char)(charIndex + offset));
                }
                else
                {
                    cipherText.Append(character);
                }
            }

            var response = new CaesarResponse(cipherText.ToString(), Operation.Encryption.ToString(), Algorithm.Caesar.ToString(), request.ShiftKey);
            return response;
        }

        public CaesarResponse Decrypt(CaesarRequest request)
        {
            StringBuilder plainText = new StringBuilder();
            int normalizedShift = request.ShiftKey % 26;

            foreach (char character in request.Text)
            {
                if (char.IsLetter(character))
                {
                    char offset = char.IsUpper(character) ? 'A' : 'a';
                    int charIndex = (character - offset - normalizedShift + 26) % 26;

                    plainText.Append((char)(charIndex + offset));
                }
                else
                {
                    plainText.Append(character);
                }
            }

            var response = new CaesarResponse(plainText.ToString(), Operation.Decryption.ToString(), Algorithm.Caesar.ToString(), request.ShiftKey);
            return response;
        }
    }
}
