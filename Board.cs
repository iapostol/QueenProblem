using System;
using System.Collections.Generic;

namespace QueenProblem
{
    public class Board
    {
        private byte size;
        private bool[,] positions;

        private List<bool[,]> solutions;

        public List<bool[,]> Solve(byte size)
        {
            if (size == 0)
                throw new ArgumentOutOfRangeException();

            if (size == 2 || size == 3)
                return null;

            this.size = size;

            InitializeBoard();

            FindSolutions(0);

            return solutions;
        }

        private void InitializeBoard()
        {
            positions = new bool[size, size];
            solutions = new List<bool[,]>();
        }

        private bool FindSolutions(int col)
        {
            if (col == size)
            {
                solutions.Add((bool[,])positions.Clone());
                return true;
            }

            bool found = false;

            for (int i = 0; i < size; i++)
            {
                if (CanPlaceAt(i, col))
                {
                    positions[i, col] = true;

                    found = FindSolutions(col + 1);

                    positions[i, col] = false;
                }
            }

            return found;
        }

        private bool CanPlaceAt(int row, int col)
        {
            int i, j;

            for (i = 0; i < col; i++)
                if (positions[row, i])
                    return false;

            for (i = row, j = col; i >= 0 && j >= 0; i--, j--)
                if (positions[i, j])
                    return false;

            for (i = row, j = col; j >= 0 && i < size; i++, j--)
                if (positions[i, j])
                    return false;

            return true;
        }
    }
}