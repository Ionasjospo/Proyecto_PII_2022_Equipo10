
namespace Library
{

    public class Board
    {
        private string[,] board = new string[10, 10];

        public string[,] Ocean
        {
            get { return board; }
            set { this.board = value; }
        }

        public Board()
        {
            for (int filas = 0; filas < board.GetLength(0); filas++)
            {
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    board[filas, col] = "O";
                }
            }
        }

        public void ShowBoard()
        {
            for (int filas = 0; filas < board.GetLength(0); filas++)
            {
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    Console.Write(board[filas, col]);
                }
                Console.Write("\n");
            }

        }
    }
}