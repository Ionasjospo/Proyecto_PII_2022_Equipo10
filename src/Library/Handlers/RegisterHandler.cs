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
    public class RegisterHandler : BaseHandler
    {
        public RegisterHandler(BaseHandler next) : base(next)
        {

            this.Keywords = new string[] { "/Registrarme" };
        }

        protected override bool InternalHandle(Message message, out string response)
        {
            HistorialUser.Instance.Historial[message.From.ToString()].Add(message.Text);
            bool itsRegister = false;
            int i = 2;

            if (HistorialUser.Instance.Historial[message.From.ToString()].Contains("/Registrarme") && HistorialUser.Instance.Historial[message.From.ToString()].Count() == 1)
            {
                StringBuilder CompleteMessage = new StringBuilder();
                CompleteMessage.Append("A continuacion se va a registrar...\n");
                CompleteMessage.Append("Ingrese su nombre de usuario, recuerde que será para siempre y no lo podra cambiar (Cuanto mas crativo... mejor!) \n");
                response = CompleteMessage.ToString();
                return true;
            }
            StringBuilder completeMessage = new StringBuilder();

            do
            {
                if (HistorialUser.Instance.Historial[message.From.ToString()].Contains("/Registrarme") || HistorialUser.Instance.Historial[message.From.ToString()].Count() == i)
                {

                    if (UserList.Instance.UsernameIsUsed(message.Text.ToString()) == false)
                    {
                        completeMessage.Append($"Su nombre de usuario es: '{message.Text}' \n");
                        completeMessage.Append("Usuario creado con exito!! \n");
                        completeMessage.Append("Para empezar a jugar ingresa al /Menu \n");
                        UserList.Instance.addNewUser(message.Text, message.From.ToString());
                        itsRegister = true;

                        HistorialUser.Instance.Historial[message.From.ToString()].Clear();

                        response = completeMessage.ToString();
                        return true;
                    }
                    else
                    {
                        completeMessage.Clear();
                        i++;

                        //throw new UserNameAlreadyExistException("Pestañaste! , el nombre de usuario que intentaste poner ya lo tiene otra persona. Intente con otro nuevamente.");

                        completeMessage.Append("Pestañaste! , el nombre de usuario que intentaste poner ya lo tiene otra persona. Intente con otro nuevamente. /Registrarme ");

                        response = completeMessage.ToString();
                        return true;
                        //message = new Message();
                    }
                }
            }
            while (!itsRegister);
            response = string.Empty;
            return true;
        }
    }
}
