using NUnit.Framework;
using Library;

namespace Library.Test
{
    [TestFixture]
    public class ShowBoardsToPlayer
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ShowBoardWithShips()
        {
            UserList.Instance.addNewUser("Alberto Kesman","56");
            UserList.Instance.Users[0].NewMatch(false);

            Match match = MatchList.Instance.HistoricMatches[0];
            ShowBoards.Instance.ShowConsoleBoard(match.PlayerA1.BoardWithShips);

            string[,] expectedBoard = new string[10, 10];

            for (int x = 0; x < expectedBoard.GetLength(0); x++)
            {
                for (int y = 0; y < expectedBoard.GetLength(1); y++)
                {
                    expectedBoard[x, y] = "O";
                }
            }
            expectedBoard[0, 0] = "S";
            expectedBoard[1, 0] = "S";

            expectedBoard[2, 4] = "B";
            expectedBoard[2, 5] = "B";
            expectedBoard[2, 6] = "B";

            expectedBoard[0, 4] = "D";
            expectedBoard[0, 5] = "D";
            expectedBoard[0, 6] = "D";
            expectedBoard[0, 7] = "D";
            
            expectedBoard[7, 2] = "A";
            expectedBoard[7, 3] = "A";
            expectedBoard[7, 4] = "A";
            expectedBoard[7, 5] = "A";
            expectedBoard[7, 6] = "A";


            Assert.AreEqual(expectedBoard, match.PlayerA1.BoardWithShips.Ocean);
        }
    }
}
    