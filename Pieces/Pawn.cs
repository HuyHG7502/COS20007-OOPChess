using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckMate.Moves;

namespace CheckMate.Pieces
{
    public class Pawn : Piece
    {
        private bool _isFirstMove;

        public Pawn(ChessColor color, Cell cell)
            : base(PieceType.Pawn, color, cell)
        {
            _isFirstMove = true;
            MoveBehavior = new PawnMove();
        }
        
        public bool IsFirstMove
        {
            get => _isFirstMove;
            set => _isFirstMove = value;
        }
    }
}
