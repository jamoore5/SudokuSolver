using System.Text;
using SudokuLibrary.Services;
using SudokuLibraryTest.Helpers;
using Xunit;

namespace SudokuLibraryTest.Services
{
    public class PuzzleSolverTest
    {
        [Fact]
        public void PopulatePossibilities_Test()
        {
            var sb = new StringBuilder();
            sb.AppendLine("0 0 0 4");
            sb.AppendLine("4 1 3 2");
            sb.AppendLine("0 0 2 3");
            sb.AppendLine("2 0 0 0");
            var puzzleString = sb.ToString();

            var puzzle = PuzzleHelper.BuildPuzzle(puzzleString);

            var solver = new PuzzleSolver(puzzle);
            var result = solver.Solve();

            Assert.True(result);
        }

        [Fact]
        public void PopulatePossibilities_Test2()
        {
            var sb = new StringBuilder();
            sb.AppendLine("0 2 3 0");
            sb.AppendLine("0 0 0 0");
            sb.AppendLine("3 1 2 4");
            sb.AppendLine("0 0 0 0");
            var puzzleString = sb.ToString();

            var puzzle = PuzzleHelper.BuildPuzzle(puzzleString);

            var solver = new PuzzleSolver(puzzle);
            var result = solver.Solve();

            Assert.True(result);
        }

        [Fact]
        public void PopulatePossibilities_Test3()
        {
            var sb = new StringBuilder();
            sb.AppendLine("0 6 0 0 0 3 0 0 0");
            sb.AppendLine("0 0 4 6 0 0 3 7 0");
            sb.AppendLine("0 3 5 4 0 0 2 8 6");
            sb.AppendLine("6 2 8 5 0 0 0 0 4");
            sb.AppendLine("4 7 0 0 0 2 5 0 8");
            sb.AppendLine("3 0 0 9 0 8 0 6 0");
            sb.AppendLine("5 9 2 3 0 6 0 4 0");
            sb.AppendLine("0 8 6 7 5 0 0 2 0");
            sb.AppendLine("7 0 3 8 2 0 0 5 0");
            var puzzleString = sb.ToString();

            var puzzle = PuzzleHelper.BuildPuzzle(puzzleString);

            var solver = new PuzzleSolver(puzzle);
            var result = solver.Solve();

            Assert.True(result);
        }

        [Fact]
        public void PopulatePossibilities_NotAnEasyPuzzlw()
        {
            var sb = new StringBuilder();
            sb.AppendLine("0 0 0 0 0 6 0 8 0");
            sb.AppendLine("0 2 6 0 3 0 1 0 0");
            sb.AppendLine("0 3 0 4 0 0 0 6 0");
            sb.AppendLine("1 0 5 2 9 0 7 3 4");
            sb.AppendLine("0 0 8 0 0 0 0 0 0");
            sb.AppendLine("3 0 0 0 0 7 8 0 5");
            sb.AppendLine("0 0 3 0 4 2 0 0 8");
            sb.AppendLine("2 0 0 0 0 0 0 0 0");
            sb.AppendLine("6 9 4 8 0 0 0 0 3");
            var puzzleString = sb.ToString();

            var puzzle = PuzzleHelper.BuildPuzzle(puzzleString);

            var solver = new PuzzleSolver(puzzle);
            var result = solver.Solve();

            Assert.False(result); // need more complex logic to solve
        }
    }
}