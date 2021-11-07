using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckMate.Factories;
using CheckMate.Pieces;
using SplashKitSDK;
using NUnit.Framework;

namespace CheckMate
{
    public class Board
    {
        private Dictionary<string, Cell> _cells;
        private List<Piece>  _whiteSet, _blackSet;
        private CellFactory  _cellFactory;
        private PieceFactory _pieceFactory;

        /// <summary>
        /// Constructor for a Board: Create Cells and Set Pieces onto Cells
        /// </summary>
        public Board()
        {
            CreateCells();
            CreateWhiteSet();
            CreateBlackSet();
        }

        /// <summary>
        /// Draw the board onto screen
        /// </summary>
        public void DrawBoard()
        {
            foreach (Cell c in Cells.Values)
                c.Draw();
            foreach (Piece p in Pieces)
                p.Draw();
        }
        
        /// <summary>
        /// Create Cells for a Chessboard in form of Dictionary. The key is the position itself for easy retrieval of Cell values
        /// </summary>
        public void CreateCells()
        {
            _cells = new Dictionary<string, Cell>();

            foreach (File file in (File[]) Enum.GetValues(typeof(File)))
                for (int rank = 1; rank <= 8; rank++)
                {
                    // Odd sum of rank and file produces a black cell
                    if ((rank + (int) file) % 2 == 0)
                        _cellFactory = new BlackCellFactory();
                    // Even sum produces a white cell
                    else
                        _cellFactory = new WhiteCellFactory();

                    // Call the cellFactory to create cells
                    Cell cell = _cellFactory.GetCell(new Position(file, rank));
                    
                    _cells.Add(cell.Position.Name, cell);
                }
        }

        /// <summary>
        /// Create White and Black piecesets
        /// </summary>
        public void CreateWhiteSet()
        {
            _whiteSet     = new List<Piece>();
            _pieceFactory = new WhitePieceFactory();
            CreatePieces(_whiteSet, 1, 2);
        }

        public void CreateBlackSet()
        {
            _blackSet     = new List<Piece>();
            _pieceFactory = new BlackPieceFactory();
            CreatePieces(_blackSet, 8, 7);
        }

        /// <summary>
        /// Set the pieces onto their initial positions
        /// </summary>
        /// <param name="set"></param>
        /// <param name="upperRank"></param>
        /// <param name="lowerRank"></param>
        public void CreatePieces(List<Piece> set, int upperRank, int lowerRank)
        {
            foreach (Cell c in Cells.Values)
                if (c.Position.Rank == lowerRank)
                    set.Add(_pieceFactory.GetPiece(PieceType.Pawn, c));

            set.Add(_pieceFactory.GetPiece(PieceType.Rook,   _cells["A" + upperRank]));
            set.Add(_pieceFactory.GetPiece(PieceType.Knight, _cells["B" + upperRank]));
            set.Add(_pieceFactory.GetPiece(PieceType.Bishop, _cells["C" + upperRank]));
            set.Add(_pieceFactory.GetPiece(PieceType.Queen,  _cells["D" + upperRank]));
            set.Add(_pieceFactory.GetPiece(PieceType.King,   _cells["E" + upperRank]));
            set.Add(_pieceFactory.GetPiece(PieceType.Bishop, _cells["F" + upperRank]));
            set.Add(_pieceFactory.GetPiece(PieceType.Knight, _cells["G" + upperRank]));
            set.Add(_pieceFactory.GetPiece(PieceType.Rook,   _cells["H" + upperRank]));
        }

        public Dictionary<string, Cell> Cells
        {
            get => _cells;
        }

        public List<Piece> Pieces
        {
            get
            {
                List<Piece> _pieces = new List<Piece>();
                _pieces.AddRange(_whiteSet);
                _pieces.AddRange(_blackSet);
                return _pieces;
            }
        }

        /// <summary>
        /// Return a cell at the current user mouse position
        /// </summary>
        /// <param name="pt"></param>
        /// <returns></returns>
        public Cell GetCellFromPosition(Point2D pt)
        {
            foreach (Cell c in Cells.Values)
                if (c.IsAt(pt)) return c;
            return null;
        }

        /// <summary>
        /// Return a piece at the current user mouse position
        /// </summary>
        /// <param name="pt"></param>
        /// <returns></returns>
        public Piece GetPieceFromPosition(Point2D pt)
        {
            return GetCellFromPosition(pt).Piece; 
        }

        public void ResetColor()
        {
            foreach (Cell c in Cells.Values)
                c.IsHighlight = false;
        }
    }

    [TestFixture]
    public class TestBoard
    {
        Board board;

        [SetUp]
        public void SetUp()
        {
            board = new Board();
        }

        [Test]
        public void TestPieceOnCell()
        {
            King king = new King(ChessColor.White, new WhiteCell(new Position(File.D, 1)));

            Assert.AreEqual(king.Name, board.Cells["E1"].Piece.Name);
        }

        [Test]
        public void TestCellOfPiece()
        {
            King king = new King(ChessColor.White, new WhiteCell(new Position(File.D, 1)));

            Assert.AreEqual(king.Cell.Position.Name, board.Cells["E1"].Position.Name);
        }

        [Test]
        public void TestMovePiece()
        {
            King king = (King) board.Cells["E1"].Piece;

            king.Cell = board.Cells["E4"];
            Assert.AreEqual(board.Cells["E4"].Piece.Name, king.Name);
        }
    }
}