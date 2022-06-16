using System;
using Library;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board();
            Battle battle = new Battle();
            
            IShip submarine = new Submarine();
            IShip destroyer = new Destroyer();
            IShip battleShip = new BattleShip();
            IShip airCraftCarrier = new AirCraftCarrier();
            
            //ShowBoard.ShowConsoleBoard(board);
            //Console.WriteLine("---------------------------------");

            board.SetPosition(submarine, 0, 3,"horizontal");
            board.SetPosition(battleShip, 3, 0,"vertical");
            board.SetPosition(destroyer, 8, 5, "horizontal");
            board.SetPosition(airCraftCarrier, 3, 4, "vertical");
            ShowBoard.ShowConsoleBoard(board);
            ShowBoard.ShowImageBoard(board);

            

            
            
            // batlle.EspecialBombAttack(2, 4, board);
            // int i = 0;
            // CombineImage combineImage = new CombineImage();
            // combineImage.MergeMultipleImages(@"..\Program\FinalImage.jpg", @$"..\Library\Images\AirCraftCarrierV5.png", 539, 106);

        } 
    }
}  