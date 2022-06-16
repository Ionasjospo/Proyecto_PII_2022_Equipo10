
namespace Library
{

    public class Board
    {
        private const int sizeH = 10;
        private const int sizeV = 10;
        private bool shipsReady;
        private string[,] ocean = new string[sizeH, sizeV];
        private Coordinates coordinates = new Coordinates();

        private List<IShip> listShip = new List<IShip>();

        public string[,] Ocean
        {
            get { return ocean; }
            //set { this.ocean = value; }
        }

        public List<IShip> ListShip
        {
            get { return listShip; }
            
        }

        public Board()
        {
            this.shipsReady = false; 
            for (int filas = 0; filas < sizeH; filas++)
            {
                for (int col = 0; col < sizeV; col++)
                {
                    ocean[filas, col] = "O";
                }
            }
        }

        public void ShowBoard()
        {
            for (int filas = 0; filas < sizeH; filas++)
            {
                for (int col = 0; col < sizeV; col++)
                {
                    Console.Write(ocean[filas, col]);
                }
                Console.Write("\n");
            }

        }

        private bool SetPosition(IShip ship, int fila, int col, string direc)
        {
            if(!this.ListShip.Contains(ship))
            {  
            coordinates.transformPosition(col, fila);
                if (direc == "horizontal")
                {
                    if ((col + ship.Size) <= 10)
                    {
                        int contador = 0;
                        for (int Fila = 0; Fila < sizeH; Fila++)
                        {
                            for (int Col = 0; Col < sizeV; Col++)
                            {
                                if (Fila == fila && Col < col + ship.Size && Col >= col)
                                {
                                    if (this.Ocean[Fila, Col] == "O")
                                    {
                                        contador++;
                                        if (contador == ship.Size)
                                        {
                                            for (int F = 0; F < sizeH; F++)
                                            {
                                                for (int C = 0; C < sizeV; C++)
                                                {
                                                    if (F == fila && C < col + ship.Size && C >= col)
                                                    {
                                                        this.Ocean[F, C] = "B";
                                                    }
                                                }
                                            }
                                            ListShip.Add(ship);
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
                        for (int Fila = 0; Fila < sizeH; Fila++)
                        {
                            for (int Col = 0; Col < sizeV; Col++)
                            {
                                if (Col == col && Fila < fila + ship.Size && Fila >= fila)
                                {
                                    if (this.Ocean[Fila, Col] == "O")
                                    {
                                        contador++;
                                        if (contador == ship.Size)
                                        {
                                            for (int F = 0; F < sizeH; F++)
                                            {
                                                for (int C = 0; C < sizeV; C++)
                                                {
                                                    if (C == col && F < fila + ship.Size && F >= fila)
                                                    {
                                                        this.Ocean[F, C] = "B";
                                                    }
                                                }
                                            }
                                            ListShip.Add(ship);
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
        }
    }
}