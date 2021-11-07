using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckMate
{
    public class Game
    {
        private static Board  board;
        private InputManager  manager;
        private BoardListener boardListener;
        public Game()
        {
            board         = new Board();
            manager       = new InputManager();
            boardListener = new BoardListener(board);

            manager.Add(boardListener);
        }

        public void Draw()
        {
            board.DrawBoard();
        }

        public void ProcessEvents()
        {
            manager.CheckInput();
        }
    }
}
