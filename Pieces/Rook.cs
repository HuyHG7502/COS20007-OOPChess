using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckMate.Moves;

namespace CheckMate.Pieces
{
    public class Rook : Piece
    {
        public Rook(ChessColor color, Cell cell)
            : base(PieceType.Rook, color, cell)
        {
            MoveBehavior = new RookMove();
        }
    }
}
