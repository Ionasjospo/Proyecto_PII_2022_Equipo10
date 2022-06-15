using System;
using ImageMagick;

namespace Library
{
    public class Battle
    {
        private CombineImage combineImage = new CombineImage();
        private Coordinates coordinates = new Coordinates();
       

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
