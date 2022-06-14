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
        /// Usuario que manda el mensaje ? .
        /// </summary>
       
        /// <summary>
        /// Id del usuario que envia el mensaje.
        /// </summary>
        private int id;

        public Text(User user, string text)
        {
            this.id = user.Id;
            this.text = text;
        }
    }
}
