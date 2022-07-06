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
    public class AttackHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="HelloHandler"/>. Esta clase procesa el mensaje "hola".
        /// </summary>
        /// <param name="next">El próximo "handler".</param>
        public AttackHandler(TelegramBotClient bot, BaseHandler next) : base(next)
        {

            this.Keywords = new string[] { "/Atacar" };
            this.bot = bot;

        }
        private TelegramBotClient bot;
        private CombineImage combineImage = new CombineImage();

        /// <summary>
        /// Procesa el mensaje "hola" y retorna true; retorna false en caso contrario.
        /// </summary>
        /// <param name="message">El mensaje a procesar.</param>
        /// <param name="response">La respuesta al mensaje procesado.</param>
        /// <returns>true si el mensaje fue procesado; false en caso contrario.</returns>

        protected override bool InternalHandle(Message message, out string response)
        {
            if (this.CanHandle(message) || HistorialUser.Instance.Historial[message.From.ToString()].Contains("/Atacar"))
            {
                StringBuilder CompleteMessage = new StringBuilder();
                HistorialUser.Instance.Historial[message.From.ToString()].Add(message.Text);

                Match match = MatchList.Instance.FindMatch(message.From.ToString());

                Player me = match.My(message.From.ToString());
                Player enemy = match.MyEnemy(message.From.ToString());

                BoardWithShips boardenemy = enemy.BoardWithShips as BoardWithShips;
                BoardWithShots myboard = me.BoardWithShoots as BoardWithShots;


                if (me == match.Battle.VerifyTurn())
                {
                    if (HistorialUser.Instance.Historial[message.From.ToString()].Contains("/Atacar") && (HistorialUser.Instance.Historial[message.From.ToString()].Count() == 1))
                    {
                        AsyncContext.Run(() => SendBoardImage(message, me.BoardWithShoots.BoardDefaultPath));
                        CompleteMessage.Append("Es tu turno, indique las coordenadas que desea atacar ej: x,y \n");
                        response = CompleteMessage.ToString();
                        return true;
                    }
                    if (HistorialUser.Instance.Historial[message.From.ToString()].Contains("/Atacar") && (HistorialUser.Instance.Historial[message.From.ToString()].Count() == 2))
                    {

                        List<string> list = new List<string>();
                        list = message.Text.Split(',').ToList();
                        int x = Convert.ToInt16(list[0]);
                        int y = Convert.ToInt32(list[1]);

                        match.Battle.Attack(x, y, me, enemy, false);

                    if(match.Battle.Winner == me || match.Battle.Winner==enemy)
                    {
                        combineImage.MergeMultipleImages(me.BoardWithShoots.BoardDefaultPath,@"C:/Images/Winner.png",0,0,me.BoardWithShoots);
                        combineImage.MergeMultipleImages(enemy.BoardWithShoots.BoardDefaultPath,@"C:/Images/Looser.png",0,0,enemy.BoardWithShoots);
                        
                        AsyncContext.Run(() => SendBoardImage(message, me.BoardWithShoots.BoardDefaultPath));
                        
                        AsyncContext.Run(() => SendBoardImage2(message, enemy.BoardWithShoots.BoardDefaultPath,enemy));

                        CompleteMessage.Append("La batalla a finalizado... /Menu");
                        response = CompleteMessage.ToString();
                        return true;



                    }
                    else
                    {
                        AsyncContext.Run(() => SendBoardImage(message, me.BoardWithShoots.BoardDefaultPath));

                        AsyncContext.Run(() => SendMessage(enemy.User, message));

                        CompleteMessage.Append("Esperando al rival... \n");

                        HistorialUser.Instance.Historial[message.From.ToString()].Clear();
                        response = CompleteMessage.ToString();
                        return true;
                    }
                        
                    }

                    HistorialUser.Instance.Historial[message.From.ToString()].Clear();
                    response = CompleteMessage.ToString();
                    return true;
                }
                else
                {
                    CompleteMessage.Append("Espera tu turno!!!");
                    HistorialUser.Instance.Historial[message.From.ToString()].Clear();
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
                    caption: "Mis disparos"
                );
            }
        }

        private async Task SendBoardImage2(Message message, string path, Player enemy)
        {
            
            // Can be null during testing
            if (bot != null)
            {
                await bot.SendChatActionAsync(enemy.User.ChatId, ChatAction.UploadPhoto);

                string filePath = path;
                using var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
                var fileName = filePath.Split(Path.DirectorySeparatorChar).Last();

                await bot.SendPhotoAsync(
                    chatId: enemy.User.ChatId,
                    photo: new InputOnlineFile(fileStream, fileName),
                    caption: "Mis disparos"
                );
            }
        }
        private async Task SendMessage(User user, Message message)
        {
            if (bot != null)
            {
                await bot.SendTextMessageAsync(user.ChatId, "Ya es tu turno, /Atacar");
            }
        }
    }
}