using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SplashKitSDK;

namespace CheckMate
{
    public abstract class Cell : GameObject
    {
        private   bool      _isHighlight;
        private   Piece     _piece;
        private   Rectangle _block;
        protected Color     _blockColor;
        
        /// <summary>
        /// Cell constructor
        /// </summary>
        /// <param name="color"></param>
        /// <param name="pos"></param>
        public Cell(ChessColor color, Position pos)
            : base(color, pos)
        {
            _isHighlight = false;
            _block       = SplashKit.RectangleFrom(((int) Position.File - 1) * Constant.CellSize, (Position.Rank - 1) * Constant.CellSize, Constant.CellSize, Constant.CellSize);
        }

        /// <summary>
        /// Draw cell on the screen. If the cell is currently chosen, the color is changed to Gold
        /// </summary>
        public override void Draw()
        {
            Color _outline;

            if (IsHighlight)
                _outline = Constant.Highlight;
            else
                _outline = _blockColor;

            SplashKit.FillRectangle(_blockColor, Block);
            SplashKit.FillRectangle(_outline,    Block);
        }

        // 
        public bool IsHighlight
        {
            get => _isHighlight;
            set => _isHighlight = value;
        }

        public Piece Piece
        {
            get => _piece;
            set => _piece = value;
        }
        
        public Rectangle Block
        {
            get => _block; 
        }

        public bool IsAt(Point2D pt)
        {
            return SplashKit.PointInRectangle(pt, _block);
        }
    }

    /// <summary>
    /// BlackCell is a child class of Cell
    /// </summary>
    public class BlackCell : Cell
    {
        public BlackCell(Position pos)
            : base(ChessColor.Black, pos)
        {
            _blockColor = Constant.Black;
        }
    }

    /// <summary>
    /// WhiteCell is a child class of Cell
    /// </summary>
    public class WhiteCell : Cell
    {
        public WhiteCell(Position pos)
            : base(ChessColor.White, pos)
        {
            _blockColor = Constant.White;
        }
    }

    [TestFixture]
    public class TestCell
    {
        Cell cell1, cell2;
        
        [SetUp]
        public void SetUp()
        {
            cell1 = new BlackCell(new Position());
            cell2 = new WhiteCell(new Position(File.C, 2));
        }

        [Test]
        public void TestCellColor()
        {
            Assert.AreEqual(ChessColor.Black, cell1.Color);
            Assert.AreEqual(ChessColor.White, cell2.Color);
        }

        [Test]
        public void TestCellPosition()
        {
            Assert.AreEqual("00", cell1.Position.Name);
            Assert.AreEqual("C2", cell2.Position.Name);
        }

        [Test]
        public void TestBlockPosition()
        {
            Assert.AreEqual(160, cell2.Block.X);
            Assert.AreEqual(80,  cell2.Block.Y);
        }
    }
}
