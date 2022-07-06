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
using System.Threading;

namespace Library
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "hola".
    /// </summary>
    public class BattleHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="HelloHandler"/>. Esta clase procesa el mensaje "hola".
        /// </summary>
        /// <param name="next">El próximo "handler".</param>
        public BattleHandler(TelegramBotClient bot, BaseHandler next) : base(next)
        {

            this.Keywords = new string[] { "/Comenzar_combate" };
            this.bot = bot;

        }
        private TelegramBotClient bot;

        /// <summary>
        /// Procesa el mensaje "hola" y retorna true; retorna false en caso contrario.
        /// </summary>
        /// <param name="message">El mensaje a procesar.</param>
        /// <param name="response">La respuesta al mensaje procesado.</param>
        /// <returns>true si el mensaje fue procesado; false en caso contrario.</returns>

        protected override bool InternalHandle(Message message, out string response)
        {
            if (this.CanHandle(message) || HistorialUser.Instance.Historial[message.From.ToString()].Contains("/Comenzar_combate"))
            {
                StringBuilder CompleteMessage = new StringBuilder();
                HistorialUser.Instance.Historial[message.From.ToString()].Add(message.Text);

                Match match = MatchList.Instance.FindMatch(message.From.ToString());

                Player me = match.My(message.From.ToString());
                Player enemy = match.MyEnemy(message.From.ToString());

                BoardWithShips boardenemy = enemy.BoardWithShips as BoardWithShips;
                BoardWithShots myboard = me.BoardWithShoots as BoardWithShots;

            
                if (!boardenemy.ShipReady)
                {
                  CompleteMessage.Append("Tu enemigo todavia no esta listo... espera un momento y ejecute de nuevo el comando /Comenzar_combate nuevamente");
                  HistorialUser.Instance.Historial[message.From.ToString()].Clear();
                  response = CompleteMessage.ToString();
                  return true;
                }
                else
                {
                    CompleteMessage.Append("Tu enemigo esta listo para la batalla, ya es hora del combate!!\n /Atacar");
                    match.NewBattle();
                    HistorialUser.Instance.Historial[message.From.ToString()].Clear();
                    response = CompleteMessage.ToString();
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