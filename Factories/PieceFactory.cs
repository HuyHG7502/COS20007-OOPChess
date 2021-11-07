using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckMate.Pieces;

namespace CheckMate.Factories
{
    /// <summary>
    /// Interface for PieceFactory to create new Pieces
    /// </summary>
    public interface PieceFactory
    {
        public Piece GetPiece(PieceType type, Cell cell);
    }

    /// <summary>
    /// A PieceFactory dedicated to creating white Pieces
    /// </summary>
    public class WhitePieceFactory : PieceFactory
    {
        public Piece GetPiece(PieceType type, Cell cell)
        {
            ChessColor color = ChessColor.White;

            switch (type)
            {
                case PieceType.King:
                    return new King(color, cell);
                case PieceType.Queen:
                    return new Queen(color, cell);
                case PieceType.Bishop:
                    return new Bishop(color, cell);
                case PieceType.Knight:
                    return new Knight(color, cell);
                case PieceType.Rook:
                    return new Rook(color, cell);
                case PieceType.Pawn:
                    return new Pawn(color, cell);
            }

            return null;
        }
    }

    /// <summary>
    /// A PieceFactory dedicated to creating black Pieces
    /// </summary>
    public class BlackPieceFactory : PieceFactory
    {
        public Piece GetPiece(PieceType type, Cell cell)
        {
            ChessColor color = ChessColor.Black;

            switch (type)
            {
                case PieceType.King:
                    return new King(color, cell);
                case PieceType.Queen:
                    return new Queen(color, cell);
                case PieceType.Bishop:
                    return new Bishop(color, cell);
                case PieceType.Knight:
                    return new Knight(color, cell);
                case PieceType.Rook:
                    return new Rook(color, cell);
                case PieceType.Pawn:
                    return new Pawn(color, cell);
            }

            return null;
        }
    }
}
