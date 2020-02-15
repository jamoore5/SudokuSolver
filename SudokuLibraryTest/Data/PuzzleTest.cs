using System.Text;
using SudokuLibrary.Data;
using SudokuLibraryTest.Helpers;
using Xunit;

namespace SudokuLibraryTest.Data
{
    public class PuzzleTests
    {
        [Fact]
        public void ToString_EmptyPuzzle_ReturnEmptyPuzzle()
        {
            var puzzle = new Puzzle(4);

            var sb = new StringBuilder();
            sb.AppendLine("0 0 0 0");
            sb.AppendLine("0 0 0 0");
            sb.AppendLine("0 0 0 0");
            sb.AppendLine("0 0 0 0");
            var puzzleString = sb.ToString();

            Assert.Equal(puzzleString, puzzle.ToString());
        }

        [Fact]
        public void SetNumber_BlankPuzzle_ReturnPuzzleWithNumberSet()
        {
            var puzzle = new Puzzle(4);

            puzzle.SetNumber(4, 3, 3);

            var sb = new StringBuilder();
            sb.AppendLine("0 0 0 0");
            sb.AppendLine("0 0 0 0");
            sb.AppendLine("0 0 0 0");
            sb.AppendLine("0 0 0 4");
            var puzzleString = sb.ToString();

            Assert.Equal(puzzleString, puzzle.ToString());
        }

        [Fact]
        public void Valid_ValidPuzzleInvalidSetNumber_ReturnFalse()
        {
            var sb = new StringBuilder();
            sb.AppendLine("1 4 3 2");
            sb.AppendLine("2 3 1 4");
            sb.AppendLine("3 2 0 1");
            sb.AppendLine("4 1 2 3");
            var puzzleString = sb.ToString();

            var puzzle = PuzzleHelper.BuildPuzzle(puzzleString);

            puzzle.SetNumber(3, 2, 2);

            var actual = puzzle.Valid;

            Assert.False(actual);
        }

        [Fact]
        public void Valid_InvalidPuzzleValidSetNumber_ReturnFalse()
        {
            var sb = new StringBuilder();
            sb.AppendLine("1 1 3 2");
            sb.AppendLine("2 3 1 4");
            sb.AppendLine("3 2 0 1");
            sb.AppendLine("4 1 2 3");
            var puzzleString = sb.ToString();

            var puzzle = PuzzleHelper.BuildPuzzle(puzzleString);

            puzzle.SetNumber(4, 2, 2);

            var actual = puzzle.Valid;

            Assert.False(actual);
        }

        [Fact]
        public void Solved_FullValidPuzzleButInvalidSetNumber_ReturnFalse()
        {
            var sb = new StringBuilder();
            sb.AppendLine("1 4 3 2");
            sb.AppendLine("2 3 1 4");
            sb.AppendLine("3 2 0 1");
            sb.AppendLine("4 1 2 3");
            var puzzleString = sb.ToString();

            var puzzle = PuzzleHelper.BuildPuzzle(puzzleString);

            puzzle.SetNumber(3, 2, 2);

            var actual = puzzle.Solved;

            Assert.False(actual);
        }

        [Fact]
        public void Valid_ValidPuzzleValidSetNumber_ReturnTrue()
        {
            var sb = new StringBuilder();
            sb.AppendLine("1 4 3 2");
            sb.AppendLine("2 3 1 4");
            sb.AppendLine("3 2 0 1");
            sb.AppendLine("4 1 2 3");
            var puzzleString = sb.ToString();

            var puzzle = PuzzleHelper.BuildPuzzle(puzzleString);

            puzzle.SetNumber(4, 2, 2);

            var actual = puzzle.Valid;

            Assert.True(actual);
        }

        public void Solced_FullValidPuzzleValidSetNumber_ReturnTrue()
        {
            var sb = new StringBuilder();
            sb.AppendLine("1 4 3 2");
            sb.AppendLine("2 3 1 4");
            sb.AppendLine("3 2 0 1");
            sb.AppendLine("4 1 2 3");
            var puzzleString = sb.ToString();

            var puzzle = PuzzleHelper.BuildPuzzle(puzzleString);

            puzzle.SetNumber(4, 2, 2);

            var actual = puzzle.Solved;

            Assert.True(actual);
        }


        [Fact]
        public void GetRow_4x4Puzzle_ReturnFirstRow()
        {
            var sb = new StringBuilder();
            sb.AppendLine("1 2 3 4");
            sb.AppendLine("0 0 0 0");
            sb.AppendLine("0 0 0 0");
            sb.AppendLine("0 0 0 0");
            var puzzleString = sb.ToString();

            var puzzle = PuzzleHelper.BuildPuzzle(puzzleString);

            var row = puzzle.GetRow(0);

            Assert.Equal("1 2 3 4", string.Join(" ", row));
        }

        [Fact]
        public void GetRow_4x4Puzzle_ReturnFThirdRow()
        {
            var sb = new StringBuilder();
            sb.AppendLine("0 0 0 0");
            sb.AppendLine("0 0 0 0");
            sb.AppendLine("1 2 3 4");
            sb.AppendLine("0 0 0 0");
            var puzzleString = sb.ToString();

            var puzzle = PuzzleHelper.BuildPuzzle(puzzleString);

            var row = puzzle.GetRow(2);

            Assert.Equal("1 2 3 4", string.Join(" ", row));
        }

        [Fact]
        public void GetColumn_4x4Puzzle_ReturnFirstColumn()
        {
            var sb = new StringBuilder();
            sb.AppendLine("1 0 0 0");
            sb.AppendLine("2 0 0 0");
            sb.AppendLine("3 0 0 0");
            sb.AppendLine("4 0 0 0");
            var puzzleString = sb.ToString();

            var puzzle = PuzzleHelper.BuildPuzzle(puzzleString);

            var column = puzzle.GetColumn(0);

            Assert.Equal("1 2 3 4", string.Join(" ", column));
        }

