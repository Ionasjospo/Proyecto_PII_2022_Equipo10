using System;
using ImageMagick;

namespace Library
{

    public class Batlle
    {
        private CombiningImagesSamples combiningImagesSamples = new CombiningImagesSamples();
        private Coordinates coordinates = new Coordinates();
        public bool SetPosition(Board board, Ship1 ship, int fila, int col, string direc)
        {
            coordinates.transformPosition(fila, col);
            if (direc == "derecha")
            {
                if ((col + ship.Size) <= 10)
                {
                    int contador = 0;
                    for (int Fila = 0; Fila < board.Ocean.GetLength(0); Fila++)
                    {
                        for (int Col = 0; Col < board.Ocean.GetLength(1); Col++)
                        {
                            if (Fila == fila && Col < col + ship.Size && Col >= col)
                            {
                                if (board.Ocean[Fila, Col] == "O")
                                {
                                    contador++;
                                    if (contador == ship.Size)
                                    {
                                        for (int F = 0; F < board.Ocean.GetLength(0); F++)
                                        {
                                            for (int C = 0; C < board.Ocean.GetLength(1); C++)
                                            {
                                                if (F == fila && C < col + ship.Size && C >= col)
                                                {
                                                    //board.Ocean[F, C] = "B";
                                                    combiningImagesSamples.MergeMultipleImages(@"Background.jpg", ship.Path, coordinates.X, coordinates.Y);
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

            if (direc == "izquierda")
            {
                if ((col - ship.Size) >= 0)
                {
                    int contador = 0;
                    col = col - ship.Size + 1;
                    for (int Fila = 0; Fila < board.Ocean.GetLength(0); Fila++)
                    {
                        for (int Col = 0; Col < board.Ocean.GetLength(1); Col++)
                        {
                            if (Fila == fila && Col < col + ship.Size && Col >= col)
                            {
                                if (board.Ocean[Fila, Col] == "O")
                                {
                                    contador++;
                                    if (contador == ship.Size)
                                    {
                                        for (int F = 0; F < board.Ocean.GetLength(0); F++)
                                        {
                                            for (int C = 0; C < board.Ocean.GetLength(1); C++)
                                            {
                                                if (F == fila && C < col + ship.Size && C >= col)
                                                {
                                                    board.Ocean[F, C] = "B";
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
            if (direc == "abajo")
            {
                if ((fila + ship.Size) <= 10)
                {
                    int contador = 0;
                    for (int Fila = 0; Fila < board.Ocean.GetLength(0); Fila++)
                    {
                        for (int Col = 0; Col < board.Ocean.GetLength(1); Col++)
                        {
                            if (Col == col && Fila < fila + ship.Size && Fila >= fila)
                            {
                                if (board.Ocean[Fila, Col] == "O")
                                {
                                    contador++;
                                    if (contador == ship.Size)
                                    {
                                        for (int F = 0; F < board.Ocean.GetLength(0); F++)
                                        {
                                            for (int C = 0; C < board.Ocean.GetLength(1); C++)
                                            {
                                                if (C == col && F < fila + ship.Size && F >= fila)
                                                {
                                                    board.Ocean[F, C] = "B";
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
            if (direc == "arriba")
            {
                if ((fila - ship.Size) <= 0)
                {
                    int contador = 0;
                    fila = fila - ship.Size + 1;
                    for (int Fila = 0; Fila < board.Ocean.GetLength(0); Fila++)
                    {
                        for (int Col = 0; Col < board.Ocean.GetLength(1); Col++)
                        {
                            if (Col == col && Fila < fila + ship.Size && Fila >= fila)
                            {
                                if (board.Ocean[Fila, Col] == "O")
                                {
                                    contador++;
                                    if (contador == ship.Size)
                                    {
                                        for (int F = 0; F < board.Ocean.GetLength(0); F++)
                                        {
                                            for (int C = 0; C < board.Ocean.GetLength(1); C++)
                                            {
                                                if (C == col && F < fila + ship.Size && F >= fila)
                                                {
                                                    board.Ocean[F, C] = "B";
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

        public bool Attack(int fila, int col, Board board)
        {
            if(board.Ocean[fila,col]=="O")
            {   
                board.Ocean[fila,col]="X";
                return false;
            }
            if(board.Ocean[fila,col]=="B")
            {
                board.Ocean[fila,col]="H";
                return true;
            }
            return false;
        }

        public bool EspecialBombAttack(int fila, int col, Board board)
        {
            if(board.Ocean[fila,col]=="O")
            {   
                board.Ocean[fila,col]="X";
               
            }
            if(board.Ocean[fila,col]=="B")
            {
                board.Ocean[fila,col]="H";
                
            }

             if(board.Ocean[fila+1,col]=="O")
            {   
                board.Ocean[fila+1,col]="X";
               
            }
            if(board.Ocean[fila+1,col]=="B")
            {
                board.Ocean[fila+1,col]="H";
                
            }

             if(board.Ocean[fila-1,col]=="O")
            {   
                board.Ocean[fila-1,col]="X";
               
            }
            if(board.Ocean[fila-1,col]=="B")
            {
                board.Ocean[fila-1,col]="H";
                
            }

            if(board.Ocean[fila,col-1]=="O")
            {   
                board.Ocean[fila,col-1]="X";
               
            }
            if(board.Ocean[fila,col-1]=="B")
            {
                board.Ocean[fila,col-1]="H";
                
            }

            if(board.Ocean[fila,col+1]=="O")
            {   
                board.Ocean[fila,col+1]="X";
               
            }
            if(board.Ocean[fila,col+1]=="B")
            {
                board.Ocean[fila,col+1]="H";
                
            }

           return false;
        }

    }

}
