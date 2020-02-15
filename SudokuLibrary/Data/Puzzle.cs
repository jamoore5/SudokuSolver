using System;
using System.Collections.Generic;
using System.Linq;
using SudokuLibrary.Services;

namespace SudokuLibrary.Data
{
    public class Puzzle
    {
        private readonly int[,] _puzzle;

        public int Size { get; }
        public bool Solved { get; private set; }
        public bool Valid { get; private set;}

        public Puzzle(int size)
        {
            Size = size;
            Solved = false;
            Valid = true;
            _puzzle = new int[Size,Size];
        }

        public void SetNumber(int value, int rowIdx, int colIdx)
        {
            _puzzle[rowIdx, colIdx] = value;
            Validate();
        }

        public int GetNumber(int rowIdx, int colIdx)
        {
            return _puzzle[rowIdx, colIdx];
        }

        private void Validate()
        {
            var validator = new PuzzleValidator(this);
            Solved = validator.Solved;
            Valid = validator.Valid;
        }

        public IEnumerable<int> GetRow(int index)
        {
            var row = new int[Size];

            for (var idx = 0; idx < Size; idx++)
            {
                row[idx] = _puzzle[index, idx];
            }

            return row;
        }

        public IEnumerable<int> GetColumn(int index)
        {
            var column = new int[Size];

            for (var idx = 0; idx < Size; idx++)
            {
                column[idx] = _puzzle[idx, index];
            }

            return column;
        }

        public IEnumerable<int> GetSquare(int index)
        {
            var square = new int[Size];
            var squareSize = (int) Math.Sqrt(Size);
            var squareIdx = 0;

            var quotient = index / squareSize;
            var remainder = index % squareSize;

            var rowScale = quotient * squareSize;
            var colScale = remainder * squareSize;

            for (var i = 0; i < squareSize; i++)
            {
                for (var j = 0; j < squareSize; j++)
                {
                    square[squareIdx] = (_puzzle[rowScale+i, colScale+j]);
                    squareIdx++;
                }
            }

            return square;
        }

        public int GetSquareIndex(int rowIdx, int colIdx)
        {
            var squareSize = (int) Math.Sqrt(Size);

            return squareSize * (rowIdx / squareSize) + (colIdx / squareSize);
        }

        public override string ToString()
        {
            var writer = new PuzzleStringWriter(this);
            var puzzleString = writer.Write();
            return puzzleString;
        }
    }
}