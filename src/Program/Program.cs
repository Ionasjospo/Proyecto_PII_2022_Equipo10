using System;
using Library;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board();
            Batlle batlle = new Batlle();
            Ship1 ship1 = new Ship1();
            //IShip ship2 = new Ship2();
            
            // board.ShowBoard();
            // Console.WriteLine("____________________");
            batlle.SetPosition(board, ship1, 4, 2,"derecha");
            //batlle.SetPosition(board, ship2, 4, 1, "derecha");
            // board.ShowBoard();

            // batlle.EspecialBombAttack(2, 4, board);


        } 
    }
}  