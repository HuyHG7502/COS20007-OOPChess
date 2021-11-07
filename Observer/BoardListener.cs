using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace CheckMate
{
    /// <summary>
    /// BoardListener handles the MouseClicks when Player attemps to move a Chess piece
    /// </summary>
    public class BoardListener : IKeyListener
    {
        private Board  _board;
        private Piece  _piece;
        private Cell   _newCell;

        private ChessColor _turn;

        public BoardListener(Board board)
        {
            _board   = board;
            _turn    = ChessColor.White;
        }

        public void OnMouseClick(MouseButton mouse)
        {
            _board.ResetColor();
            if (mouse == MouseButton.LeftButton)
            {
                Piece tmp = _board.GetPieceFromPosition(SplashKit.MousePosition());

                if (tmp != null &&
                    tmp.Color == _turn)
                {
                    _piece = tmp;
                    _piece.Cell.IsHighlight = true;
                }
            }

            if (mouse == MouseButton.RightButton && _piece != null)
            {
                _newCell = _board.GetCellFromPosition(SplashKit.MousePosition());

                if (_piece.MoveBehavior.IsValidMove(_piece.Cell, _newCell))
                {
                    _newCell.IsHighlight = true;
                    MovePiece();
                    Reset();
                }
            }
        }

        public void MovePiece()
        {
            if (_newCell.Piece != null)
            {
                _newCell.Piece.IsCaptured = true;
                _newCell.Piece.Cell = null;
                RemoveKilledPieces();
            }
            _piece.Cell = _newCell;
            _turn = (_turn == ChessColor.White) ? ChessColor.Black : ChessColor.White;
        }

        public void Reset()
        {
            _piece  = null;
            _newCell = null;
        }

        public void RemoveKilledPieces()
        {
            List<Piece> _killedPieces = new List<Piece>();

            foreach (Piece p in _board.Pieces)
                if (p.IsCaptured)
                {
                    _killedPieces.Add(p);
                    _board.Pieces.Remove(p);
                }
        }
    }
}
