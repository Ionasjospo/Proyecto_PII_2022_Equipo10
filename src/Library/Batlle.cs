using System;
using ImageMagick;

namespace Library
{
    public class Batlle
    {
        private Match match{get; set;}

        private string[,] boardA {get; set;}

        private string[,] boardB {get; set;}

        private List<User> ListTurns = new List<User>();

        private  int turn=0;

        private User Winner;

        

        public Battle (Match match)
        {
            this.match = match;

            this.Turns.Add(match.PlayerA1);
            this.Turns.Add(match.PlayerB1);

            if(match.TwoVtwo)
            {
                this.Turns.Add(match.PlayerA2);
                this.Turns.Add(match.PlayerB2);
            }

            for (int i = 0; i < boardA.GetLength(0); i++)
            {
                for (int j = 0; j < boardA.GetLength(1); j++)
                {
                    boardA[i,j]="O";
                }
            }

            for (int i = 0; i < boardB.GetLength(0); i++)
            {
                for (int j = 0; j < boardB.GetLength(1); j++)
                {
                    boardB[i,j]="O";
                }
            }
        }

        public bool VerifyTurn(User user)
        {
            if(turn%2==0)
            {
               if(user = this.ListTurns[0] ) 
               {
                    return true;
               } 
               return false;
            } 
            else 
            {
                if(user = this.ListTurns[1])
                {
                    return true;
                }
                return false;
            }
        }

        public void Attack(int fila, int col, User player)
        {
            if(this.VerifyTurn(player))
            {







               
                
            }
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
