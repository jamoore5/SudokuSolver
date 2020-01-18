using System.Linq;
using System.Text;

namespace SudokuLibraryTest.Helpers
{
    public static class PuzzleStringHelper
    {
        public static string BuildPuzzleString(int size)
        {
            var sb = new StringBuilder();

            foreach (var i in Enumerable.Range(1, size - 1)) 
                sb.Append($"{i} ");

            sb.AppendLine(size.ToString());

            foreach (var i in Enumerable.Range(1, size - 1))
            {
                var row = new int[size];
                sb.AppendLine(string.Join(" ", row));
            }

            return sb.ToString();
        }
    }
}