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
        public SetShipsPositionHandler(TelegramBotClient bot, BaseHandler next) : base(next)
        {
            this.Keywords = new string[]{"/Colocar_Tablero"};
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
            if (this.CanHandle(message) || HistorialUser.Instance.Historial[message.From.ToString()].Contains("/Colocar_Tablero"))
            {
                HistorialUser.Instance.Historial[message.From.ToString()].Add(message.Text);

                if (HistorialUser.Instance.Historial[message.From.ToString()].Contains("/Colocar_Tablero") && HistorialUser.Instance.Historial[message.From.ToString()].Count() == 1)
                {
                    StringBuilder CompleteMessage = new StringBuilder();
                    
                    BoardWithShips board = MatchList.Instance.FindBoard(message.From.ToString()) as BoardWithShips;
                    AsyncContext.Run(() => SendBoardImage(message, board.BoardDefaultPath ));
                    
                    int cont = 0;
                    foreach (var item in board.Ship)
                    {
                        CompleteMessage.Append($"/{cont} - {item.Name} tamaño = {item.Size}\n");
                        cont++;
                    }

              

                    response = CompleteMessage.ToString();
                    return true;

                }
                if(HistorialUser.Instance.Historial[message.From.ToString()].Contains("/CrearPartida") && HistorialUser.Instance.Historial[message.From.ToString()].Count() == 2)
                {
                    StringBuilder CompleteMessage = new StringBuilder();

                    if(message.Text=="/1")
                    {
                        CompleteMessage.Append($"Partida 1vs1 creada.\n");
                        CompleteMessage.Append($"A continuacion debera colocar toda su flota...");
                      
                        response = CompleteMessage.ToString();
                        return true;




                    }
                    if(message.Text=="/2")
                    {


                    }
                   

                    response = CompleteMessage.ToString();
                    return true;
                }

            }
            response = string.Empty;
            return false;
        }

        private async Task SendBoardImage(Message message, string path)
        {
            // Can be null during testing
            if (bot != null)
            {
                await bot.SendChatActionAsync(message.Chat.Id, ChatAction.UploadPhoto);

                string filePath = path;
                using var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
                var fileName = filePath.Split(Path.DirectorySeparatorChar).Last();

                await bot.SendPhotoAsync(
                    chatId: message.Chat.Id,
                    photo: new InputOnlineFile(fileStream, fileName),
                    caption: "Este es tu tablero a colocar"
                );
            }
        }
    }
}