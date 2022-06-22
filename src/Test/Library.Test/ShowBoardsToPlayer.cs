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
            UserList.Instance.addNewUser("Alberto Kesman");
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

            Assert.AreEqual(expectedBoard, match.PlayerA1.BoardWithShips.Ocean);
        }
    }
}
    