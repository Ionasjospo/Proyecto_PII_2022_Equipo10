using System.Collections.Generic;
namespace Library
{
    /// <summary>
    /// Tablero el cual contiene la ubicacion de los buques del jugador.
    /// </summary>
    public class BoardWithShips : Boards
    {
        /// <summary>
        /// Indica si se lo colocaron todos los barcos en el tablero.
        /// </summary>
        private bool shipsReady; 
        /// <summary>
        /// Lista que contiene los barcos colocados.
        /// </summary>
        /// <typeparam name="IShip">Tipo IShip de los buques.</typeparam>
        /// <returns>Los buques colocados.</returns>
        private List<IShip> listShip = new List<IShip>();
        /// <summary>
        /// Lista que contiene los barcos a colocar.
        /// </summary>
        /// <typeparam name="IShip">Tipo IShip</typeparam>
        private List<IShip> ships = new List<IShip>();
        /// <summary>
        /// Constructor del tablero.
        /// </summary>
        public BoardWithShips()
        {
            this.shipsReady = false;
            this.BoardId = Counter;
            this.CombineImage.MergeMultipleImages(@"C:\Images\Background.jpg", @"C:\Images\Background.jpg", 0, 0, this);
            this.BoardDefaultPath = @$"C:\Images\CombinedImages\Board{this.BoardId}.jpg";
            for (int filas = 0; filas < this.SizeH; filas++)
            {
                for (int col = 0; col < this.SizeV; col++)
                {
                    this.Ocean[filas, col] = "O";
                }
            }
            IShip submarine = new Submarine();
            IShip battleShip = new BattleShip();
            IShip destroyer = new Destroyer();
            IShip airCraftCarrier = new AirCraftCarrier();

            Ship.Add(submarine);
            Ship.Add(battleShip);
            Ship.Add(destroyer);
            Ship.Add(airCraftCarrier);
            Counter++;
        }
        /// <summary>
        /// Propiedad que devuelve la lista de los buques colocados.
        /// </summary>
        /// <value>Los buques colocados.</value>
        public List<IShip> ListShip
        {
            get { return listShip; }

        }
        /// <summary>
        /// Metodo para saber si todos los barcos han sido colocados.
        /// </summary>
        /// <value></value>
        public bool ShipReady
        {
            get { return shipsReady; }

        }
        /// <summary>
        /// Método para obtener que barcos faltan para colocar.
        /// </summary>
        /// <value>Barcos por colocar</value>
        public List<IShip> Ship
        {
            get { return this.ships; }

        }
        /// <summary>
        /// Método que verifica si estan todos los buques colocados.
        /// </summary>
        public void Verifyships()
        {
            int contador = 0;
            foreach (var item in Ship)
            {
                if (listShip.Contains(item))
                {
                    contador++;
                }
            }
            if (contador == 4)
            {
                this.shipsReady = true;
            }
        }
        /// <summary>
        /// Método para colocar los buques.
        /// </summary>
        /// <param name="ship">El buque a colocar.</param>
        /// <param name="fila">Fila a colocar.</param>
        /// <param name="col">Columna a colocar.</param>
        /// <param name="direc">Dirección a colocar.</param>
        /// <returns></returns>
        public bool SetPosition(IShip ship, int fila, int col, string direc)
        {
            if (!this.ListShip.Contains(ship))
            {
                this.Coordinates.transformPosition(col, fila);
                if (direc == "horizontal")
                {
                    if ((col + ship.Size) <= 10)
                    {
                        int contador = 0;
                        for (int Fila = 0; Fila < this.SizeH; Fila++)
                        {
                            for (int Col = 0; Col < this.SizeV; Col++)
                            {
                                if (Fila == fila && Col < col + ship.Size && Col >= col)
                                {
                                    if (this.Ocean[Fila, Col] == "O")
                                    {
                                        contador++;
                                        if (contador == ship.Size)
                                        {
                                            for (int F = 0; F < this.SizeH; F++)
                                            {
                                                for (int C = 0; C < this.SizeV; C++)
                                                {
                                                    if (F == fila && C < col + ship.Size && C >= col)
                                                    {
                                                        this.Ocean[F, C] = ship.LetterId;
                                                    }
                                                }
                                            }
                                            CombineImage.MergeMultipleImages(this.BoardDefaultPath, ship.PathH, Coordinates.X, Coordinates.Y, this);
                                            ListShip.Add(ship);
                                            ships.Remove(ship);

                                            this.Verifyships();
                                            return true;
                                        }

                                    }
                                }
                            }
                        }
                    }
                }

                if (direc == "vertical")
                {
                    if ((fila + ship.Size) <= 10)
                    {
                        int contador = 0;
                        for (int Fila = 0; Fila < this.SizeH; Fila++)
                        {
                            for (int Col = 0; Col < this.SizeV; Col++)
                            {
                                if (Col == col && Fila < fila + ship.Size && Fila >= fila)
                                {
                                    if (this.Ocean[Fila, Col] == "O")
                                    {
                                        contador++;
                                        if (contador == ship.Size)
                                        {
                                            for (int F = 0; F < this.SizeH; F++)
                                            {
                                                for (int C = 0; C < this.SizeV; C++)
                                                {
                                                    if (C == col && F < fila + ship.Size && F >= fila)
                                                    {
                                                        this.Ocean[F, C] = ship.LetterId;
                                                    }

                                                }
                                            }
                                            CombineImage.MergeMultipleImages(this.BoardDefaultPath, ship.PathV, Coordinates.X, Coordinates.Y, this);
                                            ListShip.Add(ship);
                                            ships.Remove(ship);

                                            this.Verifyships();
                                            return true;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                return false;
            }
            return false;
        }
    }
}
