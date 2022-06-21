using System;

namespace Library
{
    /// <summary>
    /// Representa a un jugador.
    /// </summary>
    public class Player
    {
        /// <summary>
        /// Instancia de la clase User.
        /// </summary>
        private User user;
        /// <summary>
        /// Tablero que contiene los buques.
        /// </summary>
        private BoardWithShips boardWithShips;
        /// <summary>
        /// Tablero que contiene los disparos.
        /// </summary>
        private Boards boardWithShots;
        /// <summary>
        /// Propiedad que devuelve el usuario.
        /// </summary>
        /// <value></value>
        public User User 
        { get { return this.user; } }
        /// <summary>
        /// Propiedad que devuelve el tablero con los buques.
        /// </summary>
        /// <value>Tablero con buques.</value>
        public BoardWithShips BoardWithShips
        { get { return this.boardWithShips; } }
        /// <summary>
        /// Propiedad que devuelve el tablero con los disparos realizados.
        /// </summary>
        /// <value>Tablero con disparos.</value>
        public Boards BoardWithShoots 
        { 
            get { return this.boardWithShots; } 
        }
        /// <summary>
        /// Constructor de player.
        /// </summary>
        /// <param name="user">Usuario</param>
        public Player (User user)
        {
            this.user = user;
            this.boardWithShips = new BoardWithShips();
            this.boardWithShots = new BoardWithShots();
        }
        /// <summary>
        /// Constructor de player para partidas 2vs2
        /// </summary>
        /// <param name="user">Usuario.</param>
        /// <param name="player">Jugador.</param>
        public Player (User user, Player player)
        {
            this.user = user;
            this.boardWithShips = player.BoardWithShips;
            this.boardWithShots = player.BoardWithShoots;
        }
    }
}