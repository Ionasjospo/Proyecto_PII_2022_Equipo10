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
        public void ShipsSetPosition()
        {
            User juan = new User("Juan");
            juan.NewMatch(false);
            Match match =  MatchList.Instance.HistoricMatches[0];
            BoardWithShips boardShip = match.PlayerA1.BoardWithShips as BoardWithShips;
            boardShip.SetPosition(boardShip.Ship[0], 0, 0, "horizontal");
            // boardShip.SetPosition(boardShip.Ship[1], 0, 2, "horizontal");
            // boardShip.SetPosition(boardShip.Ship[2], 0, 4, "horizontal");
            // boardShip.SetPosition(boardShip.Ship[3], 0, 6, "horizontal");

            // string [,] finalBoard = new string [10, 10];
            
            
            // finalBoard[0, 1] = boardShip.Ship[0].LetterId;
            // finalBoard[0, 2] = boardShip.Ship[0].LetterId;
            
            // Assert.AreEqual("S",boardShip.Ocean[0, 1].ToString());
            // Assert.AreEqual("S", boardShip.Ocean[0, 2].ToString());
            
            
        }
   }
}

    



