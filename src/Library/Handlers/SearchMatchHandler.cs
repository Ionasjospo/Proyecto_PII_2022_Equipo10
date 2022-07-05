using Telegram.Bot.Types;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Exceptions;

namespace Library
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "BuscarPartida".
    /// </summary>
    public class SearchMatchHandler : BaseHandler
    {
        string msj = "";
        User user;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="SearchMatchHandler"/>. 
        /// Esta clase procesa el mensaje "BuscarPartida".
        /// </summary>
        /// <param name="next">El próximo "handler".</param>
        public SearchMatchHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] { "/BuscarPartida" };
        }

        /// <summary>
        /// Procesa el mensaje "BuscarPartida" y retorna true; retorna false en caso contrario.
        /// </summary>
        /// <param name="message">El mensaje a procesar.</param>
        /// <param name="response">La respuesta al mensaje procesado.</param>
        /// <returns>true si el mensaje fue procesado; false en caso contrario.</returns>
        protected override bool InternalHandle(Message message, out string response)
        {
            if (this.CanHandle(message) || HistorialUser.Instance.Historial[message.From.ToString()].Contains("/BuscarPartida"))
            {
                Console.WriteLine("BuscarPartida");
                HistorialUser.Instance.Historial[message.From.ToString()].Add(message.Text);

                //if (HistorialUser.Instance.Historial[message.From.ToString()].Contains("/BuscarPartida") && HistorialUser.Instance.Historial[message.From.ToString()].Count() == 1)
                if (HistorialUser.Instance.Historial[message.From.ToString()][0]==("/BuscarPartida") && HistorialUser.Instance.Historial[message.From.ToString()].Count() == 1)
                {
                    StringBuilder CompleteMessage = new StringBuilder();
                    try
                    {
                        user = UserList.Instance.FindUserById(message.From.ToString());
                        if (user.UserInMatchRunning())
                        {
                            CompleteMessage.Append($"Usted ya está jugando en una partida.\n");
                            CompleteMessage.Append($"Si lo desea, puede iniciar un /Chat con los demás jugadores");
                        }
                        else
                        {
                            CompleteMessage.Append("Seleccione alguna de las siguientes partidas:\n");
                            int cont = 0;
                            foreach (Match match in MatchList.Instance.HistoricMatches)
                            {
                                string twovtwo = "1vs1";
                                if (match.OpenToJoin)
                                {
                                    if (match.TwoVtwo)
                                        twovtwo = "2vs2";
                                    CompleteMessage.Append($"Jugar en la partida n° /{cont} del tipo {twovtwo}. \n");
                                }
                                cont++;
                            }
                            if (cont == 0)
                            {
                                msj = "No hay partidas disponibles para unirse \n Tu puedes también /CrearPartida !!";
                                HistorialUser.Instance.Historial[message.From.ToString()].Clear();
                            } 
                        }
                    }
                    catch (System.Exception)
                    {
                        msj = "Ocurrió un error al intentar buscar partidas para unirse. \n";
                        throw new MatchOpenToJoinException(msj);
                    }
                    finally
                    {
                        CompleteMessage.Append(msj);
                        response = CompleteMessage.ToString();
                    }                    
                    return true;
                }
                //if (HistorialUser.Instance.Historial[message.From.ToString()].Contains("/BuscarPartida") && HistorialUser.Instance.Historial[message.From.ToString()].Count() == 2)
                if (HistorialUser.Instance.Historial[message.From.ToString()][0]==("/BuscarPartida") && HistorialUser.Instance.Historial[message.From.ToString()].Count() == 2)
                {
                    StringBuilder CompleteMessage = new StringBuilder();
                    try
                    {
                        string matchNum = message.Text.Substring(1);
                        Match match = MatchList.Instance.HistoricMatches[Convert.ToInt32(matchNum)];
                        if (!match.OpenToJoin)
                        {
                            msj = "Lamentamos que ya se ha completado esa partida, \n Pudes volver a /BuscarPartida \n También puedes /CrearPartida !!";
                            HistorialUser.Instance.Historial[message.From.ToString()].Clear();
                        }
                        else
                        {
                            bool mainUser = true;
                            if (user.JoinMatch(match))
                            {
                                CompleteMessage.Append($"Te has unido a la partida de {match.PlayerA1.User.Name}.\n");
                                if (match.TwoVtwo)
                                {
                                    if (match.PlayerA2 != null)
                                    {
                                        if (match.PlayerA2.User == user)
                                        {
                                            mainUser = false;
                                        }
                                    }
                                    if (match.PlayerB2 != null)
                                    {
                                        if (match.PlayerB2.User == user)
                                        {
                                            mainUser = false;
                                        }
                                    }
                                }
                                if (mainUser)
                                {
                                    CompleteMessage.Append($"A continuacion debera colocar toda su flota...");
                                    CompleteMessage.Append($"/Colocar_Tablero");
                                }
                                else
                                {
                                    CompleteMessage.Append($"Aguarde a que los jugadores principales finalicen con la colocación de los barcos para comenzar la Batalla.\n");
                                    CompleteMessage.Append($"Si lo desea, puede iniciar un /Chat con los demás jugadores");
                                }
                            }
                            else
                            {
                                CompleteMessage.Append($"Usted ya está jugando en este partida, aguarde a que comience la batalla.\n");
                                CompleteMessage.Append($"Si lo desea, puede iniciar un /Chat con los demás jugadores");
                            }
                        }
                    }
                    catch (System.Exception e)
                    {
                        msj = "Lamentamos que no es posible unirse a una partida.\n";
                        throw new MatchFullPlayersException(msj + e.ToString());
                    }
                    finally
                    {
                        CompleteMessage.Append(msj);
                        HistorialUser.Instance.Historial[message.From.ToString()].Clear();
                        response = CompleteMessage.ToString();                        
                    }
                    return true;
                }
            }

            response = string.Empty;
            return false;
        }
    }
}