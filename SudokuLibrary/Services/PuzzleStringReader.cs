using System;
using SudokuLibrary.Data;

namespace SudokuLibrary.Services
{
    public class PuzzleStringReader
    {
        private readonly string _str;

        public int Size => GetSize();
        private string[] Rows => GetRows();

        public PuzzleStringReader(string str)
        {
            _str = str;
        }

        public Puzzle Read()
        {
            if (InValidPuzzleString())
            {
                // TODO make an Invalid Puzzle Exception class 
                throw new Exception("The string does not represent a Sudoku puzzle");
            }
            var puzzle = new Puzzle(Size);

            for (var rowIdx = 0; rowIdx < Size; rowIdx++)
            {
                var row = Rows[rowIdx].Split(' ');
                for (var colIdx = 0; colIdx < Size; colIdx++)
                {
                    puzzle.SetNumber(int.Parse(row[colIdx]), rowIdx, colIdx);
                }
            }

            return puzzle;
        }

        private bool InValidPuzzleString()
        {
            return !ValidPuzzleString();
        }

        private bool ValidPuzzleString()
        {
            // TODO implement a regex expression to verify that the string is in the expected format 
            return true;
        }

        private string[] GetRows()
        {
            return _str.Split('\n');
        }

        private int GetSize()
        {
            return Rows[0].Split(' ').Length;
        }
    }
}