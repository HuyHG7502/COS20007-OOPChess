using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckMate.Factories
{
    public interface CellFactory
    {
        public abstract Cell GetCell(Position pos);
    }

    public class BlackCellFactory : CellFactory
    {
        public Cell GetCell(Position pos)
        {
            return new BlackCell(pos);
        }
    }

    public class WhiteCellFactory : CellFactory
    {
        public Cell GetCell(Position pos)
        {
            return new WhiteCell(pos);
        }
    }
}
