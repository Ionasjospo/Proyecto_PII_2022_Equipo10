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
                    StringBuilder CompleteMessage = new StringBuilder();
                    CompleteMessage.Append("BIENVENIDO AL BOT DEL EQUIPO 10 \n");
                    CompleteMessage.Append("Usted no se encuentra registrado... \n");
                    CompleteMessage.Append("Ingrese /REGISTRARME para continuar");

                    response = CompleteMessage.ToString();
                   return true;

                }
                else 
                {
                    StringBuilder CompleteMessage = new StringBuilder();
                    CompleteMessage.Append("BIENVENIDO AL BOT DEL EQUIPO 10\n");   
                    CompleteMessage.Append("    MENU DE JUEGO \n");
                    CompleteMessage.Append("    /BUSCAR_PARTIDA \n");
                    CompleteMessage.Append("    /CREAR_PARTIDA \n");
                    CompleteMessage.Append("    /OTRAS_OPCIONES \n");

                    response = CompleteMessage.ToString();
                   return true;
                }

            }
            response = string.Empty;
            return false;
        }
    }
}