using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckMate.Moves;

namespace CheckMate.Pieces
{
    public class Knight : Piece
    {
        public Knight(ChessColor color, Cell cell)
            : base(PieceType.Knight, color, cell)
        {
            MoveBehavior = new KnightMove();
        }
    }
}
