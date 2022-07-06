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
    public class FinalHandlerTest
    {
        FinalHandler handler;
        Message message;

        [SetUp]
        public void Setup()
        {

            handler = new FinalHandler(null);
            message = new Message();
        }

        [Test]
        public void FinalHandler()
        {
            var user = new Telegram.Bot.Types.User();
            user.Id = 123;
            message.From = user;
            UserList.Instance.addNewUser("ionass", user.Id.ToString());
            // HistorialUser.Instance.Historial.Add(message.From.ToString(), new Collection<string>());

            message.Text = "Mensaje de usuario no conocido";
            string response;

            IHandler result = handler.Handle(message, out response);
            string expectedResponse = "No puedo procesar ese mensaje, intente de nuevo. ";
            Assert.That(result, Is.Not.Null);
            Assert.That(response, Is.EqualTo(expectedResponse));
        }


    }
}








