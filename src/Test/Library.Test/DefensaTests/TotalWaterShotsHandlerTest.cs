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
    public class TotalWaterShotsHandlerTest
    {
        TotalWaterShotHandler handler;
        Message message;

        [SetUp]
        public void Setup()
        {

            handler = new TotalWaterShotHandler(null);
            message = new Message();
        }
        /// <summary>
        /// test que verifica que dos usuarios estan dentro de la misma partida.
        /// </summary>
        [Test]
        public void TwoPlayersInMatch()
        {
            var userWantSeeAllWaterShots = new Telegram.Bot.Types.User();
            userWantSeeAllWaterShots.Id = 123;
            message.From = userWantSeeAllWaterShots;
            UserList.Instance.addNewUser("usuarioCurioso", userWantSeeAllWaterShots.Id.ToString());

            var userEnemy = new Telegram.Bot.Types.User();
            userEnemy.Id = 321;
            UserList.Instance.addNewUser("Rival", userEnemy.Id.ToString());

            UserList.Instance.FindUserById("123").NewMatch(false);

            MatchList.Instance.addNewMatch(MatchList.Instance.FindMatch("123"));

            UserList.Instance.FindUserById("321").JoinMatch(MatchList.Instance.FindMatch("123"));

            Assert.Contains(MatchList.Instance.FindMatch("123"), MatchList.Instance.HistoricMatches);
            Assert.That(MatchList.Instance.FindMatch("123").PlayerA1.User.Name == UserList.Instance.FindUserById("123").Name);
            Assert.That(MatchList.Instance.FindMatch("123").PlayerB1.User.Name == UserList.Instance.FindUserById("321").Name);
        }

        [Test]
        public void TotalWaterShotHandlerTest()
        {
            var userWantSeeAllWaterShots = new Telegram.Bot.Types.User();
            userWantSeeAllWaterShots.Id = 123;
            message.From = userWantSeeAllWaterShots;
            UserList.Instance.addNewUser("usuarioCurioso", userWantSeeAllWaterShots.Id.ToString());
            HistorialUser.Instance.Historial.Add(message.From.ToString(), new Collection<string>());

            var userEnemy = new Telegram.Bot.Types.User();
            userEnemy.Id = 321;
            UserList.Instance.addNewUser("Rival", userEnemy.Id.ToString());

            UserList.Instance.FindUserById("123").NewMatch(false);
            Match match = MatchList.Instance.FindMatch("123");


            UserList.Instance.FindUserById("321").JoinMatch(MatchList.Instance.FindMatch("123"));

            match.NewBattle();


            match.Battle.Attack(0, 0, match.PlayerA1, match.PlayerB1, false);
            match.Battle.Attack(2, 2, match.PlayerB1, match.PlayerA1, false);
           

            message.Text = handler.Keywords[0];
            string response;
            IHandler result = handler.Handle(message, out response);

            string expectedResponse = "Los disparos al agua totales en esta partida son 2.";

            Assert.That(result, Is.Not.Null);
            Assert.That(response, Is.EqualTo(expectedResponse.ToString()));
        }
    }
}








