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
    public class StartHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="HelloHandler"/>. Esta clase procesa el mensaje "hola".
        /// </summary>
        /// <param name="next">El próximo "handler".</param>
        public StartHandler(BaseHandler next) : base(next)
        {

            this.Keywords = new string[] { "/start" };
        }

        /// <summary>
        /// Procesa el mensaje "hola" y retorna true; retorna false en caso contrario.
        /// </summary>
        /// <param name="message">El mensaje a procesar.</param>
        /// <param name="response">La respuesta al mensaje procesado.</param>
        /// <returns>true si el mensaje fue procesado; false en caso contrario.</returns>
        protected override bool InternalHandle(Message message, out string response)
        {
            if (this.CanHandle(message))
            {
                if (!HistorialUser.Instance.Historial.ContainsKey(message.From.ToString()))
                {
                    HistorialUser.Instance.Historial.Add(message.From.ToString(),new Collection<string>());
                    StringBuilder completeMessage = new StringBuilder();
                    completeMessage.Append("Bienvenido a la Batalla Naval del Equipo 10\n");
                    completeMessage.Append("Usted no se encuentra registrado... \n");
                    completeMessage.Append("Ingrese /REGISTRARME para continuar");

                    response = completeMessage.ToString();
                   return true;

                }
                else 
                {
                    StringBuilder completeMessage = new StringBuilder();
                    completeMessage.Append("Bienvenido a la Batalla Naval del Equipo 10\n");   
                    completeMessage.Append("    /Menu     \n");
                    completeMessage.Append("    /BuscarPartida \n");
                    completeMessage.Append("    /CrearPartida \n");
                    completeMessage.Append("    /MasOpciones \n");

                    response = completeMessage.ToString();
                   return true;
                }

            }
            response = string.Empty;
            return false;
        }
    }
}