namespace Security.Services
{
    using global::Security.DTOs.AutoKey;
    using global::Security.DTOs.Caesar;
    using global::Security.DTOs.Vigenere;
    using global::Security.Enums;
    using System.Text;

    namespace Security.Services
    {
        public class AutokeyService : IAutoKeyService
        {
            public AutoKeyResponse Encrypt(AutoKeyRequest request)
            {
                string text = request.Text.ToUpper().Replace(" ", "");
                string key = request.Key.ToUpper();

                StringBuilder keyStream = new StringBuilder(key);
                keyStream.Append(text);
                string finalKey = keyStream.ToString().Substring(0, text.Length);

                StringBuilder result = new StringBuilder();
                for (int i = 0; i < text.Length; i++)
                {
                    int p = text[i] - 'A';
                    int k = finalKey[i] - 'A';
                    int c = (p + k) % 26;
                    result.Append((char)(c + 'A'));
                }

                return new AutoKeyResponse(result.ToString(), Operation.Encryption.ToString(), Algorithm.Autokey.ToString(), request.Key);
            }

            public AutoKeyResponse Decrypt(AutoKeyRequest request)
            {
                string cipherText = request.Text.ToUpper().Replace(" ", "");
                string key = request.Key.ToUpper();
                StringBuilder plainText = new StringBuilder();

                for (int i = 0; i < cipherText.Length; i++)
                {
                    int c = cipherText[i] - 'A';

                    int k = (i < key.Length) ? (key[i] - 'A') : (plainText[i - key.Length] - 'A');

                    int p = (c - k + 26) % 26;
                    plainText.Append((char)(p + 'A'));
                }

                return new AutoKeyResponse(plainText.ToString(), Operation.Decryption.ToString(), Algorithm.Autokey.ToString(), request.Key);
            }
        }
    }
}
