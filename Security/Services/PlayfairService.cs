using Security.DTOs.Playfair;
using Security.Enums;
using System.Text;

namespace Security.Services
{
    public class PlayfairService : IPlayfairService
    {
        public PlayfairResponse Encrypt(PlayfairRequest request)
        {
            char[,] matrix = GenerateMatrix(request.Key);
            string preparedText = PrepareTextForEncryption(request.Text);
            StringBuilder cipherText = new StringBuilder();

            for (int i = 0; i < preparedText.Length; i += 2)
            {
                char a = preparedText[i];
                char b = preparedText[i + 1];

                var (rowA, colA) = GetPosition(matrix, a);
                var (rowB, colB) = GetPosition(matrix, b);

                if (rowA == rowB)
                {
                    cipherText.Append(matrix[rowA, (colA + 1) % 5]);
                    cipherText.Append(matrix[rowB, (colB + 1) % 5]);
                }
                else if (colA == colB)
                {
                    cipherText.Append(matrix[(rowA + 1) % 5, colA]);
                    cipherText.Append(matrix[(rowB + 1) % 5, colB]);
                }
                else
                {
                    cipherText.Append(matrix[rowA, colB]);
                    cipherText.Append(matrix[rowB, colA]);
                }
            }

            return new PlayfairResponse(cipherText.ToString(), Operation.Encryption.ToString(), Algorithm.Playfair.ToString(), request.Key);
        }

        public PlayfairResponse Decrypt(PlayfairRequest request)
        {
            char[,] matrix = GenerateMatrix(request.Key);
            StringBuilder plainText = new StringBuilder();
            string cipherText = request.Text.ToUpper().Replace(" ", "");

            if (cipherText.Length % 2 != 0) cipherText += "X";

            for (int i = 0; i < cipherText.Length; i += 2)
            {
                char a = cipherText[i];
                char b = cipherText[i + 1];

                var (rowA, colA) = GetPosition(matrix, a);
                var (rowB, colB) = GetPosition(matrix, b);

                if (rowA == rowB)
                {
                    plainText.Append(matrix[rowA, (colA + 4) % 5]);
                    plainText.Append(matrix[rowB, (colB + 4) % 5]);
                }
                else if (colA == colB)
                {
                    plainText.Append(matrix[(rowA + 4) % 5, colA]);
                    plainText.Append(matrix[(rowB + 4) % 5, colB]);
                }
                else
                {
                    plainText.Append(matrix[rowA, colB]);
                    plainText.Append(matrix[rowB, colA]);
                }
            }

            return new PlayfairResponse(plainText.ToString(), Operation.Decryption.ToString(), Algorithm.Playfair.ToString(), request.Key);
        }

        private char[,] GenerateMatrix(string key)
        {
            string alphabet = "ABCDEFGHIKLMNOPQRSTUVWXYZ";
            string combined = (key.ToUpper() + alphabet).Replace("J", "I");
            string distinctKey = new string(combined.Distinct().Where(char.IsLetter).ToArray());

            char[,] matrix = new char[5, 5];
            for (int i = 0; i < 25; i++)
            {
                matrix[i / 5, i % 5] = distinctKey[i];
            }
            return matrix;
        }

        private string PrepareTextForEncryption(string text)
        {
            string t = text.ToUpper().Replace("J", "I").Replace(" ", "");
            List<char> chars = t.ToList();

            for (int i = 0; i < chars.Count - 1; i += 2)
            {
                if (chars[i] == chars[i + 1])
                {
                    chars.Insert(i + 1, 'X');
                }
            }

            if (chars.Count % 2 != 0)
            {
                chars.Add('X');
            }

            return new string(chars.ToArray());
        }

        private (int row, int col) GetPosition(char[,] matrix, char c)
        {
            for (int r = 0; r < 5; r++)
                for (int col = 0; col < 5; col++)
                    if (matrix[r, col] == c) return (r, col);
            return (-1, -1);
        }
    }
}