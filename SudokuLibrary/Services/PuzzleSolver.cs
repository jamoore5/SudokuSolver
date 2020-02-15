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
        private HashSet<int>[,] _possibilities;

        public PuzzleSolver(Puzzle puzzle)
        {
            _puzzle = puzzle;
            _possibilities = new HashSet<int>[_puzzle.Size,_puzzle.Size];
        }

        public bool Solve()
        {
            PopulatePossibilities();
            return (_puzzle.Solved);
        }

        private void PopulatePossibilities()
        {

            foreach (var rowIdx in Enumerable.Range(0, _puzzle.Size))
            {
                foreach (var colIdx in Enumerable.Range(0, _puzzle.Size))
                {
                    if (_puzzle.GetNumber(rowIdx, colIdx) != 0) continue;

                    var set = Enumerable.Range(1, _puzzle.Size ).ToHashSet();
                    set.RemoveWhere(value => ValueInRowColumnOrSquare(rowIdx, colIdx, value));

                    UpdatePuzzleAndPossibilities(set, rowIdx, colIdx);
                }
            }
        }

        private bool ValueInRowColumnOrSquare(int rowIdx, int colIdx, int value)
        {
            return ValueInRow(rowIdx, value) ||
                ValueInColumn(colIdx, value) ||
                ValueInSquare(rowIdx, colIdx, value);
        }

        private bool ValueInRow(int rowIdx, int value)
        {
            return _puzzle.GetRow(rowIdx).Contains(value);
        }

        private bool ValueInColumn(int colIdx, int value)
        {
            return _puzzle.GetColumn(colIdx).Contains(value);
        }

        private bool ValueInSquare(int rowIdx, int colIdx, int value)
        {
            var sqrIdx = _puzzle.GetSquareIndex(rowIdx, colIdx);
            return _puzzle.GetSquare(sqrIdx).Contains(value);
        }

        private void UpdatePuzzleAndPossibilities(HashSet<int> set, int rowIdx, int colIdx)
        {
            if (set.Count() != 1)
            {
                _possibilities[rowIdx, colIdx] = set;
                return;
            }
            var value = set.ToList().First();
            _puzzle.SetNumber(set.ToList().First(), rowIdx, colIdx);
            UpdatePossibilities(value, rowIdx, colIdx);
            set.RemoveWhere(x => x == value);
            _possibilities[rowIdx, colIdx] = null;
        }

        private void UpdatePossibilities(int value, int rowIdx, int colIdx)
        {
            UpdateRowPossibilities(rowIdx, value);
            UpdateColumnPossibilities(colIdx, value);
            UpdateSquarePossibilities(rowIdx, colIdx, value);
        }

        private void UpdateRowPossibilities(int rowIdx, int value)
        {
            foreach (var colIdx in Enumerable.Range(0, _puzzle.Size))
            {
                var set = _possibilities[rowIdx, colIdx];
                if (set == null) continue;
                set.RemoveWhere(x => x == value);
                UpdatePuzzleAndPossibilities(set, rowIdx, colIdx);
            }
        }

        private void UpdateColumnPossibilities(int colIdx, int value)
        {
            foreach (var rowIdx in Enumerable.Range(0, _puzzle.Size))
            {
                var set = _possibilities[rowIdx, colIdx];
                if (set == null) continue;
                set.RemoveWhere(x => x == value);
                UpdatePuzzleAndPossibilities(set, rowIdx, colIdx);
            }
        }

        private void UpdateSquarePossibilities(int rowIdx, int colIdx, int value)
        {
            var sqrIdx = _puzzle.GetSquareIndex(rowIdx, colIdx);

            var squareSize = (int) Math.Sqrt(_puzzle.Size);

            var quotient = sqrIdx / squareSize;
            var remainder = sqrIdx % squareSize;

            var rowScale = quotient * squareSize;
            var colScale = remainder * squareSize;

            for (var i = 0; i < squareSize; i++)
            {
                for (var j = 0; j < squareSize; j++)
                {
                    var set = _possibilities[rowScale+i, colScale+j];
                    if (set == null) continue;
                    set.RemoveWhere(x => x == value);
                    UpdatePuzzleAndPossibilities(set, rowScale+i, colScale+j);
                }
            }

        }
    }
}