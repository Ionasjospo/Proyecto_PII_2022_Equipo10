
namespace Library
{

    public class Board
    {
        private const int sizeH = 10;
        private const int sizeV = 10;
        private bool shipsReady;
        private string[,] ocean = new string[sizeH, sizeV];
        private Coordinates coordinates = new Coordinates();

        public string[,] Ocean
        {
            get { return ocean; }
            set { this.ocean = value; }
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
            // Console.WriteLine("Estamos crerando los barcos...\n");
            // IShip jet = new Jet();
            // IShip destroyer = new Destroyer();
            // IShip battleShip = new BattleShip();
            // IShip airCraftCarrier = new AirCraftCarrier();
            // Console.WriteLine("... listo,\n");
            // Console.WriteLine("ya podemos comenzar a colocar el primer barco.\n");
            // SetPosition(jet,0,0,"horizontal");
            // Console.WriteLine("Vamos con el segundo barco.\n");
            // SetPosition(jet,1,1,"vertical");
            // Console.WriteLine("Vamos con el tercer barco.\n");
            // SetPosition(jet,2,2,"horizontal");
            // Console.WriteLine("Vamos con el cuarto barco.\n");
            // SetPosition(jet,3,3,"vertical");
            // this.shipsReady = true;
        }

        public int SizeH { get{return sizeH;} }
        public int SizeV { get{return sizeV;} }


        //public bool SetPosition(Board board, IShip ship, int fila, int col, string direc)
        public bool SetPosition(IShip ship, int fila, int col, string direc)
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