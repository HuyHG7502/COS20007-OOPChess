using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckMate
{
    public class Player
    {
        private string      _name;
        private bool        _turn;
        private ChessColor  _color;
        private List<Piece> _pieces;

        public Player(string name, ChessColor color)
        {
            _turn  = false;
            _name  = name;
            _color = color;
        }

        public List<Piece> SetPieces
        {
            get => _pieces;
            set => _pieces = value;
        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public bool Turn
        {
            get => _turn;
            set => _turn = value;
        }

        public ChessColor Color
        {
            get => _color;
            set => _color = value;
        }
    }
}
