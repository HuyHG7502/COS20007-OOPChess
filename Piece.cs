using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckMate.Pieces;
using CheckMate.Moves;
using SplashKitSDK;
using NUnit.Framework;

namespace CheckMate
{
    /// <summary>
    /// The basic component of Chess game
    /// </summary>
    public abstract class Piece : GameObject
    {
        private   bool          _isCaptured;
        protected Cell          _cell;
        protected PieceType     _type;
        protected IMoveBehavior _moveBehavior;

        /// <summary>
        /// Load Bitmap for each specific type of chess piece
        /// </summary>
        /// <returns></returns>
        protected Bitmap Bitmap()
        {
            switch (_type, Color)
            {
                case (PieceType.King, ChessColor.Black):
                    return SplashKit.LoadBitmap("BlackKing", "BlackKing.png");
                case (PieceType.King, ChessColor.White):
                    return SplashKit.LoadBitmap("WhiteKing", "WhiteKing.png");

                case (PieceType.Queen, ChessColor.Black):
                    return SplashKit.LoadBitmap("BlackQueen", "BlackQueen.png");
                case (PieceType.Queen, ChessColor.White):
                    return SplashKit.LoadBitmap("WhiteQueen", "WhiteQueen.png");

                case (PieceType.Bishop, ChessColor.Black):
                    return SplashKit.LoadBitmap("BlackBishop", "BlackBishop.png");
                case (PieceType.Bishop, ChessColor.White):
                    return SplashKit.LoadBitmap("WhiteBishop", "WhiteBishop.png");

                case (PieceType.Knight, ChessColor.Black):
                    return SplashKit.LoadBitmap("BlackKnight", "BlackKnight.png");
                case (PieceType.Knight, ChessColor.White):
                    return SplashKit.LoadBitmap("WhiteKnight", "WhiteKnight.png");

                case (PieceType.Rook, ChessColor.Black):
                    return SplashKit.LoadBitmap("BlackRook", "BlackRook.png");
                case (PieceType.Rook, ChessColor.White):
                    return SplashKit.LoadBitmap("WhiteRook", "WhiteRook.png");

                case (PieceType.Pawn, ChessColor.Black):
                    return SplashKit.LoadBitmap("BlackPawn", "BlackPawn.png");
                case (PieceType.Pawn, ChessColor.White):
                    return SplashKit.LoadBitmap("WhitePawn", "WhitePawn.png");
            }
            return null;
        }

        /// <summary>
        /// Piece constructor takes in Cell position as Piece position
        /// </summary>
        /// <param name="type"></param>
        /// <param name="color"></param>
        /// <param name="cell"></param>
        public Piece(PieceType type, ChessColor color, Cell cell)
            : base(color, cell.Position)
        {
            _type       = type;
            _cell       = cell;
            _isCaptured = false;

            _cell.Piece = this;
        }

        /// <summary>
        /// Draw piece on the board
        /// </summary>
        public override void Draw()
        {
            if (Cell != null)
                SplashKit.DrawBitmap(Bitmap(), Cell.Block.X + Bitmap().Width / 2, Cell.Block.Y + Bitmap().Height / 2);
        }

        public PieceType Type
        {
            get => _type;
            set => _type = value;
        }

        public Cell Cell
        {
            get => _cell;
            set
            {
                _cell.Piece = null;
                _cell = value;
                if (_cell != null) _cell.Piece = this;
            }
        }

        public bool IsCaptured
        {
            get => _isCaptured;
            set => _isCaptured = value;
        }

        public string Name
        {
            get => Color + " " + Type;
        }

        public IMoveBehavior MoveBehavior
        {
            get => _moveBehavior;
            set => _moveBehavior = value;
        }
    }

    [TestFixture]
    public class TestPiece
    {
        Piece piece;
        Cell  cell;

        [SetUp]
        public void SetUp()
        {
            cell  = new BlackCell(new Position(File.B, 2));
            piece = new King(ChessColor.Black, cell);
        }

        [Test]
        public void TestPieceColor()
        {
            Assert.AreEqual(ChessColor.Black, piece.Color);
        }

        [Test]
        public void TestPieceType()
        {
            Assert.AreEqual(PieceType.King, piece.Type);
            Assert.AreEqual("Black King", piece.Name);
        }

        [Test]
        public void TestPieceCell()
        {
            Assert.AreEqual("B2", piece.Cell.Position.Name);
            Assert.AreEqual(piece, cell.Piece);
        }
    }
}
