using System;
using Library;
using NUnit.Framework;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InputFiles;
using System.Collections.Generic;
using System.Text;

namespace Library.Test
{
    public class UserStatHandlerTest
    {
        UserStatsHandler handler;
        Message message;

        [SetUp]
        public void Setup()
        {

            handler = new UserStatsHandler(null);
            message = new Message();
        }


        [Test]
        public void UserStatsHandle()
        {
            var user = new Telegram.Bot.Types.User();
            message.From = user;
            message.Text = handler.Keywords[0];
            string response;
            

            IHandler result = handler.Handle(message, out response);



            StringBuilder completeMessage = new StringBuilder();

            completeMessage.Append("Tus estadisticas son: \n");
            completeMessage.Append($"Has ganado 0 partidas.\n ");
            completeMessage.Append($"Tienes un total de 0 bombas especiales disponibles para usar.");


            response = completeMessage.ToString();
            Assert.That(result, Is.Not.Null);
            Assert.That(response, Is.EqualTo("Tus estadisticas son: \nHas ganado 0 partidas.\n Tienes un total de 0 bombas especiales disponibles para usar."));
        }
    }
}



