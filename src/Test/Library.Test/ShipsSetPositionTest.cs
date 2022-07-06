using System;
using Library;
using NUnit.Framework;
using System.Collections.Generic;

namespace Library.Test
{
    public class ShipsSetPositionTest
    {
        [SetUp]
        public void Setup()
        {


        }

        [Test]
        public void SubmarineSetHorizontalPosition()
        {
            BoardWithShips boardWithShips = new BoardWithShips();
            boardWithShips.SetPosition(boardWithShips.Ship[0], 0, 0, "horizontal");


            string[,] expectedBoard = new string[10, 10];

            for (int x = 0; x < expectedBoard.GetLength(0); x++)
            {
                for (int y = 0; y < expectedBoard.GetLength(1); y++)
                {
                    expectedBoard[x, y] = "O";
                }
            }
            expectedBoard[0, 0] = "S";
            expectedBoard[0, 1] = "S";


            Assert.AreEqual(expectedBoard, boardWithShips.Ocean);
        }


        [Test]
        public void SubmarineSetVerticalPosition()
        {
            BoardWithShips boardWithShips = new BoardWithShips();
            boardWithShips.SetPosition(boardWithShips.Ship[0], 7, 7, "vertical");


            string[,] expectedBoard = new string[10, 10];

            for (int x = 0; x < expectedBoard.GetLength(0); x++)
            {
                for (int y = 0; y < expectedBoard.GetLength(1); y++)
                {
                    expectedBoard[x, y] = "O";
                }
            }
            expectedBoard[7, 7] = "S";
            expectedBoard[8, 7] = "S";


            Assert.AreEqual(expectedBoard, boardWithShips.Ocean);
        }

        [Test]
        public void BattleShipSetHorizontalPosition()
        {
            BoardWithShips boardWithShips = new BoardWithShips();
            boardWithShips.SetPosition(boardWithShips.Ship[1], 3, 1, "horizontal");


            string[,] expectedBoard = new string[10, 10];

            for (int x = 0; x < expectedBoard.GetLength(0); x++)
            {
                for (int y = 0; y < expectedBoard.GetLength(1); y++)
                {
                    expectedBoard[x, y] = "O";
                }
            }
            expectedBoard[3, 1] = "B";
            expectedBoard[3, 2] = "B";
            expectedBoard[3, 3] = "B";

            Assert.AreEqual(expectedBoard, boardWithShips.Ocean);
        }


        [Test]
        public void BattleShipSetVerticalPosition()
        {
            BoardWithShips boardWithShips = new BoardWithShips();
            boardWithShips.SetPosition(boardWithShips.Ship[1], 1, 6, "vertical");


            string[,] expectedBoard = new string[10, 10];

            for (int x = 0; x < expectedBoard.GetLength(0); x++)
            {
                for (int y = 0; y < expectedBoard.GetLength(1); y++)
                {
                    expectedBoard[x, y] = "O";
                }
            }
            expectedBoard[1, 6] = "B";
            expectedBoard[2, 6] = "B";
            expectedBoard[3, 6] = "B";

            Assert.AreEqual(expectedBoard, boardWithShips.Ocean);
        }

        [Test]
        public void DestroyerSetHorizontalPosition()
        {
            BoardWithShips boardWithShips = new BoardWithShips();
            boardWithShips.SetPosition(boardWithShips.Ship[2], 8, 6, "horizontal");


            string[,] expectedBoard = new string[10, 10];

            for (int x = 0; x < expectedBoard.GetLength(0); x++)
            {
                for (int y = 0; y < expectedBoard.GetLength(1); y++)
                {
                    expectedBoard[x, y] = "O";
                }
            }
            expectedBoard[8, 6] = "D";
            expectedBoard[8, 7] = "D";
            expectedBoard[8, 8] = "D";
            expectedBoard[8, 9] = "D";

            Assert.AreEqual(expectedBoard, boardWithShips.Ocean);
        }


        [Test]
        public void DestroyerSetVerticalPosition()
        {
            BoardWithShips boardWithShips = new BoardWithShips();
            boardWithShips.SetPosition(boardWithShips.Ship[2], 3, 4, "vertical");


            string[,] expectedBoard = new string[10, 10];

            for (int x = 0; x < expectedBoard.GetLength(0); x++)
            {
                for (int y = 0; y < expectedBoard.GetLength(1); y++)
                {
                    expectedBoard[x, y] = "O";
                }
            }
            expectedBoard[3, 4] = "D";
            expectedBoard[4, 4] = "D";
            expectedBoard[5, 4] = "D";
            expectedBoard[6, 4] = "D";

            Assert.AreEqual(expectedBoard, boardWithShips.Ocean);
        }

        [Test]
        public void AirCraftCarrierSetHorizontalPosition()
        {
            BoardWithShips boardWithShips = new BoardWithShips();
            boardWithShips.SetPosition(boardWithShips.Ship[3], 3, 1, "horizontal");


            string[,] expectedBoard = new string[10, 10];

            for (int x = 0; x < expectedBoard.GetLength(0); x++)
            {
                for (int y = 0; y < expectedBoard.GetLength(1); y++)
                {
                    expectedBoard[x, y] = "O";
                }
            }
            expectedBoard[3, 1] = "A";
            expectedBoard[3, 2] = "A";
            expectedBoard[3, 3] = "A";
            expectedBoard[3, 4] = "A";
            expectedBoard[3, 5] = "A";

            Assert.AreEqual(expectedBoard, boardWithShips.Ocean);
        }


