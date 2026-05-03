using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Security.DTOs.Monoalphabetic;
using Security.Enums;
using System.Text;

namespace Security.Services
{
    public class MonoalphabeticService : IMonoalphabeticService
    {
        private const string Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public monoalphabeticResponse Encrypt(monoalphabeticRequest request)
        {
            string upperText = request.Text.ToUpper();
            string upperKey = request.Key.ToUpper();

            var encryptionMap = new Dictionary<char, char>();

            for (int i = 0; i < Alphabet.Length; i++)
            {
                encryptionMap.Add(Alphabet[i], upperKey[i]);
            }

            StringBuilder result = new StringBuilder();
            foreach (char c in upperText)
            {
                if (char.IsLetter(c))
                {
                    result.Append(encryptionMap[c]);
                }
                else
                {
                    result.Append(c); 
                }
            }

            var response = new monoalphabeticResponse(result.ToString(), Operation.Encryption.ToString(), Algorithm.Monoalphabetic.ToString(), request.Key);
            return response;
        }

        public monoalphabeticResponse Decrypt(monoalphabeticRequest request)
        {

            string upperText = request.Text.ToUpper();
            string upperKey = request.Key.ToUpper();

            var decryptionMap = new Dictionary<char, char>();
            for (int i = 0; i < Alphabet.Length; i++)
            {
                decryptionMap.Add(upperKey[i], Alphabet[i]);
            }

            StringBuilder result = new StringBuilder();
            foreach (char c in upperText)
            {
                if (char.IsLetter(c))
                {
                    result.Append(decryptionMap[c]);
                }
                else
                {
                    result.Append(c);
                }
            }


            var response = new monoalphabeticResponse(result.ToString(), Operation.Decryption.ToString(), Algorithm.Monoalphabetic.ToString(), request.Key);
            return response;
        }
    }
}
