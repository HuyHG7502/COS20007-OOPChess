using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckMate.Pieces;

namespace CheckMate.Moves
{
    public class PawnMove : IMoveBehavior
    {
        /// <summary>
        /// A pawn can only move forward one step (two steps if first move)
        /// </summary>
        /// <param name="source"></param>
        /// <param name="dest"></param>
        /// <returns></returns>
        public bool IsValidMove(Cell source, Cell dest)
        {
            int dy = (dest.Position.Rank - source.Position.Rank);
            int dx = (dest.Position.File - source.Position.File);

            if (source.Piece != null && dest.Piece != null)
                if (source.Piece.Color == dest.Piece.Color) return false;

            Pawn pawn = (Pawn) source.Piece;

            bool upDir;
            if (pawn.Color == ChessColor.White)
                upDir = true;
            else
                upDir = false;

            if (dest.Piece == null)
            {
                if (dx != 0)
                    return false;

                if (pawn.IsFirstMove)
                {
                    if (Math.Abs(dy) == 1 || Math.Abs(dy) == 2)
                    {
                        if ((upDir && dy > 0) || (!upDir && dy < 0))
                        {
                            pawn.IsFirstMove = false;
                            return true;
                        }
                    }
                }
                else
                {
                    if (Math.Abs(dy) == 1)
                    {
                        if ((upDir && dy > 0) || (!upDir && dy < 0)) return true;
                    }
                }
            }
            else
            {
                if (Math.Abs(dx) == 1 && Math.Abs(dy) == 1)
                {
                    if ((upDir && dy > 0) || (!upDir && dy < 0)) return true;
                }
            }

            return false;
        }
    }
}
