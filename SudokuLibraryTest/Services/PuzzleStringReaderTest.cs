using System.Linq;
using System.Text;
using SudokuLibrary.Services;
using SudokuLibraryTest.Helpers;
using Xunit;

namespace SudokuLibraryTest.Services
{
    public class PuzzleStringReaderTests
    {
        [Fact]
        public void Size_4x4PuzzleString_Returns4()
        {
            var puzzleString = PuzzleStringHelper.BuildPuzzleString(4);
            
            var reader = new PuzzleStringReader(puzzleString);
            var size = reader.Size;
            
            Assert.Equal(4, size);
        }

        [Fact]
        public void Size_9x9PuzzleString_Returns9()
        {
            var puzzleString = PuzzleStringHelper.BuildPuzzleString(9);

            var reader = new PuzzleStringReader(puzzleString);
            var size = reader.Size;

            Assert.Equal(9, size);
        }

        [Fact]
        public void Read_4by4PuzzleString_ReturnPuzzleWithSameToString()
        {
            var puzzleString = PuzzleStringHelper.BuildPuzzleString(4);
            
            var reader = new PuzzleStringReader(puzzleString);
            var puzzle = reader.Read();
            
            Assert.Equal(puzzleString, puzzle.ToString());
        }

        [Fact]
        public void Read_9by9PuzzleString_ReturnPuzzleWithSameToString()
        {
            var puzzleString = PuzzleStringHelper.BuildPuzzleString(9);
            
            var reader = new PuzzleStringReader(puzzleString);
            var puzzle = reader.Read();
            
            Assert.Equal(puzzleString, puzzle.ToString());
        }
    }
}