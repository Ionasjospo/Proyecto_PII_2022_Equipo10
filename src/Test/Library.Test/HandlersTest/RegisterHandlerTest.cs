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
    public class RegisterHandlerTest
    {
        RegisterHandler handler;
        Message message;

        [SetUp]
        public void Setup()
        {

            handler = new RegisterHandler(null);
            message = new Message();
        }

        [Test]
        public void RegisterHandler()
        {
            var user = new Telegram.Bot.Types.User();
            user.Id = 999;
            message.From = user;
            UserList.Instance.addNewUser("ionass", user.Id.ToString());
            HistorialUser.Instance.Historial.Add(message.From.ToString(), new Collection<string>());

            message.Text = handler.Keywords[0];
            string response;

            IHandler result = handler.Handle(message, out response);
            StringBuilder expectedResponse = new StringBuilder();
            expectedResponse.Append("A continuacion se va a registrar...\n");
            expectedResponse.Append("Ingrese su nombre de usuario, recuerde que será para siempre y no lo podra cambiar (Cuanto mas crativo... mejor!) \n");


            Assert.That(result, Is.Not.Null);
            Assert.That(response, Is.EqualTo(expectedResponse.ToString()));
        }

      
    }
}





