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
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "hola".
    /// </summary>
    public class ConversationHandler : BaseHandler
    {

        string msj = "";
        User user;
        Match match;
        Conversation conversation;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="ConversationHandler"/>. Esta clase procesa el mensaje "hola".
        /// </summary>
        /// <param name="next">El próximo "handler".</param>
        public ConversationHandler(TelegramBotClient bot, BaseHandler next) : base(next)
        {
            this.Keywords = new string[] { "/Chat" };
            this.bot = bot;
        }
        private TelegramBotClient bot;
        /// <summary>
        /// Procesa el mensaje "Registrarme" y retorna true; retorna false en caso contrario.
        /// </summary>
        /// <param name="message">El mensaje a procesar.</param>
        /// <param name="response">La respuesta al mensaje procesado.</param>
        /// <returns>true si el mensaje fue procesado; false en caso contrario.</returns>
        protected override bool InternalHandle(Message message, out string response)
        {
            if (this.CanHandle(message) || HistorialUser.Instance.Historial[message.From.ToString()].Contains("/Chat"))
            {
                Console.WriteLine("chat");

                HistorialUser.Instance.Historial[message.From.ToString()].Add(message.Text);

                if (HistorialUser.Instance.Historial[message.From.ToString()][0] == "/Chat" && HistorialUser.Instance.Historial[message.From.ToString()].Count() == 1)
                {
                    StringBuilder CompleteMessage = new StringBuilder();
                    try
                    {
                        user = UserList.Instance.FindUserById(message.From.ToString());
                        if (user.UserInMatchRunning())
                        {
                            match = user.MatchesPlayed.Last();
                            CompleteMessage.Append($"¿Qué mensajes quieres enviar?.\n");
                        }
                        else
                        {
                            CompleteMessage.Append($"Debe ingresar a una partida para Chatear con alguien.\n");
                            CompleteMessage.Append($"Vuelva a /Menu para ingresar a una partida.\n");
                            HistorialUser.Instance.Historial[message.From.ToString()].Clear();
                        }

                        

                    }
                    catch (System.Exception e)
                    {
                        msj = "Lamentamos ...\n";
                        throw new CreateMatchException(msj + e.ToString());
                    }
                    finally
                    {
                        CompleteMessage.Append(msj);
                        response = CompleteMessage.ToString();
                    }
                    return true;
                }
                if (HistorialUser.Instance.Historial[message.From.ToString()][0] == "/Chat" && HistorialUser.Instance.Historial[message.From.ToString()].Count() == 2)
                {
                    StringBuilder CompleteMessage = new StringBuilder();
                    try
                    {
                        if (message.Text != null || message.Text != "")
                        {
                            /*
                            conversation = new Conversation();
                            conversation.SendMessage(user, message.Text);
                            */

                            /*
                            AsyncContext.Run(() => SendMessage(match.PlayerA1.User, message.Text));
                            */
                            if (match.PlayerB1 != null)
                            {
                                /*
                                AsyncContext.Run(() => SendMessage(match.PlayerB1.User, message.Text));
                                */
                            }
                            if (match.TwoVtwo)
                            {
                                if (match.PlayerA2 != null)
                                    AsyncContext.Run(() => SendMessage(match.PlayerA2.User, message.Text));
                                if (match.PlayerB2 != null)
                                    AsyncContext.Run(() => SendMessage(match.PlayerB2.User, message.Text));
                            }
                        }
                    }
                    catch (System.Exception e)
                    {
                        msj = "Lamentamos que...\n";
                        throw new CreateMatchException(msj + e.ToString());
                    }
                    finally
                    {
                        CompleteMessage.Append(msj);
                        HistorialUser.Instance.Historial[message.From.ToString()].Clear();
                        response = CompleteMessage.ToString();
                    }
                    return true;
                }
                if (HistorialUser.Instance.Historial[message.From.ToString()][0] == "/Chat" && HistorialUser.Instance.Historial[message.From.ToString()].Count() == 3)
                {
                    StringBuilder CompleteMessage = new StringBuilder();
                    try
                    {
                        if (message.Text == "/Aliado")
                        {
                            UserList.Instance.addNewUser(message.Text, message.From.ToString());
                            Conversation conversation = new Conversation();
                            //conversation.SendMessage(user)

                        }
                        if (message.Text == "/Enemigo")
                        {

                        }
                    }
                    catch (System.Exception e)
                    {
                        msj = "Lamentamos que...\n";
                        throw new CreateMatchException(msj + e.ToString());
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

        private async Task SendMessage(User user, string message)
        {
            if (bot != null)
            {
                //await bot.SendTextMessageAsync(user.Id, message);
                //await bot.SendTextMessage(user.Id, message);
            }
        }
    }
}