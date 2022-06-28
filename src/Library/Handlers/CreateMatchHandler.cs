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
    public class CreateMatchHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CreateMatchHandler"/>. Esta clase procesa el mensaje "hola".
        /// </summary>
        /// <param name="next">El próximo "handler".</param>
        public CreateMatchHandler(BaseHandler next) : base(next)
        {

            this.Keywords = new string[]{"/CREAR_PARTIDA"};
        }

        /// <summary>
        /// Procesa el mensaje "Registrarme" y retorna true; retorna false en caso contrario.
        /// </summary>
        /// <param name="message">El mensaje a procesar.</param>
        /// <param name="response">La respuesta al mensaje procesado.</param>
        /// <returns>true si el mensaje fue procesado; false en caso contrario.</returns>
        protected override bool InternalHandle(Message message, out string response)
        {
            if (this.CanHandle(message) || HistorialUser.Instance.Historial[message.From.ToString()].Contains("/CREAR_PARTIDA"))
            {
                Console.WriteLine("match");
                HistorialUser.Instance.Historial[message.From.ToString()].Add(message.Text);

                if (HistorialUser.Instance.Historial[message.From.ToString()].Contains("/CREAR_PARTIDA") && HistorialUser.Instance.Historial[message.From.ToString()].Count() == 1)
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
                if(HistorialUser.Instance.Historial[message.From.ToString()].Contains("/CREAR_PARTIDA") && HistorialUser.Instance.Historial[message.From.ToString()].Count() == 2)
                {
                    StringBuilder CompleteMessage = new StringBuilder();

                    if(message.Text=="/1")
                    {
                        CompleteMessage.Append($"PARTIDA 1VS1 CREADA...\n");
                        CompleteMessage.Append($"A continuacion debera colocar toda su flota...");
                        CompleteMessage.Append($"/COLOCAR_TABLERO");
                        //Match match = new Match(HistorialUser.Instance.UserID[message.From.ToString()],false);
                        User user = UserList.Instance.FindUserById(message.From.ToString());
                        user.NewMatch(false);
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