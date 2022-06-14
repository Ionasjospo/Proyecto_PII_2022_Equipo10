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
       /// Id del jugador que manda el mensaje.
       /// </summary>
       private int idPlayerSend;
       /// <summary>
       /// Id del jugador que recive el mensaje.
       /// </summary>
       private int idPlayerReceive;

       /// <summary>
       /// Lista encargada de guardar la conversación que hubo.
       /// </summary>
       /// <typeparam name="Text">Mensajes</typeparam>
       /// <returns></returns>
       private List<Text> conversation = new List<Text> ();

       /// <summary>
       /// Metodo para enviar mensajes
       /// </summary>
       /// <param name="playerSend">Jugador que envia el mensaje.</param>
       /// <param name="playerReceive">Jugador que recibe el mensaje</param>
       /// <param name="text">Mensaje</param>
       public void SendMessage(User playerSend, User playerReceive, string message)
       {
           Text text = new Text(playerSend, message);//patron creator
           conversation.Add(text);           
       }
    }
}

