using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckMate.Moves
{
    public class KingMove : IMoveBehavior
    {
        /// <summary>
        /// A king can move in all directions, but only one step at a time
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

            if (dx == 1 && (dy == 1 || dy == 0))
                return true;
            if (dy == 1 && (dx == 1 || dx == 0))
                return true;
            return false;
        }
    }
}
