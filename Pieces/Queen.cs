using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckMate.Moves;

namespace CheckMate.Pieces
{
    public class Queen : Piece
    {
        public Queen(ChessColor color, Cell cell)
            : base(PieceType.Queen, color, cell)
        {
            MoveBehavior = new QueenMove();
        }
    }
}
