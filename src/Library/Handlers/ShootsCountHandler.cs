using Telegram.Bot.Types;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Exceptions;

namespace Library
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "VerDisparosTotales".
    /// </summary>
    public class ShootsCountHandler : BaseHandler
    {
        /// <summary>
        /// Mensaje a responder.
        /// </summary>
        string msj = "";
        /// <summary>
        /// Instancia de user.
        /// </summary>
        User user;
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="ShootsCountHandler"/>. 
        /// Esta clase procesa el mensaje "VerDisparosTotales".
        /// </summary>
        /// <param name="next">El próximo "handler".</param>
        public ShootsCountHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] { "/VerDisparosTotales" };
        }

        /// <summary>
        /// Procesa el mensaje "BuscarPartida" y retorna true; retorna false en caso contrario.
        /// </summary>
        /// <param name="message">El mensaje a procesar.</param>
        /// <param name="response">La respuesta al mensaje procesado.</param>
        /// <returns>true si el mensaje fue procesado; false en caso contrario.</returns>
        protected override bool InternalHandle(Message message, out string response)
        {
            msj = "";
            if (this.CanHandle(message) || HistorialUser.Instance.Historial[message.From.ToString()].Contains("/VerDisparosTotales"))
            {
                Console.WriteLine("VerDisparosTotales");
                HistorialUser.Instance.Historial[message.From.ToString()].Add(message.Text);

                if (HistorialUser.Instance.Historial[message.From.ToString()][0] == ("/VerDisparosTotales") && HistorialUser.Instance.Historial[message.From.ToString()].Count() == 1)
                {
                    StringBuilder CompleteMessage = new StringBuilder();
                    try
                    {
                        user = UserList.Instance.FindUserById(message.From.ToString());
                        if (user.UserInMatchRunning())
                        {
                            Match match = MatchList.Instance.FindMatch(message.From.ToString());
                            if (match.Battle != null)
                            {
                                CompleteMessage.Append($"Se han disparado {match.Battle.Shoots.Water} veces al agua.\n");
                                CompleteMessage.Append($"Se han disparado {match.Battle.Shoots.Ship} veces a los barcos.\n");
                                CompleteMessage.Append($"Si desea, ya puede volver a /Atacar.\n");
                                
                            }
                            else
                            {
                                CompleteMessage.Append($"Usted no está jugando en ninguna batalla.\n");
                                CompleteMessage.Append($"Pudes volver a /BuscarPartida \n También puedes /CrearPartida !!");
                            }
                        }
                        else
                        {
                            CompleteMessage.Append($"Usted no está jugando en ninguna partida.\n");
                            CompleteMessage.Append($"Pudes volver a /BuscarPartida \n También puedes /CrearPartida !!");
                        }
                    }
                    catch (System.Exception)
                    {
                        msj = "Ocurrió un error al intentar ver la cantidad de disparos realiados. \n";
                        new ShootsCountException(msj);
                        CompleteMessage.Append(msj);
                        response = CompleteMessage.ToString();
                        return true;
                    }
                    CompleteMessage.Append(msj);
                    response = CompleteMessage.ToString();
                    return true;
                }

            }

            response = string.Empty;
            return false;
        }
    }
}