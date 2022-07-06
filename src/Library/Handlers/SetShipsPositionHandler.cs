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
        /// Inicializa una nueva instancia de la clase <see cref="SetShipsPositionHandler"/>. 
        /// Esta clase procesa el mensaje "Colocar_Tablero".
        /// </summary>
        /// <param name="next">El próximo "handler".</param>
        public SetShipsPositionHandler(TelegramBotClient bot, BaseHandler next) : base(next)
        {
            this.Keywords = new string[] { "/Colocar_Tablero" };
            this.bot = bot;
        }
        private TelegramBotClient bot;

        /// <summary>
        /// Procesa el mensaje "/Colocar_Tablero" y retorna true; retorna false en caso contrario.
        /// </summary>
        /// <param name="message">El mensaje a procesar.</param>
        /// <param name="response">La respuesta al mensaje procesado.</param>
        /// <returns>true si el mensaje fue procesado; false en caso contrario.</returns>
        protected override bool InternalHandle(Message message, out string response)
        {
            if (this.CanHandle(message) || HistorialUser.Instance.Historial[message.From.ToString()].Contains("/Colocar_Tablero"))
            {
                HistorialUser.Instance.Historial[message.From.ToString()].Add(message.Text);
                BoardWithShips board = MatchList.Instance.FindBoard(message.From.ToString()) as BoardWithShips;

                if (HistorialUser.Instance.Historial[message.From.ToString()].Contains("/Colocar_Tablero") && HistorialUser.Instance.Historial[message.From.ToString()].Count() == 1)
                {
                    StringBuilder CompleteMessage = new StringBuilder();

                    AsyncContext.Run(() => SendBoardImage(message, board.BoardDefaultPath));
                    int cont = 0;
                    foreach (var item in board.Ship)
                    {
                        CompleteMessage.Append($"/{cont} - {item.Name} tamaño = {item.Size}\n");
                        cont++;
                    }

                    response = CompleteMessage.ToString();
                    return true;

                }
                if (HistorialUser.Instance.Historial[message.From.ToString()].Contains("/Colocar_Tablero") && HistorialUser.Instance.Historial[message.From.ToString()].Count() == 2)
                {
                    StringBuilder CompleteMessage = new StringBuilder();

                    CompleteMessage.Append($"Nave seleccionada con exito!\n");
                    CompleteMessage.Append($"Debe ingresar la ubicacion que desea y la palabra vertical o horizontal \n");
                    CompleteMessage.Append($"Por ejemplo: x,y,vertical \n");

                    response = CompleteMessage.ToString();
                    return true;

                }
                if (HistorialUser.Instance.Historial[message.From.ToString()].Contains("/Colocar_Tablero") && HistorialUser.Instance.Historial[message.From.ToString()].Count() >= 3)
                {
                    StringBuilder CompleteMessage = new StringBuilder();

                    List<string> list = new List<string>();
                    list = message.Text.Split(',').ToList();
                    int x = Convert.ToInt16(list[0]);
                    int y = Convert.ToInt32(list[1]);

                    string nave = HistorialUser.Instance.Historial[message.From.ToString()][1].Substring(1);
                    int ship = Convert.ToInt32(nave);


                    if (board.SetPosition(board.Ship[ship], x, y, list[2]))
                    {
                        CompleteMessage.Append($"Nave colocada correctamente!!\n");
                        AsyncContext.Run(() => SendBoardImage(message, board.BoardDefaultPath));
                        int cont = 0;
                        foreach (var item in board.Ship)
                        {
                            CompleteMessage.Append($"/{cont} - {item.Name} tamaño = {item.Size}\n");
                            cont++;
                        }
                        if (board.ShipReady)
                        {
                            CompleteMessage.Append($"Tu flota ya esta lista para la batalla!!!\n");
                            CompleteMessage.Append($"/Comenzar_combate\n");
                            HistorialUser.Instance.Historial[message.From.ToString()].Clear();

                        }
                        else
                        {
                            HistorialUser.Instance.Historial[message.From.ToString()].Clear();
                            HistorialUser.Instance.Historial[message.From.ToString()].Add("/Colocar_Tablero");

                        }



                        response = CompleteMessage.ToString();
                        return true;
                    }
                    else
                    {
                        CompleteMessage.Append($"Error al colocar la nave \n");
                        CompleteMessage.Append($"Coloque nuevamente la nave y la posicion de la misma\n");
                        int cont = 0;
                        foreach (var item in board.Ship)
                        {
                            CompleteMessage.Append($"/{cont} - {item.Name} tamaño = {item.Size}\n");
                            cont++;
                        }
                        HistorialUser.Instance.Historial[message.From.ToString()].Clear();
                        HistorialUser.Instance.Historial[message.From.ToString()].Add("/Colocar_Tablero");

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
            User user = UserList.Instance.FindUserById(message.From.ToString());

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
                    caption: $"Tablero de {user.Name} "
                );
            }
        }
    }
}