using System.Linq;
using System.Text;
using SudokuLibrary.Data;

namespace SudokuLibrary.Services
{
    public class PuzzleStringWriter
    {
        private readonly Puzzle _puzzle;

        public PuzzleStringWriter(Puzzle puzzle)
        {
            _puzzle = puzzle;
        }

        public string Write()
        {
            var sb = new StringBuilder();
            foreach (var idx in Enumerable.Range(0, _puzzle.Size))
            {
                var row = _puzzle.GetRow(idx);
                sb.AppendLine(string.Join(" ", row));
            }

            return sb.ToString();
        }
    }
}