using System;
using System.Text;
namespace Library
{
    /// <summary>
    /// Clase que proporciona un menú a los usuarios.
    /// </summary>
    public static class Menu
    {
        /// <summary>
        /// Despliega el menu de opciones.
        /// </summary>
        public static StringBuilder ShowOptions()
        {
            StringBuilder options = new StringBuilder("The options you have are:  \n Create new 1vs1 match \n Create new 2vs2 match \n Join match");
            return options;
        }
    }
}

