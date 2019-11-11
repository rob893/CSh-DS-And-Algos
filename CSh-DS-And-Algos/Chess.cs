using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace CSh_DS_And_Algos
{
    public class ChessPiece
    {
        public Position Position { get; set; }
        public ChessPieceType Type { get; }
        public ChessPieceColor Color { get; }
        public bool HasMoved { get; set; }

        private readonly IMovementStrategy movement;


        public ChessPiece(ChessPieceColor color, ChessPieceType type, Position position, IMovementStrategy movementStrategy)
        {
            Color = color;
            Type = type;
            Position = position;
            movement = movementStrategy;
        }

        public IEnumerable<ChessPiece> PiecesCanTake(IEnumerable<ChessPiece> otherPieces)
        {
            return movement.PiecesInRangeToTake(this, otherPieces);
        }
    }

    public interface IMovementStrategy
    {
        IEnumerable<ChessPiece> PiecesInRangeToTake(ChessPiece me, IEnumerable<ChessPiece> others);
    }

    public class PawnMovementStrategy : IMovementStrategy
    {
        public IEnumerable<ChessPiece> PiecesInRangeToTake(ChessPiece me, IEnumerable<ChessPiece> others)
        {
            var pieces = new List<ChessPiece>();

            foreach (var other in others)
            {
                if (other.Color == me.Color)
                {
                    continue;
                }

                if (me.Color == ChessPieceColor.White)
                {
                    if (other.Position.Y == me.Position.Y + 1 && Math.Abs(other.Position.X - me.Position.X) == 1)
                    {
                        pieces.Add(other);
                    }
                }
                else
                {
                    if (other.Position.Y == me.Position.Y - 1 && Math.Abs(other.Position.X - me.Position.X) == 1)
                    {
                        pieces.Add(other);
                    }
                }
            }

            return pieces;
        }
    }

    public class KnightMovementStrategy : IMovementStrategy
    {
        public IEnumerable<ChessPiece> PiecesInRangeToTake(ChessPiece me, IEnumerable<ChessPiece> others)
        {
            var pieces = new List<ChessPiece>();

            foreach (var other in others)
            {
                if (other.Color == me.Color)
                {
                    continue;
                }

                if (Math.Abs(other.Position.X - me.Position.X) == 2)
                {
                    if (Math.Abs(other.Position.Y - me.Position.Y) == 1)
                    {
                        pieces.Add(other);
                    }
                }
                else if (Math.Abs(other.Position.X - me.Position.X) == 1)
                {
                    if (Math.Abs(other.Position.Y - me.Position.Y) == 2)
                    {
                        pieces.Add(other);
                    }
                }
            }

            return pieces;
        }
    }

    public class RookMovementStrategy : IMovementStrategy
    {
        public IEnumerable<ChessPiece> PiecesInRangeToTake(ChessPiece me, IEnumerable<ChessPiece> others)
        {
            var pieces = new List<ChessPiece>();

            foreach (var other in others)
            {
                if (other.Color == me.Color)
                {
                    continue;
                }

                if (me.Position.X == other.Position.X || me.Position.Y == other.Position.Y)
                {
                    pieces.Add(other);
                }
            }

            return pieces;
        }
    }

    public struct Position : IEquatable<Position>
    {
        public int X { get; set; }
        public int Y { get; set; }


        public Position(int x, int y)
        {
            if (x < 0 || x > 7 || y < 0 || y > 7)
            {
                throw new ArgumentException("x and y must be greater than 0 and less than 8");
            }

            X = x;
            Y = y;
        }

        public bool Equals([AllowNull] Position other)
        {
            return other.X == X && other.Y == Y;
        }
    }

    public class ChessPieceFactory
    {
        public static ChessPiece BuildChessPiece(ChessPieceColor color, ChessPieceType type, Position position)
        {
            switch (type)
            {
                case ChessPieceType.Knight:
                    return new ChessPiece(color, type, position, new KnightMovementStrategy());
                case ChessPieceType.Rook:
                    return new ChessPiece(color, type, position, new RookMovementStrategy());
                default:
                    throw new Exception("Invalid type");
            }
        }
    }

    public enum ChessPieceType
    {
        Knight,
        Rook,
        Queen,
        King,
        Pawn,
        Bishop
    }

    public enum ChessPieceColor
    {
        Black,
        White
    }
}