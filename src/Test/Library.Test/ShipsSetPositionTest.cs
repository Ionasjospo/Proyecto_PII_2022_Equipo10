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
        public void DestroyerSetVerticalPosition()
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

    }
}





