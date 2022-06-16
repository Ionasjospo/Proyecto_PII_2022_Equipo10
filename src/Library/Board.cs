using System.Collections.Generic;
namespace Library
{
    public class Board
    {
        private const int sizeH = 10;
        private const int sizeV = 10;
        private bool shipsReady;
        private int boardId;
        private string[,] ocean = new string[sizeH, sizeV];
        private Coordinates coordinates = new Coordinates();

        private List<IShip> listShip = new List<IShip>();

        public string[,] Ocean
        {
            get { return ocean; }
            //set { this.ocean = value; }
        }
        public int BoardId { get{return this.boardId; } }

        public Board(int boardId) 
        {
            this.shipsReady=false;
            this.boardId=boardId;

            for (int filas = 0; filas < sizeH; filas++)
            {
                for (int col = 0; col < sizeV; col++)
                {
                    ocean[fila,col]=="O";
                }
            }
        }
        public List<IShip> ListShip
        {
            get { return listShip; }
            
        }

        public Board()
        {
            this.shipsReady = false; 
            this.boardId = boardId;
            for (int filas = 0; filas < sizeH; filas++)
            {
                for (int col = 0; col < sizeV; col++)
                {
                    ocean[filas, col] = "O";
                }
            }
        }

        public int SizeH { get{return sizeH;} }
        public int SizeV { get{return sizeV;} }

        private List<string> lettersIds = new List<string>();
        private List<string> horizontalPaths = new List<string>();
        private List<string> verticalPaths = new List<string>();

        //public bool SetPosition(Board board, IShip ship, int fila, int col, string direc)
        public bool SetPosition(IShip ship, int fila, int col, string direc)
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
                                                    this.Ocean[F, C] = ship.LetterId;
                                                }
                                            }
                                            ListShip.Add(ship);
                                            return true;
                                        }
                                        lettersIds.Add(ship.LetterId);
                                        horizontalPaths.Add(ship.PathH);
                                        return true;
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
                                                    this.Ocean[F, C] = ship.LetterId;
                                                }
                                            }
                                            ListShip.Add(ship);
                                            return true;
                                        }
                                        lettersIds.Add(ship.LetterId);
                                        verticalPaths.Add(ship.PathV);
                                        return true;
                                    }
                                }
                            }
                        }
                    }
                }
            return false;
        }
        
        
    }
        public List<string> LettersIds { get{return this.lettersIds;} }
        public List<string> HorizontalPaths { get{return this.horizontalPaths;} }
        public List<string> VerticalPaths { get{return this.verticalPaths;} }
}

}
