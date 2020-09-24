using System;
using System.Collections.Generic;
using System.Linq;

using Xunit;

namespace QueenProblem
{
    public class BoardTest
    {
        private readonly Board board;

        public BoardTest()
        {
            board = new Board();
        }

        [Fact]
        public void TestNoQueen()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => board.Solve(0));
        }

        [Fact]
        public void TestTwoQueens()
        {
            Assert.Null(board.Solve(2));
        }

        [Fact]
        public void TestThreeQueens()
        {
            Assert.Null(board.Solve(3));
        }

        [Theory]
        [InlineData(1, 1)]
        [InlineData(2, 4)]
        [InlineData(10, 5)]
        [InlineData(4, 6)]
        [InlineData(40, 7)]
        [InlineData(92, 8)]
        [InlineData(352, 9)]
        [InlineData(724, 10)]
        public void TestFourQueens(int solutions, byte size)
        {
            Assert.Equal(solutions, board.Solve(size).Count);
        }
    }
}
