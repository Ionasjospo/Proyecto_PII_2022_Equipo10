using System;
using ImageMagick;

namespace Library
{

    public class Battle
    {
        private Match match { get; set; }


        private List<Player> ListTurns = new List<Player>();

        private int turn = 2;

        private Player Winner;

        private CombineImage combineImage = new CombineImage();

        private Coordinates coordinates = new Coordinates();

        private int shipsDestroys = 0;


        /// <summary>
        /// Constructor de Battle.
        /// </summary>
        /// <param name="match">Partida.</param>
        public Battle(Match match)
        {
            this.match = match;

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
        /// <param name="player">???????</param>
        public void Attack(int col, int fila, Player player1, Player player2, bool SpecialBomb)
        {
            coordinates.transformPosition(col,fila);

            if (this.VerifyTurn() == player1)
            {
                if (player1.BoardWithShoots.Ocean[fila, col] != "X")
                {
                    if (player2.BoardWithShips.Ocean[fila, col] == "O")
                    {
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
                                        this.Winner = player1;
                                        player1.User.AddBattleWon();
                                        HistorialUser.Instance.MatchID.Remove(this.match.PlayerA1.User.Id);
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