        [Test]
        public void AirCraftCarrierSetVerticalPosition()
        {
            BoardWithShips boardWithShips = new BoardWithShips();
            boardWithShips.SetPosition(boardWithShips.Ship[3], 1, 5, "vertical");


            string[,] expectedBoard = new string[10, 10];

            for (int x = 0; x < expectedBoard.GetLength(0); x++)
            {
                for (int y = 0; y < expectedBoard.GetLength(1); y++)
                {
                    expectedBoard[x, y] = "O";
                }
            }
            expectedBoard[1, 5] = "A";
            expectedBoard[2, 5] = "A";
            expectedBoard[3, 5] = "A";
            expectedBoard[4, 5] = "A";
            expectedBoard[5, 5] = "A";

            Assert.AreEqual(expectedBoard, boardWithShips.Ocean);
        }

        [Test]
        public void AllShipsSetHorizontalPosition()
        {
            BoardWithShips boardWithShips = new BoardWithShips();
            boardWithShips.SetPosition(boardWithShips.Ship[0], 3, 5, "horizontal");
            boardWithShips.SetPosition(boardWithShips.Ship[0], 4, 2, "horizontal");
            boardWithShips.SetPosition(boardWithShips.Ship[0], 1, 1, "horizontal");
            boardWithShips.SetPosition(boardWithShips.Ship[0], 9, 0, "horizontal");


            string[,] expectedBoard = new string[10, 10];

            for (int x = 0; x < expectedBoard.GetLength(0); x++)
            {
                for (int y = 0; y < expectedBoard.GetLength(1); y++)
                {
                    expectedBoard[x, y] = "O";
                }
            }
            expectedBoard[3, 5] = "S";
            expectedBoard[3, 6] = "S";

            expectedBoard[4, 2] = "B";
            expectedBoard[4, 3] = "B";
            expectedBoard[4, 4] = "B";

            expectedBoard[1, 1] = "D";
            expectedBoard[1, 2] = "D";
            expectedBoard[1, 3] = "D";
            expectedBoard[1, 4] = "D";
            
            expectedBoard[9, 0] = "A";
            expectedBoard[9, 1] = "A";
            expectedBoard[9, 2] = "A";
            expectedBoard[9, 3] = "A";
            expectedBoard[9, 4] = "A";

            Assert.AreEqual(expectedBoard, boardWithShips.Ocean);
        }

        [Test]
        public void AllShipsSetVerticalPosition()
        {
            BoardWithShips bw = new BoardWithShips();
            bw.SetPosition(bw.Ship[0], 1, 1, "vertical");
            bw.SetPosition(bw.Ship[0], 2, 2, "vertical");
            bw.SetPosition(bw.Ship[0], 3, 3, "vertical");
            bw.SetPosition(bw.Ship[0], 4, 4, "vertical");
            


            string[,] expectedBoard = new string[10, 10];

            for (int x = 0; x < expectedBoard.GetLength(0); x++)
            {
                for (int y = 0; y < expectedBoard.GetLength(1); y++)
                {
                    expectedBoard[x, y] = "O";
                }
            }
            expectedBoard[1, 1] = "S";
            expectedBoard[2, 1] = "S";

            expectedBoard[2, 2] = "B";
            expectedBoard[3, 2] = "B";
            expectedBoard[4, 2] = "B";

            expectedBoard[3, 3] = "D";
            expectedBoard[4, 3] = "D";
            expectedBoard[5, 3] = "D";
            expectedBoard[6, 3] = "D";
            
            expectedBoard[4, 4] = "A";
            expectedBoard[5, 4] = "A";
            expectedBoard[6, 4] = "A";
            expectedBoard[7, 4] = "A";
            expectedBoard[8, 4] = "A";

            Assert.AreEqual(expectedBoard, bw.Ocean);
        }

        [Test]
        public void AllShipsDifferentPosition()
        {
            BoardWithShips boardWithShips = new BoardWithShips();
            boardWithShips.SetPosition(boardWithShips.Ship[0], 7, 9, "vertical");
            boardWithShips.SetPosition(boardWithShips.Ship[0], 0, 3, "horizontal");
            boardWithShips.SetPosition(boardWithShips.Ship[0], 6, 2, "vertical");
            boardWithShips.SetPosition(boardWithShips.Ship[0], 2, 4, "horizontal");


            string[,] expectedBoard = new string[10, 10];

            for (int x = 0; x < expectedBoard.GetLength(0); x++)
            {
                for (int y = 0; y < expectedBoard.GetLength(1); y++)
                {
                    expectedBoard[x, y] = "O";
                }
            }
            expectedBoard[7, 9] = "S";
            expectedBoard[8, 9] = "S";

            expectedBoard[0, 3] = "B";
            expectedBoard[0, 4] = "B";
            expectedBoard[0, 5] = "B";

            expectedBoard[6, 2] = "D";
            expectedBoard[7, 2] = "D";
            expectedBoard[8, 2] = "D";
            expectedBoard[9, 2] = "D";
            
            expectedBoard[2, 4] = "A";
            expectedBoard[2, 5] = "A";
            expectedBoard[2, 6] = "A";
            expectedBoard[2, 7] = "A";
            expectedBoard[2, 8] = "A";

            Assert.AreEqual(expectedBoard, boardWithShips.Ocean);
        }
    }
}





