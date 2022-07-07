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
    public class HeatTestHandler
    {
        HeatShipHandler handler;
        Message message;

        [SetUp]
        public void Setup()
        {

            handler = new HeatShipHandler(null);
            message = new Message();
        }

        [Test]
        public void HandlerHeatTest()
        {
            var user = new Telegram.Bot.Types.User();
            user.Id = 777;
            message.From = user;

            UserList.Instance.addNewUser("Gonzalito",user.Id.ToString());
            UserList.Instance.addNewUser("Uruguayo", "789");

            HistorialUser.Instance.Historial.Add(message.From.ToString(), new Collection<string>());


            UserList.Instance.FindUserById(user.Id.ToString()).NewMatch(false);
            Match match = MatchList.Instance.FindMatch(user.Id.ToString());
            UserList.Instance.FindUserById("789").JoinMatch(match);

            BoardWithShips board1 = match.PlayerA1.BoardWithShips as BoardWithShips;

            BoardWithShips board2 = match.PlayerB1.BoardWithShips as BoardWithShips;


            board1.SetPosition(board1.Ship[3], 1, 1, "vertical");
            board1.SetPosition(board1.Ship[2], 2, 2, "vertical");
            board1.SetPosition(board1.Ship[1], 3, 3, "vertical");
            board1.SetPosition(board1.Ship[0], 4, 4, "vertical");

            board2.SetPosition(board2.Ship[3], 1, 1, "horizontal");
            board2.SetPosition(board2.Ship[2], 2, 2, "horizontal");
            board2.SetPosition(board2.Ship[1], 3, 3, "horizontal");
            board2.SetPosition(board2.Ship[0], 4, 4, "horizontal");

            match.NewBattle();

            match.Battle.Attack(1, 1, match.PlayerA1, match.PlayerB1, false);//BARCO

            match.Battle.Attack(2, 2, match.PlayerB1, match.PlayerA1, false);//BARCO

            match.Battle.Attack(9, 9, match.PlayerA1, match.PlayerB1, false);//AGUA

            message.Text = handler.Keywords[0];
            string response;

            IHandler result = handler.Handle(message, out response);


            StringBuilder expectedResponse = new StringBuilder();

            expectedResponse.Append($"Los disparos efectuados a barcos son: 2");


            Assert.That(result, Is.Not.Null);
            Assert.That(response, Is.EqualTo(expectedResponse.ToString()));

        }

    }
}








