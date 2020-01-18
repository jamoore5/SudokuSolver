using SudokuLibrary.Data;
using SudokuLibrary.Services;

namespace SudokuLibraryTest.Helpers
{
    public static class PuzzleHelper
    {
        public static Puzzle BuildPuzzle(string puzzleString)
        {
            var writer = new PuzzleStringReader(puzzleString);
            return writer.Read();
        }
    }
}