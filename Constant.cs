using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace CheckMate
{
    /// <summary>
    /// A Chessboard is divided into Files (columns from A - H) and Ranks (rows from 1 - 8)
    /// </summary>
    public enum File
    {
        A = 1, B, C, D, E, F, G, H
    }

    /// <summary>
    /// There are two primary colors: Black and White
    /// </summary>
    public enum ChessColor
    {
        Black,
        White
    }

    /// <summary>
    /// There are 8 types of chess pieces
    /// </summary>
    public enum PieceType
    {
        King,
        Queen,
        Bishop,
        Knight,
        Rook,
        Pawn
    }

    /// <summary>
    /// Keeps records of all constants to be used in this program
    /// </summary>
    public class Constant
    {
        // Window Dimensions
        public static int WinWidth  = 640;
        public static int WinHeight = 640;

        // Cell Constants
        public static int CellSize = 80;
        public static int CellNum  = 8;

        // Cell Colors for GUI
        public static Color Black     = Color.Peru;
        public static Color White     = Color.Beige;
        public static Color Highlight = Color.Gold;

        // Piece Sizes
        public static int PieceSize = 40;
        public static int PieceLeft = 20;
        public static int PieceTop  = 20;

        public static int Timer = 30;
    }
}
