using System.Linq;
using SudokuLibrary.Data;
using SudokuLibrary.Services;
using Xunit;

namespace SudokuLibraryTest.Services
{
    public class PuzzleStringWriterTests
    {
        [Fact]
        public void Write_EmptyPuzzle_ReturnsEmptyPuzzleString()
        {
            var emptyPuzzle = new Puzzle(4);

            var writer = new PuzzleStringWriter(emptyPuzzle);
            var puzzleStr = writer.Write();
            
            Assert.Equal("0 0 0 0\n0 0 0 0\n0 0 0 0\n0 0 0 0\n", puzzleStr);
        }

        [Fact]
        public void Write_1234Puzzle_Returns1234PuzzleString()
        {
            var puzzle = new Puzzle(4);

            foreach (var num in Enumerable.Range(1, 4))
            {
                puzzle.SetNumber(num, 0, num-1);
            }

            var writer = new PuzzleStringWriter(puzzle);
            var puzzleStr = writer.Write();
            
            Assert.Equal("1 2 3 4\n0 0 0 0\n0 0 0 0\n0 0 0 0\n", puzzleStr);
        }
        
    }
}