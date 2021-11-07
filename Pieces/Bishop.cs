using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckMate.Moves;

namespace CheckMate.Pieces
{
    public class Bishop : Piece
    {
        public Bishop(ChessColor color, Cell cell)
            : base(PieceType.Bishop, color, cell)
        {
            MoveBehavior = new BishopMove();
        }
    }
}
