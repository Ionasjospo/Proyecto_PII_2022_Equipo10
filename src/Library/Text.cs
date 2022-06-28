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
        /// Id del usuario que envia el mensaje.
        /// </summary>
        private int id;
        /// <summary>
        /// Constructor del mensaje.
        /// </summary>
        /// <param name="user">Usuario que manda el mensaje.</param>
        /// <param name="text">string con el texto a mandar.</param>
        public Text(User user, string text)
        {
            //this.id = user.Id;
            this.text = text;
        }
    }
}