        [Fact]
        public void GetColumn_4x4Puzzle_ReturnFThirdColumn()
        {
            var sb = new StringBuilder();
            sb.AppendLine("0 0 1 0");
            sb.AppendLine("0 0 2 0");
            sb.AppendLine("0 0 3 0");
            sb.AppendLine("0 0 4 0");
            var puzzleString = sb.ToString();

            var puzzle = PuzzleHelper.BuildPuzzle(puzzleString);

            var column = puzzle.GetColumn(2);

            Assert.Equal("1 2 3 4", string.Join(" ", column));
        }

        [Fact]
        public void GetSquare_4x4Puzzle_ReturnFirstSquare()
        {
            var sb = new StringBuilder();
            sb.AppendLine("1 2 0 0");
            sb.AppendLine("3 4 0 0");
            sb.AppendLine("0 0 0 0");
            sb.AppendLine("0 0 0 0");
            var puzzleString = sb.ToString();

            var puzzle = PuzzleHelper.BuildPuzzle(puzzleString);

            var square = puzzle.GetSquare(0);

            Assert.Equal("1 2 3 4", string.Join(" ", square));
        }

        [Fact]
        public void GetSquare_4x4Puzzle_ReturnFourthSquare()
        {
            var sb = new StringBuilder();
            sb.AppendLine("0 0 0 0");
            sb.AppendLine("0 0 0 0");
            sb.AppendLine("0 0 1 2");
            sb.AppendLine("0 0 3 4");
            var puzzleString = sb.ToString();

            var puzzle = PuzzleHelper.BuildPuzzle(puzzleString);

            var square = puzzle.GetSquare(3);

            Assert.Equal("1 2 3 4", string.Join(" ", square));
        }

        [Fact]
        public void GetSquare_9x9Puzzle_ReturnFifthSquare()
        {
            var sb = new StringBuilder();
            sb.AppendLine("0 0 0 0 0 0 0 0 0");
            sb.AppendLine("0 0 0 0 0 0 0 0 0");
            sb.AppendLine("0 0 0 0 0 0 0 0 0");
            sb.AppendLine("0 0 0 1 2 3 0 0 0");
            sb.AppendLine("0 0 0 4 5 6 0 0 0");
            sb.AppendLine("0 0 0 7 8 9 0 0 0");
            sb.AppendLine("0 0 0 0 0 0 0 0 0");
            sb.AppendLine("0 0 0 0 0 0 0 0 0");
            sb.AppendLine("0 0 0 0 0 0 0 0 0");
            var puzzleString = sb.ToString();

            var puzzle = PuzzleHelper.BuildPuzzle(puzzleString);

            var square = puzzle.GetSquare(4);

            Assert.Equal("1 2 3 4 5 6 7 8 9", string.Join(" ", square));
        }

        [Fact]
        public void GetSquareIndex_4x4Puzzle()
        {
            var puzzle = new Puzzle(4);

            Assert.Equal(0, puzzle.GetSquareIndex(0,0));
            Assert.Equal(0, puzzle.GetSquareIndex(0,1));
            Assert.Equal(0, puzzle.GetSquareIndex(1,0));
            Assert.Equal(0, puzzle.GetSquareIndex(1,1));

            Assert.Equal(1, puzzle.GetSquareIndex(0,2));
            Assert.Equal(1, puzzle.GetSquareIndex(0,3));
            Assert.Equal(1, puzzle.GetSquareIndex(1,2));
            Assert.Equal(1, puzzle.GetSquareIndex(1,3));

            Assert.Equal(2, puzzle.GetSquareIndex(2,0));
            Assert.Equal(2, puzzle.GetSquareIndex(2,1));
            Assert.Equal(2, puzzle.GetSquareIndex(3,0));
            Assert.Equal(2, puzzle.GetSquareIndex(3,1));

            Assert.Equal(3, puzzle.GetSquareIndex(2,2));
            Assert.Equal(3, puzzle.GetSquareIndex(2,3));
            Assert.Equal(3, puzzle.GetSquareIndex(3,2));
            Assert.Equal(3, puzzle.GetSquareIndex(3,3));
        }

        [Fact]
        public void GetSquareIndex_9x9Puzzle()
        {
            var puzzle = new Puzzle(9);

            Assert.Equal(0, puzzle.GetSquareIndex(1,2));
            Assert.Equal(0, puzzle.GetSquareIndex(2,2));

            Assert.Equal(1, puzzle.GetSquareIndex(1,5));
            Assert.Equal(1, puzzle.GetSquareIndex(2,4));

            Assert.Equal(2, puzzle.GetSquareIndex(0,6));
            Assert.Equal(2, puzzle.GetSquareIndex(2,8));

            Assert.Equal(3, puzzle.GetSquareIndex(3,1));
            Assert.Equal(3, puzzle.GetSquareIndex(4,2));

            Assert.Equal(4, puzzle.GetSquareIndex(3,5));
            Assert.Equal(4, puzzle.GetSquareIndex(4,3));

            Assert.Equal(5, puzzle.GetSquareIndex(4,7));
            Assert.Equal(5, puzzle.GetSquareIndex(5,7));

            Assert.Equal(6, puzzle.GetSquareIndex(6,1));
            Assert.Equal(6, puzzle.GetSquareIndex(8,2));

            Assert.Equal(7, puzzle.GetSquareIndex(7,5));
            Assert.Equal(7, puzzle.GetSquareIndex(8,3));

            Assert.Equal(8, puzzle.GetSquareIndex(6,8));
            Assert.Equal(8, puzzle.GetSquareIndex(7,7));
        }
    }
}