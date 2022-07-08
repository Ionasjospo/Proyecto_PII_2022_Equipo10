using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InputFiles;
using Nito.AsyncEx;
using System.Text;
using System.Collections.ObjectModel;
using Exceptions;

namespace Library
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "/VerDisparosAlAgua".
    /// </summary>
    public class TotalWaterShotHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TotalWaterShotHandler"/>. 
        /// Esta clase procesa el mensaje "Registrarme".
        /// </summary>
        /// <param name="next">El próximo "handler".</param>

        private QuantityOfShots quantityOfShots = new QuantityOfShots();
        public TotalWaterShotHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] { "/VerDisparosAlAgua" };
        }
        /// <summary>
        /// Procesa el mensaje "/TotalWaterShot" y retorna true; retorna false en caso contrario.
        /// </summary>
        /// <param name="message">El mensaje a procesar.</param>
        /// <param name="response">La respuesta al mensaje procesado.</param>
        /// <returns>true si el mensaje fue procesado; false en caso contrario.</returns>
        protected override bool InternalHandle(Message message, out string response)
        {
            if (HistorialUser.Instance.Historial[message.From.ToString()].Contains("/VerDisparosAlAgua") || this.CanHandle(message))
            {
                Match match = MatchList.Instance.FindMatch(message.From.ToString());
                StringBuilder completeMessage = new StringBuilder();
                completeMessage.Append($"Los disparos al agua totales en esta partida son {match.Battle.quantityOfShots.QuantityOfWaterShots}.");
                response = completeMessage.ToString();
                return true;
            }
            response = string.Empty;
            return false;
        }

    }
}
