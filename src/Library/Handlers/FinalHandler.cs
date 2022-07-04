// using Telegram.Bot.Types;
// using System;
// using System.Collections.Generic;
// using System.Collections.ObjectModel;
// using System.Text;

// namespace Library
// {
//     /// <summary>
//     /// Un "handler" del patrón Chain of Responsibility que implementa el comando "hola".
//     /// </summary>
//     public class FinalHandler : BaseHandler
//     {
//         /// <summary>
//         /// Inicializa una nueva instancia de la clase <see cref="FinalHandler"/>. Esta clase procesa el mensaje "hola".
//         /// </summary>
//         /// <param name="next">El próximo "handler".</param>
//         public FinalHandler(BaseHandler next) : base(next)
//         {
//             this.Keywords = new string[] { };
//         }

//         /// <summary>
//         /// Procesa el mensaje "Registrarme" y retorna true; retorna false en caso contrario.
//         /// </summary>
//         /// <param name="message">El mensaje a procesar.</param>
//         /// <param name="response">La respuesta al mensaje procesado.</param>
//         /// <returns>true si el mensaje fue procesado; false en caso contrario.</returns>
//         protected override bool InternalHandle(Message message, out string response)
//         {
//             this.Keywords.Append(message.ToString());
//             if (this.CanHandle(message) || HistorialUser.Instance.Historial[message.From.ToString()].Contains(message.ToString()))
//             {
//                 StringBuilder completeMessage = new StringBuilder();
//                 completeMessage.Append("No reconozco ese comando o esa palabra. Intente de nuevo /Menu ");

//                 response = completeMessage.ToString();
//                 return true;
//             }
//             response = string.Empty;
//             return true;

//         }
//     }
// }