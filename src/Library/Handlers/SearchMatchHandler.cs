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
    public class SearchMatchHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="SearchMatchHandler"/>. Esta clase procesa el mensaje "hola".
        /// </summary>
        /// <param name="next">El próximo "handler".</param>
        public SearchMatchHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[]{"/BuscarPartida"};
        }

        /// <summary>
        /// Procesa el mensaje "Registrarme" y retorna true; retorna false en caso contrario.
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
                    CompleteMessage.Append("Seleccione alguna de las siguientes partidas:\n");
                    int cont = 0;
                    foreach (Match match in MatchList.Instance.HistoricMatches)
                    {
                        if (match.OpenToJoin)
                            CompleteMessage.Append($"Jugar en la partida n° /{cont} \n");
                        cont++;
                    }
                    response = CompleteMessage.ToString();
                    return true;
                }
                if(HistorialUser.Instance.Historial[message.From.ToString()].Contains("/BuscarPartida") && HistorialUser.Instance.Historial[message.From.ToString()].Count() == 2)
                {
                    StringBuilder CompleteMessage = new StringBuilder();
                    string matchNum = message.Text.Substring(1);
                    Match match = MatchList.Instance.HistoricMatches[Convert.ToInt32(matchNum)];
                    User user = UserList.Instance.FindUserById(message.From.ToString());
                    user.JoinMatch(match);
                    CompleteMessage.Append($"Te has unido a la partida de {match.PlayerA1.User.Name}.\n");
                    CompleteMessage.Append($"A continuacion debera colocar toda su flota...");
                    CompleteMessage.Append($"/COLOCAR_TABLERO");  
                    response = CompleteMessage.ToString();
                    return true;
                }
            }
            response = string.Empty;
            return false;
        }
    }
}