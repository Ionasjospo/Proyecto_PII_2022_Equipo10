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
    public class HeatWaterHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="UserStatsHandler"/>. Esta clase procesa el mensaje "/Estadisticas".
        /// </summary>
        /// <param name="next">El próximo "handler".</param>
        public HeatWaterHandler(BaseHandler next) : base(next)
        {

            this.Keywords = new string[] { "/Disparos_Agua" };
        }

        /// <summary>
        /// Procesa el mensaje "/Estadisticas" y retorna true; retorna false en caso contrario.
        /// </summary>
        /// <param name="message">El mensaje a procesar.</param>
        /// <param name="response">La respuesta al mensaje procesado.</param>
        /// <returns>true si el mensaje fue procesado; false en caso contrario.</returns>
        protected override bool InternalHandle(Message message, out string response)
        {
             if (this.CanHandle(message) && MatchList.Instance.FindMatch(message.From.ToString())!=null)
            {
                StringBuilder completeMessage = new StringBuilder();
                Match match = MatchList.Instance.FindMatch(message.From.ToString());
                
                completeMessage.Append($"Los disparos efectuados al agua son: {match.Battle.WaterHeat}");

                response = completeMessage.ToString();
                return true;
            }
            response = string.Empty;
            return false;
        }
    }
}