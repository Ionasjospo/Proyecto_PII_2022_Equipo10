using Telegram.Bot.Types;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Exceptions;

namespace Library
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "/CrearPartida".
    /// </summary>
    public class CreateMatchHandler : BaseHandler
    {
        /// <summary>
        /// Mensaje que le es enviado al usuario.
        /// </summary>
        string msj = "";
        /// <summary>
        /// Instancia de usuario.
        /// </summary>
        User user;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CreateMatchHandler"/>. Esta clase procesa el mensaje "/CrearPartida".
        /// </summary>
        /// <param name="next">El próximo "handler".</param>
        public CreateMatchHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] { "/CrearPartida" };
        }

        /// <summary>
        /// Procesa el mensaje "/CrearPartida" y retorna true; retorna false en caso contrario.
        /// </summary>
        /// <param name="message">El mensaje a procesar.</param>
        /// <param name="response">La respuesta al mensaje procesado.</param>
        /// <returns>true si el mensaje fue procesado; false en caso contrario.</returns>
        protected override bool InternalHandle(Message message, out string response)
        {
            if (this.CanHandle(message) || HistorialUser.Instance.Historial[message.From.ToString()].Contains("/CrearPartida"))
            {

                HistorialUser.Instance.Historial[message.From.ToString()].Add(message.Text);

                if (HistorialUser.Instance.Historial[message.From.ToString()][0] == "/CrearPartida" && HistorialUser.Instance.Historial[message.From.ToString()].Count() == 1)
                {
                    StringBuilder CompleteMessage = new StringBuilder();
                    try
                    {
                        user = UserList.Instance.FindUserById(message.From.ToString());
                        if (user.UserInMatchRunning())
                        {
                            CompleteMessage.Append($"Usted ya está jugando en una partida.\n");
                            CompleteMessage.Append($"Si lo desea, puede iniciar un /Chat con los demás jugadores");
                        }
                        else
                        {
                            CompleteMessage.Append("Esta a punto de comenzar una batalla...\n");
                            CompleteMessage.Append("Para comenzar debe aclarar si va a ser una guerra con aliados o no...\n");
                            CompleteMessage.Append("Contamos con dos modalidades de juego:\n");
                            CompleteMessage.Append("/1 - 1\U0001f19a1\n");
                            CompleteMessage.Append("/2 - 2\U0001f19a2\n");
                        }
                    }
                    catch (System.Exception e)
                    {
                        msj = "Lamentamos que no es posible crear una partida.\n";
                        throw new CreateMatchException(msj + e.ToString());
                    }
                    finally
                    {
                        CompleteMessage.Append(msj);
                        response = CompleteMessage.ToString();
                    }
                    return true;
                }
                if (HistorialUser.Instance.Historial[message.From.ToString()][0] == "/CrearPartida" && HistorialUser.Instance.Historial[message.From.ToString()].Count() == 2)
                {
                    StringBuilder CompleteMessage = new StringBuilder();
                    try
                    {
                        if (message.Text == "/1")
                        {
                            CompleteMessage.Append($"Partida 1vs1 creada.\n");
                            CompleteMessage.Append($"A continuacion debera colocar toda su flota...");

                            CompleteMessage.Append($"/Colocar_Tablero");

                            //User user = UserList.Instance.FindUserById(message.From.ToString());
                            user.NewMatch(false);
                            HistorialUser.Instance.Historial[message.From.ToString()].Clear();

                            //response = CompleteMessage.ToString();
                            //return true;
                        }
                        if (message.Text == "/2")
                        {
                            CompleteMessage.Append($"Partida 2vs2 creada.\n");
                            CompleteMessage.Append($"A continuacion debera colocar toda su flota...");

                            CompleteMessage.Append($"/Colocar_Tablero");

                            //User user = UserList.Instance.FindUserById(message.From.ToString());
                            user.NewMatch(true);
                            HistorialUser.Instance.Historial[message.From.ToString()].Clear();

                            //response = CompleteMessage.ToString();
                            //return true;
                        }
                    }
                    catch (System.Exception e)
                    {
                        msj = "Lamentamos que no es posible crear una partida.\n";
                        throw new CreateMatchException(msj + e.ToString());
                    }
                    finally
                    {
                        CompleteMessage.Append(msj);
                        HistorialUser.Instance.Historial[message.From.ToString()].Clear();
                        response = CompleteMessage.ToString();
                    }
                    return true;
                }

            }
            response = string.Empty;
            return false;
        }
    }
}