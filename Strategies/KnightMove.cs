using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckMate.Moves
{
    public class KnightMove : IMoveBehavior
    {
        /// <summary>
        /// A knight can only move in L-shape pattern
        /// </summary>
        /// <param name="source"></param>
        /// <param name="dest"></param>
        /// <returns></returns>
        public bool IsValidMove(Cell source, Cell dest)
        {
            int dy = Math.Abs(source.Position.Rank - dest.Position.Rank);
            int dx = Math.Abs(source.Position.File - dest.Position.File);

            if (source.Piece != null && dest.Piece != null)
                if (source.Piece.Color == dest.Piece.Color) return false;

            return ((dx + dy == 3) && (dx != 0) && (dy != 0)) ? true : false;
        }
    }
}
