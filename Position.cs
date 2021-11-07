using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace CheckMate
{
    /// <summary>
    /// A Chess position consists of File and Rank (col vs row)
    /// </summary>
    public class Position
    {
        private File _file;
        private int  _rank;

        public Position()
        {

        }

        public Position(File file, int rank)
        {
            _file = file;
            _rank = rank;
        }

        public File File
        {
            get => _file;
            set => _file = value;
        }

        public int Rank
        {
            get => _rank;
            set => _rank = value;
        }

        public string Name
        {
            get => File.ToString() + Rank;
        }
    }

    [TestFixture]
    public class TestPosition
    {
        Position pos1, pos2, pos3;

        [SetUp]
        public void SetUp()
        {
            pos1 = new Position();
            pos2 = new Position();
            pos3 = new Position(File.A, 2);
        }

        [Test]
        public void TestPositionName()
        {
            pos1.File = File.B;
            pos1.Rank = 3;

            Assert.AreEqual("B3", pos1.Name);
            Assert.AreEqual("00", pos2.Name);
            Assert.AreEqual("A2", pos3.Name);
        }
    }
}
