using System;
using System.Collections.Generic;
using System.Linq;
using CSh_DS_And_Algos;
using Xunit;

namespace CSh_DS_And_Algos.Test
{
    public class ChessTests
    {
        [Fact]
        public void CanKnightTakePieces()
        {
            //Arrange
            var knight = ChessPieceFactory.BuildChessPiece(ChessPieceColor.White, ChessPieceType.Knight, new Position(0, 0));
            var other1 = ChessPieceFactory.BuildChessPiece(ChessPieceColor.Black, ChessPieceType.Rook, new Position(2, 1));
            var other2 = ChessPieceFactory.BuildChessPiece(ChessPieceColor.Black, ChessPieceType.Rook, new Position(5, 5));

            var pieces = new List<ChessPiece> { knight, other1, other2 };

            //Act
            var inRangeOfKnight = knight.PiecesCanTake(pieces).ToList();

            //Assert
            Assert.Contains(other1, inRangeOfKnight);
            Assert.DoesNotContain(other2, inRangeOfKnight);
            Assert.DoesNotContain(knight, inRangeOfKnight);
            Assert.Single(inRangeOfKnight);
        }
    }
}
