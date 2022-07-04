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
    public class RegisterHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="HelloHandler"/>. Esta clase procesa el mensaje "hola".
        /// </summary>
        /// <param name="next">El próximo "handler".</param>
        public RegisterHandler(BaseHandler next) : base(next)
        {

            this.Keywords = new string[]{"/Registrarme"};
        }

        /// <summary>
        /// Procesa el mensaje "Registrarme" y retorna true; retorna false en caso contrario.
        /// </summary>
        /// <param name="message">El mensaje a procesar.</param>
        /// <param name="response">La respuesta al mensaje procesado.</param>
        /// <returns>true si el mensaje fue procesado; false en caso contrario.</returns>
        protected override bool InternalHandle(Message message, out string response)
        {
            if (message.Text=="/Registrarme" || HistorialUser.Instance.Historial[message.From.ToString()].Contains("/Registrarme"))
            {
                Console.WriteLine("Registrarme");
                HistorialUser.Instance.Historial[message.From.ToString()].Add(message.Text);

                if (HistorialUser.Instance.Historial[message.From.ToString()].Contains("/Registrarme") && HistorialUser.Instance.Historial[message.From.ToString()].Count() == 1)
                {
                    StringBuilder CompleteMessage = new StringBuilder();
                    CompleteMessage.Append("A continuacion se va a registrar...\n");
                    CompleteMessage.Append("Ingrese su nombre de usuario, recuerde que será para siempre y no lo podra cambiar (Cuanto mas crativo... mejor!) \n");
                    response = CompleteMessage.ToString();
                    return true;

                }
                if(HistorialUser.Instance.Historial[message.From.ToString()].Contains("/Registrarme") && HistorialUser.Instance.Historial[message.From.ToString()].Count() == 2)
                {
                    StringBuilder completeMessage = new StringBuilder();
                    completeMessage.Append($"Su nombre de usuario es: '{message.Text}' \n");
                    completeMessage.Append("Usuario creado con exito!! \n");
                    completeMessage.Append("Para empezar a jugar ingresa al /Menu \n");
                    UserList.Instance.addNewUser(message.Text,message.From.ToString());
                   
                    HistorialUser.Instance.Historial[message.From.ToString()].Clear();

                    response = completeMessage.ToString();
                    return true;
                }

            }
            response = string.Empty;
            return false;
        }
    }
}