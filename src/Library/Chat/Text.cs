namespace Library
{
    /// <summary>
    /// Clase que representa mensajes.
    /// </summary>
    public class Text
    {
        /// <summary>
        /// string que contiene el mensaje.
        /// </summary>
        private string text;       
        /// <summary>
        /// Jugador que envia el mensaje.
        /// </summary>
        private User user;
        /// <summary>
        /// Constructor del mensaje.
        /// </summary>
        /// <param name="user">Usuario que manda el mensaje.</param>
        /// <param name="text">string con el texto a mandar.</param>
        public Text(User user, string text)
        {
            this.user = user;
            this.text = text;
        }
    }
}
