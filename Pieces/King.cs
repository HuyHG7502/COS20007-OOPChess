using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckMate.Moves;

namespace CheckMate.Pieces
{
    public class King : Piece
    {
        public King(ChessColor color, Cell cell)
            : base(PieceType.King, color, cell)
        {
            MoveBehavior = new KingMove();
        }
    }
}
