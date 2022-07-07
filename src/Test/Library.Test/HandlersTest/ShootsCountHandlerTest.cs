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
    public class ShootsCountHandlerTest
    {
        ShootsCountHandler handler;
        Message message;

        


        [SetUp]
        public void Setup()
        {

            handler = new ShootsCountHandler(null);
            message = new Message();
        }

        [Test]
        public void ShootsCountHandler_Water()
        {

            UserList.Instance.addNewUser("pepe1", " (12345678901)");
            UserList.Instance.addNewUser("pepe2", " (12345678902)");
            User user1 = UserList.Instance.FindUserById(" (12345678901)");
            user1.NewMatch(false);
            Match match = user1.MatchesPlayed.Last();
            User user2 = UserList.Instance.FindUserById(" (12345678902)");
            user2.JoinMatch(match);
            match.NewBattle();
            Battle battle = match.Battle;

            int water_test = 15;
            for (int i = 0; i < water_test; i++)
            {
                battle.Shoots.AddWater();
            }
            int water_real = battle.Shoots.Water;


            var telegram_user = new Telegram.Bot.Types.User();
            telegram_user.Id = 12345678901;
            message.From = telegram_user;
            HistorialUser.Instance.Historial.Add(message.From.ToString(), new Collection<string>());

            message.Text = handler.Keywords[0];
            string response;

            IHandler result = handler.Handle(message, out response);
            StringBuilder expectedResponse = new StringBuilder();

            expectedResponse.Append($"Se han disparado {match.Battle.Shoots.Water} veces al agua.\n");
            expectedResponse.Append($"Se han disparado {match.Battle.Shoots.Ship} veces a los barcos.\n");
            expectedResponse.Append($"Si desea, ya puede volver a /Atacar.\n");

            Assert.That(result, Is.Not.Null);
            Assert.That(response, Is.EqualTo(expectedResponse.ToString()));
        }

        [Test]
        public void ShootsCountHandler_Ship()
        {

            UserList.Instance.addNewUser("pepe3", " (12345678903)");
            UserList.Instance.addNewUser("pepe4", " (12345678904)");
            User user3 = UserList.Instance.FindUserById(" (12345678903)");
            user3.NewMatch(false);
            Match match = user3.MatchesPlayed.Last();
            User user4 = UserList.Instance.FindUserById(" (12345678904)");
            user4.JoinMatch(match);
            match.NewBattle();
            Battle battle = match.Battle;

            int ship_test = 15;
            for (int i = 0; i < ship_test; i++)
            {
                battle.Shoots.AddShip();
            }
            int ship_real = battle.Shoots.Ship;


            var telegram_user = new Telegram.Bot.Types.User();
            telegram_user.Id = 12345678903;
            message.From = telegram_user;
            HistorialUser.Instance.Historial.Add(message.From.ToString(), new Collection<string>());

            message.Text = handler.Keywords[0];
            string response;

            IHandler result = handler.Handle(message, out response);
            StringBuilder expectedResponse = new StringBuilder();

            expectedResponse.Append($"Se han disparado {match.Battle.Shoots.Water} veces al agua.\n");
            expectedResponse.Append($"Se han disparado {match.Battle.Shoots.Ship} veces a los barcos.\n");
            expectedResponse.Append($"Si desea, ya puede volver a /Atacar.\n");

            Assert.That(result, Is.Not.Null);
            Assert.That(response, Is.EqualTo(expectedResponse.ToString()));
        }
    }
}








