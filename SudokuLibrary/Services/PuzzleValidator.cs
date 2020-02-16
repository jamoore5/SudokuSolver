using System;
using System.Collections.Generic;
using System.Linq;
using SudokuLibrary.Data;

namespace SudokuLibrary.Services
{
    public class PuzzleValidator
    {
        private readonly Puzzle _puzzle;
        private int _numberOfZeros;

        private bool _hasRan;
        private bool _valid;

        public bool Valid => IsValid();
        public bool Solved => IsSolved();

        public PuzzleValidator(Puzzle puzzle)
        {
            _puzzle = puzzle;
            _numberOfZeros = 0;
            _hasRan = false;
        }

        public bool ValidMove(int value, int rowIdx, int colIdx)
        {
            _puzzle.SetNumber(value,rowIdx, colIdx);
            var valid = !InvalidRow(_puzzle.GetRow(rowIdx)) &&
                        !InvalidColumn(_puzzle.GetColumn(colIdx)) &&
                        !InvalidSquare(_puzzle.GetSquare(_puzzle.GetSquareIndex(rowIdx, colIdx)));
            _puzzle.SetNumber(0,rowIdx, colIdx);
            return valid;
        }

        private bool IsValid()
        {
            if (_hasRan) return _valid;

            _valid = true;

            foreach (var idx in Enumerable.Range(0, _puzzle.Size))
            {
                if (InvalidRow(_puzzle.GetRow(idx)) || InvalidColumn(_puzzle.GetColumn(idx)) ||
                    InvalidSquare(_puzzle.GetSquare(idx)))
                {
                    _valid = false;
                    break;
                }
            }

            _hasRan = true;
            return _valid;
        }

        private bool IsSolved()
        {
            return Valid && _numberOfZeros == 0;
        }

        private bool InvalidRow(IEnumerable<int> row)
        {
            return InvalidElement(row);
        }

        private bool InvalidColumn(IEnumerable<int> column)
        {
            return InvalidElement(column);
        }

        private bool InvalidSquare(IEnumerable<int> square)
        {
            return InvalidElement(square);
        }

        private bool InvalidElement(IEnumerable<int> enumerable)
        {
            var element = enumerable.ToList();
            _numberOfZeros += element.RemoveAll(Zero);
            return element.Distinct().Count() != element.Count();
        }

        private static bool Zero(int num)
        {
            return num == 0;
        }
    }
}