using Library;
namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board();
            
            //board.ShowBoard();
            Ship1 ship = new Ship1();
            Batlle batlle = new Batlle();
            //batlle.SetPosition(board,ship,4,7,"abajo");
            batlle.EspecialBombAttack(1,4,board);
            board.ShowBoard();

            
        }
    }
}