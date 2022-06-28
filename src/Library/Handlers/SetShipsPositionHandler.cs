using Telegram.Bot.Types;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Library
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "hola".
    /// </summary>
    public class SetShipsPositionHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="SetShipsPositionHandler"/>. Esta clase procesa el mensaje "hola".
        /// </summary>
        /// <param name="next">El próximo "handler".</param>
        public SetShipsPositionHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[]{"/CrearTablero"};
        }

        /// <summary>
        /// Procesa el mensaje "Registrarme" y retorna true; retorna false en caso contrario.
        /// </summary>
        /// <param name="message">El mensaje a procesar.</param>
        /// <param name="response">La respuesta al mensaje procesado.</param>
        /// <returns>true si el mensaje fue procesado; false en caso contrario.</returns>
        protected override bool InternalHandle(Message message, out string response)
        {
            if (this.CanHandle(message) || HistorialUser.Instance.Historial[message.From.ToString()].Contains("/CrearTablero"))
            {
                Console.WriteLine("match");
                HistorialUser.Instance.Historial[message.From.ToString()].Add(message.Text);

                if (HistorialUser.Instance.Historial[message.From.ToString()].Contains("/CrearPartida") && HistorialUser.Instance.Historial[message.From.ToString()].Count() == 1)
                {
                    StringBuilder CompleteMessage = new StringBuilder();
                    CompleteMessage.Append("Esta a punto de comenzar una batalla...\n");
                    CompleteMessage.Append("Para comenzar debe aclarar si va a ser una guerra con aliados o no...\n");
                    CompleteMessage.Append("Contamos con dos modalidades de juego:\n");
                    CompleteMessage.Append("/1 - 1\U0001f19a1\n");
                    CompleteMessage.Append("/2 - 2\U0001f19a2\n");

                    response = CompleteMessage.ToString();
                    return true;

                }
                if(HistorialUser.Instance.Historial[message.From.ToString()].Contains("/CrearPartida") && HistorialUser.Instance.Historial[message.From.ToString()].Count() == 2)
                {
                    StringBuilder CompleteMessage = new StringBuilder();

                    if(message.Text=="/1")
                    {
                        CompleteMessage.Append($"Partida 1vs1 creada.\n");
                        CompleteMessage.Append($"A continuacion debera colocar toda su flota...");
                        CompleteMessage.Append($"/ColocarTablero");
                        Match match = new Match(HistorialUser.Instance.UserID[message.From.ToString()],false);
                        response = CompleteMessage.ToString();
                        return true;




                    }
                    if(message.Text=="/2")
                    {


                    }
                   

                    response = CompleteMessage.ToString();
                    return true;
                }

            }
            response = string.Empty;
            return false;
        }
    }
}