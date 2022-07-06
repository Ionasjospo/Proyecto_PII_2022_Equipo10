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
    public class CreateMatchHandlerTest
    {
        CreateMatchHandler handler;
        Message message;

        [SetUp]
        public void Setup()
        {

            handler = new CreateMatchHandler(null);
            message = new Message();
        }

        [Test]
        public void CreateMatchHandler()
        {
            var user = new Telegram.Bot.Types.User();
            user.Id = 123;
            message.From = user;
            UserList.Instance.addNewUser("ionass", user.Id.ToString());
            HistorialUser.Instance.Historial.Add(message.From.ToString(), new Collection<string>());

            message.Text = handler.Keywords[0];
            string response;

            IHandler result = handler.Handle(message, out response);
            StringBuilder expectedResponse = new StringBuilder();
            expectedResponse.Append("Esta a punto de comenzar una batalla...\n");
            expectedResponse.Append("Para comenzar debe aclarar si va a ser una guerra con aliados o no...\n");
            expectedResponse.Append("Contamos con dos modalidades de juego:\n");
            expectedResponse.Append("/1 - 1\U0001f19a1\n");
            expectedResponse.Append("/2 - 2\U0001f19a2\n");
            Assert.That(result, Is.Not.Null);
            Assert.That(response, Is.EqualTo(expectedResponse.ToString()));
        }


    }
}








