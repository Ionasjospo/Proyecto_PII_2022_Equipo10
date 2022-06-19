using System.Collections.Generic;
namespace Library
{
    public class BoardWithShips : Boards
    {
        private bool shipsReady;
        private List<IShip> listShip = new List<IShip>();
        private List<IShip> ships = new List<IShip>();

        public BoardWithShips()
        {
            this.shipsReady = false;
            this.BoardId = Counter;
            this.CombineImage.MergeMultipleImages(@"..\Library\Images\Background.jpg", @"..\Library\Images\Background.jpg", 0, 0, this);
            this.BoardDefaultPath = @$"..\Library\CombinedImages\Board{this.BoardId}.jpg";
            for (int filas = 0; filas < this.SizeH; filas++)
            {
                for (int col = 0; col < this.SizeV; col++)
                {
                    this.Ocean[filas, col] = "O";
                }
            }

            IShip submarine = new Submarine();
            IShip destroyer = new Destroyer();
            IShip battleShip = new BattleShip();
            IShip airCraftCarrier = new AirCraftCarrier();

            Ship.Add(submarine);
            Ship.Add(destroyer);
            Ship.Add(battleShip);
            Ship.Add(airCraftCarrier);
            Counter++;

        }

        public List<IShip> ListShip
        {
            get { return listShip; }

        }
        public List<IShip> Ship
        {
            get { return this.ships; }

        }


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
