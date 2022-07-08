using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InputFiles;
using Nito.AsyncEx;
using System.Text;
using System.Collections.ObjectModel;
using NUnit.Framework;

namespace Library.Test
{
    public class TotalShipShotsTest
    {


        [SetUp]
        public void Setup()
        {


        }




        [Test]
        public void TotalShipShotTest()
        {

            UserList.Instance.addNewUser("ionas", "1");
            UserList.Instance.addNewUser("pepe", "2");

            UserList.Instance.FindUserById("1").NewMatch(false);

            UserList.Instance.FindUserById("2").JoinMatch(MatchList.Instance.FindMatch("1"));

            Match match = MatchList.Instance.FindMatch("1");
            match.NewBattle();

            BoardWithShips board = MatchList.Instance.FindBoard("1") as BoardWithShips;
            board.SetPosition(board.Ship[0], 0, 0, "horizontal");
            board.SetPosition(board.Ship[0], 0, 1, "horizontal");
            board.SetPosition(board.Ship[0], 0, 2, "horizontal");
            board.SetPosition(board.Ship[0], 0, 3, "horizontal");

            BoardWithShips board2 = MatchList.Instance.FindBoard("2") as BoardWithShips;
            board2.SetPosition(board.Ship[0], 0, 0, "vertical");
            board2.SetPosition(board.Ship[0], 0, 1, "vertical");
            board2.SetPosition(board.Ship[0], 0, 2, "vertical");
            board2.SetPosition(board.Ship[0], 0, 3, "horizontal");

            match.Battle.Attack(0, 0, match.PlayerA1, match.PlayerB1, false);
            match.Battle.Attack(0, 0, match.PlayerB1, match.PlayerA1, false);


            Assert.AreEqual(2, match.Battle.quantityOfShots.QuantityOfShipShots);
        }

    }
}








