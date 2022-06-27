using System.Collections.ObjectModel;
using System.Collections.Generic;
using System;

namespace Library
{
    /// <summary>
    /// Clase que garantiza una lista de usuarios.
    /// </summary>
    public class HistorialUser
    {
       
        
        /// <summary>
        /// Historial del usuario para interactuar con el bot
        /// </summary>
        private static HistorialUser historialUser;
        /// <summary>
        /// Para crear o retornar la instancia de HistorialUser, usamos el patrón de singleton.
        /// </summary>
        /// <value></value>
        public static HistorialUser Instance
        {
            get
            {
                if (historialUser == null)
                {
                    historialUser = new HistorialUser();
                }
                return historialUser;
            }
        }
        /// <summary>
        /// Constructor de HistorialUSer.
        /// </summary>
        private HistorialUser ()
        {
            
        }

        public Dictionary<string, Collection<string>> Historial = new Dictionary<string, Collection<string>>();

    }
}
