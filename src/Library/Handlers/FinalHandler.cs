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
    /// Un "handler" del patrón Chain of Responsibility que es implementado para el caso que el usuario
    /// escriba un comando que nuestro bot no sea capaz de procesar o haya escrito un cómando mal.
    /// </summary>
    public class FinalHandler : BaseHandler
    {
        /// <summary>
        /// Constructor de FinalHandler.
        /// </summary>
        /// <param name="next">Proximo handler</param>
        public FinalHandler(BaseHandler next) : base(next)
        {
           
        }
        /// <summary>
        /// Responde al mensaje que no identifico ningun handler.
        /// </summary>
        /// <param name="message">El mensaje a procesar.</param>
        /// <param name="response">La respuesta al mensaje procesado.</param>
        /// <returns>true si el mensaje fue procesado; false en caso contrario.</returns>
        protected override bool InternalHandle(Message message, out string response)
        {
            response = "No puedo procesar ese mensaje, intente de nuevo. ";
            return true;
        }
    }
}
