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

        private int shipsDestroys=0;


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

            for (int i = 0; i < match.PlayerA1.BoardWithShips.Ocean.GetLength(0); i++)
            {
                for (int j = 0; j < match.PlayerA1.BoardWithShips.Ocean.GetLength(1); j++)
                {
                    match.PlayerA1.BoardWithShips.Ocean[i, j] = "O";
                }
            }

            for (int i = 0; i < match.PlayerB1.BoardWithShips.Ocean.GetLength(0); i++)
            {
                for (int j = 0; j < match.PlayerB1.BoardWithShips.Ocean.GetLength(0); j++)
                {
                    match.PlayerB1.BoardWithShips.Ocean[i, j] = "O";
                }
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
        public void Attack(int fila, int col, Player player)
        {
            coordinates.transformPosition(fila,col);
            if (this.VerifyTurn() == player)
            {
                if (player.BoardWithShips.Ocean[fila, col] == "O")
                {
                    player.BoardWithShoots.Ocean[fila, col] = "X";
                    combineImage.MergeMultipleImages(player.BoardWithShoots.BoardDefaultPath,@"src\Library\Images\HitOceanShot.png",coordinates.X,coordinates.Y,player.BoardWithShips);
                    
                }
                else
                {
                    player.BoardWithShoots.Ocean[fila, col] = "H";
                    int counter = 0;
                    foreach (IShip ship in player.BoardWithShips.ListShip)
                    {
                        if (player.BoardWithShips.Ocean[fila, col] == ship.LetterId)
                        {
                            player.BoardWithShips.ListShip[counter].Size--;
                            combineImage.MergeMultipleImages(player.BoardWithShoots.BoardDefaultPath,@"src\Library\Images\HitShipShot.png",coordinates.X,coordinates.Y,player.BoardWithShips);
                            if(!player.BoardWithShips.ListShip[counter].IsAlive())
                            {
                                shipsDestroys ++;
                                if (IsChampion())
                                {
                                    this.Winner=player;
                                }
                            }
                        }
                        counter++;
                    }
                }



            }

        }

        public bool IsChampion()
        {
            if(this.shipsDestroys==4)
            {
                return true;
            }
            return false;
        }

        
    }
}
