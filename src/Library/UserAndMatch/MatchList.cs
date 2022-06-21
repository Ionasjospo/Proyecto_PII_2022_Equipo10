using System;
using System.Collections.Generic;

namespace Library
{
    /// <summary>
    /// Lista de partidas jugadas.
    /// </summary>
    public class MatchList
    {
        /// <summary>
        /// Lista que contienen las partidas jugadas.
        /// </summary>
        private List<Match> historicMatches;
        /// <summary>
        /// Propiedad que devuelve las partidas jugadas.
        /// </summary>
        /// <value>Partidas jugadas.</value>
        public List<Match> HistoricMatches
        { get { return this.historicMatches; } }
        /// <summary>
        /// Listas de partidas
        /// </summary>
        private static MatchList matchList;
        /// <summary>
        /// Instacia de MatchList, usamos patron singleton para que solo exista una instacia de esta.
        /// </summary>
        /// <value>MatchList</value>
        public static MatchList Instance
        {
            get
            {
                if (matchList == null)
                {
                    matchList = new MatchList();
                }
                return matchList;
            }
        }
        /// <summary>
        /// Constructor de MatchList
        /// </summary>
        private MatchList ()
        {
            historicMatches = new List<Match>();
        }
        /// <summary>
        /// Método para añadir una nueva partida.
        /// </summary>
        /// <param name="match">Partida a agregar</param>
        public void addNewMatch(Match match)
        {
            historicMatches.Add(match);
        }
    }
}
