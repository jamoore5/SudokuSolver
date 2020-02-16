using System.Text;
using SudokuLibrary.Services;
using SudokuLibraryTest.Helpers;
using Xunit;

namespace SudokuLibraryTest.Services
{
    public class PuzzleSolverTest
    {
        [Fact]
        public void Solve_Test()
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

            sb.Clear();
            sb.AppendLine("3 2 1 4");
            sb.AppendLine("4 1 3 2");
            sb.AppendLine("1 4 2 3");
            sb.AppendLine("2 3 4 1");
            var expectedSolution = sb.ToString();
            Assert.Equal(expectedSolution, puzzle.ToString());
        }

        [Fact]
        public void Solve_Test2()
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

            sb.Clear();
            sb.AppendLine("4 2 3 1");
            sb.AppendLine("1 3 4 2");
            sb.AppendLine("3 1 2 4");
            sb.AppendLine("2 4 1 3");
            var expectedSolution = sb.ToString();
            Assert.Equal(expectedSolution, puzzle.ToString());
        }

        [Fact]
        public void Solve_Test3()
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
        public void Solve_Test4()
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
        public void Solve_Test5()
        {
            var sb = new StringBuilder();
            sb.AppendLine("0 0 0 8 7 0 4 0 0");
            sb.AppendLine("0 0 0 6 0 0 9 5 3");
            sb.AppendLine("0 0 0 0 0 0 0 0 7");

            sb.AppendLine("7 0 4 0 9 0 2 0 0");
            sb.AppendLine("0 9 5 0 0 2 3 4 0");
            sb.AppendLine("0 0 0 0 0 5 0 0 0");

            sb.AppendLine("0 3 0 0 5 0 0 0 8");
            sb.AppendLine("0 0 0 2 8 0 0 7 0");
            sb.AppendLine("0 0 0 0 0 7 0 0 0");
            var puzzleString = sb.ToString();

            var puzzle = PuzzleHelper.BuildPuzzle(puzzleString);

            var solver = new PuzzleSolver(puzzle);
            var result = solver.Solve();

            Assert.True(result);
        }

        // Still takes too long to solve
        // [Fact]
        // public void Solve_Test6()
        // {
        //     var sb = new StringBuilder();
        //     sb.AppendLine("0 0 9 0 0 0 15 0 0 4 13 16 10 3 0 8");
        //     sb.AppendLine("0 0 4 5 0 16 10 0 0 12 0 0 0 7 0 0");
        //     sb.AppendLine("0 0 0 0 14 11 0 0 0 0 9 0 13 0 12 0");
        //     sb.AppendLine("0 0 0 0 0 0 0 0 0 0 0 0 0 0 5 0");
        //
        //     sb.AppendLine("8 0 15 0 4 0 0 0 7 3 16 14 0 13 6 0");
        //     sb.AppendLine("0 0 11 0 0 0 0 2 0 0 0 0 0 0 7 0");
        //     sb.AppendLine("0 9 2 6 0 7 0 0 5 0 0 0 0 0 0 0");
        //     sb.AppendLine("0 3 1 0 0 0 13 5 0 8 12 0 0 0 4 11");
        //
        //     sb.AppendLine("10 6 3 0 0 0 0 7 12 15 0 11 9 0 0 13");
        //     sb.AppendLine("0 5 0 0 3 0 2 10 0 13 0 8 0 16 11 0");
        //     sb.AppendLine("15 0 0 0 0 12 9 0 3 0 0 2 4 0 0 0");
        //     sb.AppendLine("0 2 13 0 0 0 0 0 0 0 7 4 15 0 0 10");
        //
        //     sb.AppendLine("0 0 0 0 0 0 5 15 9 0 14 0 0 8 0 16");
        //     sb.AppendLine("0 13 0 0 8 0 0 11 6 0 0 0 7 0 2 0");
        //     sb.AppendLine("0 0 7 0 12 3 0 0 0 0 4 15 0 11 9 6");
        //     sb.AppendLine("0 0 8 0 0 0 0 0 0 0 0 0 12 0 0 0");
        //     var puzzleString = sb.ToString();
        //
        //     var puzzle = PuzzleHelper.BuildPuzzle(puzzleString);
        //
        //     var solver = new PuzzleSolver(puzzle);
        //     var result = solver.Solve();
        //
        //     Assert.True(result);
        // }
    }
}