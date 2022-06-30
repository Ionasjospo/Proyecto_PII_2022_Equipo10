using Telegram.Bot.Types;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InputFiles;

namespace Library
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "hola".
    /// </summary>
    public class SetShipsPositionHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="SetShipsPositionHandler"/>. Esta clase procesa el mensaje "hola".
        /// </summary>
        /// <param name="next">El próximo "handler".</param>
        public SetShipsPositionHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] { "/CrearTablero" };
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
            if (this.CanHandle(message) || HistorialUser.Instance.Historial[message.From.ToString()].Contains("/CrearTablero"))
            {
                Console.WriteLine("match");
                HistorialUser.Instance.Historial[message.From.ToString()].Add(message.Text);

                if (HistorialUser.Instance.Historial[message.From.ToString()].Contains("/CrearTablero") && HistorialUser.Instance.Historial[message.From.ToString()].Count() == 1)
                {
                    StringBuilder completeMessage = new StringBuilder();
                    completeMessage.Append("Has creado el tablero correctamente.\n");

                    response = completeMessage.ToString();
                    return true;

                }
                if (HistorialUser.Instance.Historial[message.From.ToString()].Contains("/CrearPartida") && HistorialUser.Instance.Historial[message.From.ToString()].Count() == 2)
                {
                    StringBuilder completeMessage = new StringBuilder();



                    response = completeMessage.ToString();
                    return true;
                }

            }
            response = string.Empty;
            return false;
        }

        private async Task SendGameImage(Message message)
        {
            // Can be null during testing
            if (bot != null)
            {
                await bot.SendChatActionAsync(message.Chat.Id, ChatAction.UploadPhoto);

                const string filePath = @"..\Library\Images\batallaV2.png";
                using var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
                var fileName = filePath.Split(Path.DirectorySeparatorChar).Last();

                await bot.SendPhotoAsync(
                    chatId: message.Chat.Id,
                    photo: new InputOnlineFile(fileStream, fileName),
                    caption: "-GRUPO 10-"
                );
            }
        }
    }
}