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
                Console.WriteLine("SearchMatch1");
                HistorialUser.Instance.Historial[message.From.ToString()].Add(message.Text);

                if (HistorialUser.Instance.Historial[message.From.ToString()].Contains("/BuscarPartida") && HistorialUser.Instance.Historial[message.From.ToString()].Count() == 1)
                {
                    Console.WriteLine("SearchMatch2");
                    StringBuilder CompleteMessage = new StringBuilder();
                    CompleteMessage.Append("Seleccione alguna de las siguientes partidas:\n");
                    Console.WriteLine("SearchMatch3");
                    foreach (var (key, value) in HistorialUser.Instance.MatchID)
                    {
                        Console.WriteLine("SearchMatch4");
                        CompleteMessage.Append($"Jugar en la partida de /{UserList.Instance.FindUserById(key).Name}");
                    }

                    response = CompleteMessage.ToString();
                    return true;

                }
                if(HistorialUser.Instance.Historial[message.From.ToString()].Contains("/BuscarPartida") && HistorialUser.Instance.Historial[message.From.ToString()].Count() == 2)
                {
                    StringBuilder CompleteMessage = new StringBuilder();

                    foreach (var (key, value) in HistorialUser.Instance.MatchID)
                    {
                        Console.WriteLine("SearchMatch4");

                        if(message.Text==$"/{UserList.Instance.FindUserById(key).Name}")
                        {
                            Console.WriteLine("SearchMatch5");
                            CompleteMessage.Append($"Te has unido a la partida de {UserList.Instance.FindUserById(key).Name}.\n");
                            User user = UserList.Instance.FindUserById(key);
                            user.JoinMatch(value);
                            CompleteMessage.Append($"A continuacion debera colocar toda su flota...");
                            CompleteMessage.Append($"/COLOCAR_TABLERO");  
                            response = CompleteMessage.ToString();
                            return true;                          
                        }
                    }
                    response = CompleteMessage.ToString();
                    return true;
                }

            }
            response = string.Empty;
            return false;
        }
    }
}