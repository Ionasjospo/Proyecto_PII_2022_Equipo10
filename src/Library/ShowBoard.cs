namespace Library
{
    public static class ShowBoard
    {
        public static void ShowConsoleBoard(Board board)
        {
            for (int filas = 0; filas < board.SizeH; filas++)
            {
                for (int col = 0; col < board.SizeV; col++)
                {
                    Console.Write(board.Ocean[filas, col]);
                }
                
                Console.Write("\n");
            }

        }
    }
}