using System.Collections.Generic;
namespace Library
{
    public class Board
    {
        private const int sizeH = 10;
        private const int sizeV = 10;
        private bool shipsReady;
        private int boardId;
        private static int counter = 0;
        private string boardDefaultPath;
        private string[,] ocean = new string[sizeH, sizeV];
        private Coordinates coordinates = new Coordinates();
        private CombineImage combineImage = new CombineImage();

        private List<IShip> listShip = new List<IShip>();

        private List<IShip> ships = new List<IShip>();


        private static int controlador = 0;

        public string[,] Ocean
        {
            get { return ocean; }
            //set { this.ocean = value; }
        }
        public Board()
        {
            this.shipsReady = false;
            this.boardId = counter;
            combineImage.MergeMultipleImages(@"..\Library\Images\Background.jpg", @"..\Library\Images\Background.jpg", 0, 0, this);
            this.boardDefaultPath = @$"..\Library\CombinedImages\Board{this.boardId}.jpg";
            for (int filas = 0; filas < sizeH; filas++)
            {
                for (int col = 0; col < sizeV; col++)
                {
                    ocean[filas, col] = "O";
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
            counter++;

        }
        public List<IShip> ListShip
        {
            get { return listShip; }

        }
        public List<IShip> Ship
        {
            get { return this.ships; }

        }

        public int BoardId { get { return this.boardId; } set { this.boardId = value; } }

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


        public int SizeH { get { return sizeH; } }
        public int SizeV { get { return sizeV; } }

        private List<string> lettersIds = new List<string>();
        private List<string> horizontalPaths = new List<string>();
        private List<string> verticalPaths = new List<string>();

        //public bool SetPosition(Board board, IShip ship, int fila, int col, string direc)
        public bool SetPosition(IShip ship, int fila, int col, string direc)
        {
            if (!this.ListShip.Contains(ship))
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
                                                        this.Ocean[F, C] = ship.LetterId;
                                                    }
                                                }
                                            }
                                            combineImage.MergeMultipleImages(this.boardDefaultPath, ship.PathH, coordinates.X, coordinates.Y, this);
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
                                                        this.Ocean[F, C] = ship.LetterId;
                                                    }
                                                    
                                                }
                                            }
                                            combineImage.MergeMultipleImages(this.boardDefaultPath, ship.PathV, coordinates.X, coordinates.Y, this);
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
        public List<string> LettersIds { get { return this.lettersIds; } }
        public List<string> HorizontalPaths { get { return this.horizontalPaths; } }
        public List<string> VerticalPaths { get { return this.verticalPaths; } }
    }

}
