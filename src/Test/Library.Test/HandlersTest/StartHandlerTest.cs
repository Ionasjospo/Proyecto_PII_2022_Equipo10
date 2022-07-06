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
    public class StartHandlerTest
    {
        StartHandler handler;
        Message message;

        [SetUp]
        public void Setup()
        {

            handler = new StartHandler(null, null);
            message = new Message();
        }

        [Test]
        public void UserStartHandle()
        {
            var user = new Telegram.Bot.Types.User();
            message.From = user;
            message.Text = handler.Keywords[0];
            string response;

            IHandler result = handler.Handle(message, out response);
            StringBuilder expectedResponse = new StringBuilder();
            expectedResponse.Append("Bienvenido a la Batalla Naval del Equipo 10\n");
            expectedResponse.Append("Usted no se encuentra registrado... \n");
            expectedResponse.Append("Ingrese /Registrarme para continuar");


            Assert.That(result, Is.Not.Null);
            Assert.That(response, Is.EqualTo(expectedResponse.ToString()));
        }

    }
}





