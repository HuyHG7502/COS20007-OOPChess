using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckMate.Moves
{
    /// <summary>
    /// Interface to implement strategy pattern for Chess moves
    /// </summary>
    public interface IMoveBehavior
    {
        public bool IsValidMove(Cell source, Cell dest);
    }
}
