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
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "/VerDisparosABarcos".
    /// </summary>
    public class TotalShipShotsHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TotalShipShotsHandler"/>. 
        /// Esta clase procesa el mensaje "Registrarme".
        /// </summary>
        /// <param name="next">El próximo "handler".</param>

        private QuantityOfShots quantityOfShots = new QuantityOfShots();
        public TotalShipShotsHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] { "/VerDisparosABarcos" };
        }
        /// <summary>
        /// Procesa el mensaje "/TotalShipShots" y retorna true; retorna false en caso contrario.
        /// </summary>
        /// <param name="message">El mensaje a procesar.</param>
        /// <param name="response">La respuesta al mensaje procesado.</param>
        /// <returns>true si el mensaje fue procesado; false en caso contrario.</returns>
        protected override bool InternalHandle(Message message, out string response)
        {
            if (HistorialUser.Instance.Historial[message.From.ToString()].Contains("/VerDisparosABarcos") || this.CanHandle(message))
            {
                StringBuilder completeMessage = new StringBuilder();
                completeMessage.Append($"Los disparos a barcos totales en esta partida son {quantityOfShots.QuantityOfShipShots}.");
                response = completeMessage.ToString();
                return true;
            }
            response = string.Empty;
            return false;
        }

    }
}
