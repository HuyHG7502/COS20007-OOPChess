using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckMate
{
    /// <summary>
    /// GameObject knows its color, position, and how to draw itself
    /// </summary>
    public abstract class GameObject
    {
        private ChessColor _color;
        private Position   _pos;

        public GameObject(ChessColor color, Position pos)
        {
            _color = color;
            _pos   = pos;
        }

        public ChessColor Color
        {
            get => _color;
            set => _color = value;
        }

        public Position Position
        {
            get => _pos;
            set => _pos = value;
        }

        public string PositionName
        {
            get => _pos.Name;
        }

        public abstract void Draw();
    }
}
