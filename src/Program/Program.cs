using System;
using Library;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            // Board board = new Board(12345);
            // //Battle battle = new Battle();
            
            // // IShip submarine = new Submarine();
            // // IShip destroyer = new Destroyer();
            // // IShip battleShip = new BattleShip();
            // // IShip airCraftCarrier = new AirCraftCarrier();
            
            // // //ShowBoard.ShowConsoleBoard(board);
            // // //Console.WriteLine("---------------------------------");

            // // board.SetPosition(submarine, 0, 3,"horizontal");
            // // board.SetPosition(battleShip, 3, 0,"vertical");
            // // board.SetPosition(destroyer, 8, 5, "horizontal");
            // // board.SetPosition(airCraftCarrier, 3, 4, "vertical");
            // // ShowBoard.ShowConsoleBoard(board);
            // // ShowBoard.ShowImageBoard(board);

            

            User juan = new User("Juan");
            juan.NewMatch(false);
            Match match =  MatchList.Instance.HistoricMatches[0];
            BoardWithShips boardShip = match.PlayerA1.BoardWithShips as BoardWithShips;
            boardShip.SetPosition(boardShip.Ship[0], 0, 1, "horizontal");
            // boardShip.SetPosition(boardShip.Ship[1], 0, 2, "horizontal");
            
            // // batlle.EspecialBombAttack(2, 4, board);
            // // int i = 0;
            // CombineImage combineImage = new CombineImage();
            // Coordinates coordinates = new Coordinates();
            // coordinates.transformPosition(5,5);
            // combineImage.MergeMultipleImages(@"..\Library\Images\Background.jpg", @"..\Library\Images\TiroEmbocado.png", coordinates.X, coordinates.Y , board);

        } 
    }
}  