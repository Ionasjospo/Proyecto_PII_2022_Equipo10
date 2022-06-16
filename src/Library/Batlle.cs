using System;
using ImageMagick;

namespace Library
{
    public class Batlle
    {
        private Match match { get; set; }

        private string[,] board1 { get; set; }

        private string[,] board2 { get; set; }

        private List<Player> ListTurns = new List<Player>();

        private int turn = 2;

        private Player Winner;



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

            for (int i = 0; i < boardA.GetLength(0); i++)
            {
                for (int j = 0; j < boardA.GetLength(1); j++)
                {
                    boardA[i, j] = "O";
                }
            }

            for (int i = 0; i < boardB.GetLength(0); i++)
            {
                for (int j = 0; j < boardB.GetLength(1); j++)
                {
                    boardB[i, j] = "O";
                }
            }
        }

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

        public string[,] VerifyBoard()
        {
            if (this.turn % 2 == 0)
            {
                return this.board1;
            }
            else
            {
                return this.board2;
            }

        }


        public void Attack(int fila, int col, Player player)
        {
            if (this.VerifyTurn() == player)
            {
                if (!this.match.BoardA[fila, col] == "O")
                {
                    this.VerifyBoard()[fila,col]="X";
                    
                    this.turn++;
                }



            }

        }

        public bool EspecialBombAttack(int fila, int col, Board board)
        {
            if (board.Ocean[fila, col] == "O")
            {
                board.Ocean[fila, col] = "X";

            }
            if (board.Ocean[fila, col] == "B")
            {
                board.Ocean[fila, col] = "H";

            }

            if (board.Ocean[fila + 1, col] == "O")
            {
                board.Ocean[fila + 1, col] = "X";

            }
            if (board.Ocean[fila + 1, col] == "B")
            {
                board.Ocean[fila + 1, col] = "H";

            }

            if (board.Ocean[fila - 1, col] == "O")
            {
                board.Ocean[fila - 1, col] = "X";

            }
            if (board.Ocean[fila - 1, col] == "B")
            {
                board.Ocean[fila - 1, col] = "H";

            }

            if (board.Ocean[fila, col - 1] == "O")
            {
                board.Ocean[fila, col - 1] = "X";

            }
            if (board.Ocean[fila, col - 1] == "B")
            {
                board.Ocean[fila, col - 1] = "H";

            }

            if (board.Ocean[fila, col + 1] == "O")
            {
                board.Ocean[fila, col + 1] = "X";

            }
            if (board.Ocean[fila, col + 1] == "B")
            {
                board.Ocean[fila, col + 1] = "H";

            }

            return false;
        }

    }

}
