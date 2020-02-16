using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using SudokuLibrary.Data;

namespace SudokuLibrary.Services
{
    public class PuzzleSolver
    {
        private Puzzle _puzzle;

        public PuzzleSolver(Puzzle puzzle)
        {
            _puzzle = puzzle;
        }

        public bool Solve()
        {
            var solved = Solve(out var finalPuzzle, _puzzle, 0);
            _puzzle.UpdatePuzzle(finalPuzzle);
            return solved;
        }

        private static bool PlaceNumber(Puzzle puzzle, int value, int rowIdx, int colIdx)
        {
            var validator = new PuzzleValidator(puzzle);
            if (!validator.ValidMove(value, rowIdx, colIdx)) return false;

            puzzle.SetNumber(value, rowIdx, colIdx);
            return true;
        }

        private static bool Solve(out Puzzle finalPuzzle, Puzzle puzzle, int index)
        {
            var rowIdx = index / puzzle.Size;
            var colIdx = index % puzzle.Size;

            if (IsAlreadySet(puzzle, rowIdx, colIdx))
                return Solve(out finalPuzzle, puzzle, index+1);

            foreach(var value in PossibleValues(puzzle, rowIdx, colIdx))
            {
                if (!PlaceNumber(puzzle, value, rowIdx, colIdx)) continue;

                if (IsDone(puzzle, rowIdx, colIdx))
                {
                    finalPuzzle = puzzle;
                    if (puzzle.Solved) return true;
                }
                else
                {
                    var newPuzzle = new Puzzle(puzzle);
                    if (Solve(out finalPuzzle, newPuzzle, index+1))
                    {
                        return true;
                    }

                }
            }

            finalPuzzle = new Puzzle(puzzle.Size);
            return false;
        }

        private static bool IsAlreadySet(Puzzle puzzle, int rowIdx, int colIdx)
        {
            return (puzzle.GetNumber(rowIdx, colIdx) != 0);
        }

        private static bool IsDone(Puzzle puzzle, int rowIdx, int colIdx)
        {
            return (rowIdx == puzzle.Size-1 && colIdx == puzzle.Size-1);
        }

        private static IEnumerable<int> PossibleValues(Puzzle puzzle, int rowIdx, int colIdx)
        {
            var set = new HashSet<int>(Enumerable.Range(1, puzzle.Size));
            set.RemoveWhere(x => puzzle.GetRow(rowIdx).Contains(x));
            set.RemoveWhere(x => puzzle.GetColumn(colIdx).Contains(x));
            set.RemoveWhere(x => puzzle.GetSquare(puzzle.GetSquareIndex(rowIdx, colIdx)).Contains(x));
            return set.ToList();
        }
    }
}