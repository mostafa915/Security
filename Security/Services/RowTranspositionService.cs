using Security.DTOs.Caesar;
using Security.DTOs.RowTransposition;
using Security.DTOs.Vigenere;
using Security.Enums;
using System.Text;

namespace Security.Services
{
    public class RowTranspositionService : IRowTranspositionService
    {
        public RowTranspositionResponse Encrypt(RowTranspositionRequest request)
        {
            string text = request.Text.Replace(" ", "").ToUpper();
            string key = request.Key.ToUpper();
            int columns = key.Length;
            int rows = (int)Math.Ceiling((double)text.Length / columns);

            text = text.PadRight(rows * columns, 'X');

            var order = GetKeyOrder(key);
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < columns; i++)
            {
                int colIndex = Array.IndexOf(order, i);
                for (int r = 0; r < rows; r++)
                {
                    result.Append(text[r * columns + colIndex]);
                }
            }

            return new RowTranspositionResponse(result.ToString(), Operation.Encryption.ToString(), Algorithm.RowTransposition.ToString(), request.Key);
        }

        public RowTranspositionResponse Decrypt(RowTranspositionRequest request)
        {
            string cipherText = request.Text.ToUpper();
            string key = request.Key.ToUpper();
            int columns = key.Length;
            int rows = cipherText.Length / columns;

            var order = GetKeyOrder(key);
            char[,] matrix = new char[rows, columns];
            int currentPos = 0;

            for (int i = 0; i < columns; i++)
            {
                int colIndex = Array.IndexOf(order, i);
                for (int r = 0; r < rows; r++)
                {
                    matrix[r, colIndex] = cipherText[currentPos++];
                }
            }

            StringBuilder result = new StringBuilder();
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < columns; c++)
                {
                    result.Append(matrix[r, c]);
                }
            }

            return new RowTranspositionResponse(result.ToString().TrimEnd('X'), Operation.Decryption.ToString(), Algorithm.RowTransposition.ToString(), request.Key);
        }

        private int[] GetKeyOrder(string key)
        {
            var sortedKey = key.Select((c, i) => new { Char = c, Index = i })
                               .OrderBy(x => x.Char)
                               .ToList();

            int[] order = new int[key.Length];
            for (int i = 0; i < key.Length; i++)
            {
                order[sortedKey[i].Index] = i;
            }
            return order;
        }
    }
}