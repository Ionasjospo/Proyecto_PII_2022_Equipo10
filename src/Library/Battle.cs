using System;
using ImageMagick;

namespace Library
{
    /// <summary>
    /// Clase que representa la batalla.
    /// </summary>
    public class Battle
    {
        /// <summary>
        /// Instancia de match.
        /// </summary>
        /// <value>Match</value>
        private Match match { get; set; }
        /// <summary>
        /// Lista que lleva los turnos para atacar.
        /// </summary>
        /// <typeparam name="Player">Jugadores que quieren atacar</typeparam>
        /// <returns></returns>
        private List<Player> ListTurns = new List<Player>();
        /// <summary>
        /// Atributo que sirve para determinar que jugador debe atacar.
        /// </summary>
        private int turn = 2;
        /// <summary>
        /// Jugador ganador de la partida.
        /// </summary>
        private Player winner;
        /// <summary>
        /// Propiedad que devuelve el jugador que ganó.
        /// </summary>
        /// <value>Player</value>
        public Player Winner { get {return this.winner;}}
        /// <summary>
        /// Instancia de CombineImage.
        /// </summary>
        /// <returns>CombineImage</returns>
        private CombineImage combineImage = new CombineImage();
        /// <summary>
        /// Intancia de coordinates.
        /// </summary>
        /// <returns>Coordinates</returns>
        private Coordinates coordinates = new Coordinates();
        /// <summary>
        /// Atributo para contar los barcos que han sidos destruidos.
        /// </summary>
        private int shipsDestroys = 0;

        private ShootsCount shoots;

        public ShootsCount Shoots
        {
            get 
            { 
                return this.shoots;
            }
        } 

        /// <summary>
        /// Constructor de Battle.
        /// </summary>
        /// <param name="match">Partida.</param>
        public Battle(Match match)
        {
            this.match = match;
            this.shoots = new ShootsCount();

            this.ListTurns.Add(match.PlayerA1);
            this.ListTurns.Add(match.PlayerB1);

            if (match.TwoVtwo)
            {
                this.ListTurns.Add(match.PlayerA2);
                this.ListTurns.Add(match.PlayerB2);
                this.turn = 4;
            }

            
        }
        /// <summary>
        /// Método para verifica de quien es el turno.
        /// </summary>
        /// <returns>Jugador que tiene el turno.</returns>
        public Player VerifyTurn()
        {
            if (!this.match.TwoVtwo)
            {
                int turn = this.turn % 2;
                return ListTurns[turn];
            }
            else
            {
                int turn = this.turn % 4;
                return ListTurns[turn];
            }
        }
        /// <summary>
        /// Método para que un jugador pueda atacar.
        /// </summary>
        /// <param name="fila">Fila a atacar.</param>
        /// <param name="col">Columna a atacar.</param>
        /// <param name="player1">Jugador que ataca.</param>
        /// <param name="player2">Jugador atacado.</param>

        public void Attack(int col, int fila, Player player1, Player player2, bool SpecialBomb)
        {
            coordinates.transformPosition(col,fila);

            if (this.VerifyTurn() == player1)
            {
                if (player1.BoardWithShoots.Ocean[fila, col] != "X")
                {
                    if (player2.BoardWithShips.Ocean[fila, col] == "O")
                    {
                        Shoots.AddWater();
                        player1.BoardWithShoots.Ocean[fila, col] = "X";
                        combineImage.MergeMultipleImages(player1.BoardWithShoots.BoardDefaultPath, @"C:\Images\HitOceanShot.png", coordinates.X, coordinates.Y, player1.BoardWithShoots);
                        if (!SpecialBomb)
                        {
                            this.turn++;
                        }
                    }
                    else
                    {
                        player1.BoardWithShoots.Ocean[fila, col] = "H";
                        Shoots.AddShip();
                        int counter = 0;
                        BoardWithShips boardWithShips = player2.BoardWithShips as BoardWithShips;
                        foreach (IShip ship in boardWithShips.ListShip)
                        {
                            if (player2.BoardWithShips.Ocean[fila, col] == ship.LetterId)
                            {
                                boardWithShips.ListShip[counter].Size--;
                                combineImage.MergeMultipleImages(player1.BoardWithShoots.BoardDefaultPath, @"C:\Images\HitShipShot.png", coordinates.X, coordinates.Y, player1.BoardWithShoots);
                                if (!boardWithShips.ListShip[counter].IsAlive())
                                {
                                    shipsDestroys++;
                                    if (IsChampion())
                                    {
                                        this.winner = player1;
                                        player1.User.AddBattleWon();
                                    }
                                }
                            }
                            counter++;
                        }
                        if (!SpecialBomb)
                        {
                            this.turn++;
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Método para atacar con la bomba especial.
        /// </summary>
        /// <param name="fila">Fila</param>
        /// <param name="col">Columna</param>
        /// <param name="player1">Jugador que ataca</param>
        /// <param name="player2">Jugador que es atacado</param>
        public void SpecialBombAttack(int fila, int col, Player player1, Player player2)
        {
            if (player1.User.SpecialBomb > 0)
            {
                Attack(fila, col, player1, player2, true);
                Attack(fila - 1, col, player1, player2, true);
                Attack(fila + 1, col, player1, player2, true);
                Attack(fila, col - 1, player1, player2, true);
                Attack(fila, col + 1, player1, player2, true);

                player1.User.SpecialBombUsed();
            }
        }
        /// <summary>
        /// Metodo para determinar si el jugador es el ganador.
        /// </summary>
        /// <returns></returns>
        public bool IsChampion()
        {
            if (this.shipsDestroys == 4)
            {
                return true;
            }
            return false;
        }
    }
}
