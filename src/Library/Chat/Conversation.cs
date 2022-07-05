using System;
using System.Collections.Generic;

namespace Library
{
    /// <summary>
    /// Clase que permite establecer una conversación entre dos jugadores.
    /// </summary>
    public class Conversation
    {
        /// <summary>
        /// Lista encargada de guardar la conversación que hubo.
        /// </summary>
        /// <typeparam name="Text">Mensajes</typeparam>
        /// <returns></returns>
        private List<Text> conversation = new List<Text>();
        /// <summary>
        /// Metodo para enviar mensajes
        /// </summary>
        /// <param name="userSend">Usuario que envia el mensaje.</param>
        /// <param name="text">Mensaje</param>
        public void SendMessage(User userSending, string message)
        {
            Text text = new Text(userSending, message);//patron creator
            conversation.Add(text);
        }
    }
}

