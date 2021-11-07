using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckMate.Moves
{
    public class QueenMove : IMoveBehavior
    {
        /// <summary>
        /// A queen can move in all directions
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

            if (dy == dx && dy != 0)
                return true;
            if (dy != 0 && dx == 0)
                return true;
            if (dy == 0 && dx != 0)
                return true;
            return false;
        }
    }
}
