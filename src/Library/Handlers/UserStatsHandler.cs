using Telegram.Bot.Types;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Library
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "/Estadisticas".
    /// </summary>
    public class UserStatsHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="UserStatsHandler"/>. Esta clase procesa el mensaje "/Estadisticas".
        /// </summary>
        /// <param name="next">El próximo "handler".</param>
        public UserStatsHandler(BaseHandler next) : base(next)
        {

            this.Keywords = new string[] { "/Estadisticas" };
        }

        /// <summary>
        /// Procesa el mensaje "/Estadisticas" y retorna true; retorna false en caso contrario.
        /// </summary>
        /// <param name="message">El mensaje a procesar.</param>
        /// <param name="response">La respuesta al mensaje procesado.</param>
        /// <returns>true si el mensaje fue procesado; false en caso contrario.</returns>
        protected override bool InternalHandle(Message message, out string response)
        {
            if (this.CanHandle(message) || HistorialUser.Instance.Historial[message.From.ToString()].Contains("/CrearPartida"))
            {
                StringBuilder completeMessage = new StringBuilder();

                completeMessage.Append("Tus estadisticas son: \n");
                completeMessage.Append($"Has ganado {UserList.Instance.FindUserById(message.From.ToString()).BattlesWon} partidas.\n ");
                completeMessage.Append($"Tienes un total de {UserList.Instance.FindUserById(message.From.ToString()).SpecialBomb} bombas especiales disponibles para usar.");
                response = completeMessage.ToString();
                return true;
            }
            response = string.Empty;
            return false;
        }
    }
}