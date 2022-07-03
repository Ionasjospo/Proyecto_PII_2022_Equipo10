using Telegram.Bot.Types;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Exceptions;

namespace Library
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "BuscarPartida".
    /// </summary>
    public class SearchMatchHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="SearchMatchHandler"/>. 
        /// Esta clase procesa el mensaje "BuscarPartida".
        /// </summary>
        /// <param name="next">El próximo "handler".</param>
        public SearchMatchHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] { "/BuscarPartida" };
        }

        /// <summary>
        /// Procesa el mensaje "BuscarPartida" y retorna true; retorna false en caso contrario.
        /// </summary>
        /// <param name="message">El mensaje a procesar.</param>
        /// <param name="response">La respuesta al mensaje procesado.</param>
        /// <returns>true si el mensaje fue procesado; false en caso contrario.</returns>
        protected override bool InternalHandle(Message message, out string response)
        {
            if (this.CanHandle(message) || HistorialUser.Instance.Historial[message.From.ToString()].Contains("/BuscarPartida"))
            {
                HistorialUser.Instance.Historial[message.From.ToString()].Add(message.Text);

                if (HistorialUser.Instance.Historial[message.From.ToString()].Contains("/BuscarPartida") && HistorialUser.Instance.Historial[message.From.ToString()].Count() == 1)
                {
                    StringBuilder CompleteMessage = new StringBuilder();
                    try
                    {
                        CompleteMessage.Append("Seleccione alguna de las siguientes partidas:\n");
                        int cont = 0;
                        foreach (Match match in MatchList.Instance.HistoricMatches)
                        {
                            if (match.OpenToJoin)
                                CompleteMessage.Append($"Jugar en la partida n° /{cont} \n");
                            cont++;
                        }
                        if (cont == 0)
                        throw new MatchOpenToJoinException("No hay partidas disponibles para unirse \n Tu puedes también /CrearPartida !!");
                    }
                    catch (System.Exception)
                    {
                        //throw new MatchOpenToJoinException("No hay partidas disponibles para unirse \n Tu puedes también /CrearPartida !!");
                    }
                    finally
                    {

                    }
                    response = CompleteMessage.ToString();
                    return true;
                }
                if (HistorialUser.Instance.Historial[message.From.ToString()].Contains("/BuscarPartida") && HistorialUser.Instance.Historial[message.From.ToString()].Count() == 2)
                {
                    StringBuilder CompleteMessage = new StringBuilder();
                    try
                    {
                        string matchNum = message.Text.Substring(1);
                        Match match = MatchList.Instance.HistoricMatches[Convert.ToInt32(matchNum)];
                        User user = UserList.Instance.FindUserById(message.From.ToString());
                        user.JoinMatch(match);
                        CompleteMessage.Append($"Te has unido a la partida de {match.PlayerA1.User.Name}.\n");
                        CompleteMessage.Append($"A continuacion debera colocar toda su flota...");
                        CompleteMessage.Append($"/Colocar_Tablero");
                        HistorialUser.Instance.Historial[message.From.ToString()].Clear();
                    }
                    catch (System.Exception)
                    {
                        throw new MatchFullPlayersException("Lamentamos que se han completado todas las partidas, \n Tu puedes también /CrearPartida !!");
                    }
                    finally
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