using System.Text;
using SudokuLibrary.Data;
using SudokuLibrary.Services;
using SudokuLibraryTest.Helpers;
using Xunit;

namespace SudokuLibraryTest.Services
{
    public class PuzzleValidatorTests
    {
        [Fact]
        public void IsValid_EmptyPuzzle_ReturnsTrue()
        {
            var puzzle = new Puzzle(4);
            
            var validator = new PuzzleValidator(puzzle);
            var actual = validator.Valid;
            
            Assert.True(actual);
        }
        
        [Fact]
        public void IsSolved_EmptyPuzzle_ReturnsFalse()
        {
            var puzzle = new Puzzle(4);
            
            var validator = new PuzzleValidator(puzzle);
            var actual = validator.Solved;
            
            Assert.False(actual);
        }
        
        [Fact]
        public void IsValidSolvedPuzzle_ReturnsTrue()
        {
            var sb = new StringBuilder();
            sb.AppendLine("1 4 3 2");
            sb.AppendLine("2 3 1 4");
            sb.AppendLine("3 2 4 1");
            sb.AppendLine("4 1 2 3");
            var puzzleString = sb.ToString();
            
            var puzzle = PuzzleHelper.BuildPuzzle(puzzleString);
            
            var validator = new PuzzleValidator(puzzle);
            var actual = validator.Valid;
            
            Assert.True(actual);
        }
        
        [Fact]
        public void IsSolved_SolvedPuzzle_ReturnsTrue()
        {
            var sb = new StringBuilder();
            sb.AppendLine("1 4 3 2");
            sb.AppendLine("2 3 1 4");
            sb.AppendLine("3 2 4 1");
            sb.AppendLine("4 1 2 3");
            var puzzleString = sb.ToString();
            
            var puzzle = PuzzleHelper.BuildPuzzle(puzzleString);
            
            var validator = new PuzzleValidator(puzzle);
            var actual = validator.Solved;
            
            Assert.True(actual);
        }
        
        [Fact]
        public void IsValid_SameNumberInRow_ReturnsFalse()
        {
            var sb = new StringBuilder();
            sb.AppendLine("0 0 0 0");
            sb.AppendLine("0 1 2 1");
            sb.AppendLine("0 0 0 0");
            sb.AppendLine("0 0 0 0");
            var puzzleString = sb.ToString();
            
            var puzzle = PuzzleHelper.BuildPuzzle(puzzleString);
            
            var validator = new PuzzleValidator(puzzle);
            var actual = validator.Valid;
            
            Assert.False(actual);
        }
        
        [Fact]
        public void IsValid_SameNumberInColumn_ReturnsFalse()
        {
            var sb = new StringBuilder();
            sb.AppendLine("0 0 0 0");
            sb.AppendLine("0 1 0 0");
            sb.AppendLine("0 2 0 0");
            sb.AppendLine("0 1 0 0");
            var puzzleString = sb.ToString();
            
            var puzzle = PuzzleHelper.BuildPuzzle(puzzleString);
            
            var validator = new PuzzleValidator(puzzle);
            var actual = validator.Valid;
            
            Assert.False(actual);
        }
        
        [Fact]
        public void IsValid_SameNumberInSquare_ReturnsFalse()
        {
            var sb = new StringBuilder();
            sb.AppendLine("1 2 0 0");
            sb.AppendLine("0 1 0 0");
            sb.AppendLine("0 0 0 0");
            sb.AppendLine("0 0 0 0");
            var puzzleString = sb.ToString();
            
            var puzzle = PuzzleHelper.BuildPuzzle(puzzleString);
            
            var validator = new PuzzleValidator(puzzle);
            var actual = validator.Valid;
            
            Assert.False(actual);
        }
    }
}