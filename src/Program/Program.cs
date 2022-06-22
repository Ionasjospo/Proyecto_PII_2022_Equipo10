using System;
using Library;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {


            User user = new User("Parizon");
            User user2 = new User("fumeteo");

            user.NewMatch(false);

            Match match = MatchList.Instance.HistoricMatches[0];

            user2.JoinMatch(match);

            BoardWithShips board = match.PlayerA1.BoardWithShips as BoardWithShips;

            BoardWithShips board2 = match.PlayerB1.BoardWithShips as BoardWithShips;

            board.SetPosition(board.Ship[0], 0, 0, "vertical");
            board.SetPosition(board.Ship[1], 2, 4, "horizontal");
            board.SetPosition(board.Ship[2], 0, 4, "horizontal");
            board.SetPosition(board.Ship[3], 7, 2, "horizontal");

            board2.SetPosition(board.Ship[0], 2, 2, "vertical");
            board2.SetPosition(board.Ship[1], 3, 5, "horizontal");
            board2.SetPosition(board.Ship[2], 0, 9, "vertical");
            board2.SetPosition(board.Ship[3], 9, 0, "horizontal");

            match.NewBattle();




            match.Battle.Attack(2, 2, match.PlayerA1, match.PlayerB1, false);
            match.Battle.Attack(0, 6, match.PlayerB1, match.PlayerA1, false);
            match.Battle.Attack(2, 3, match.PlayerA1, match.PlayerB1, false);
            match.Battle.Attack(4, 6, match.PlayerB1, match.PlayerA1, false);
            match.Battle.Attack(0, 9, match.PlayerA1, match.PlayerB1, false);
            match.Battle.Attack(3, 6, match.PlayerB1, match.PlayerA1, false);
            match.Battle.Attack(1, 9, match.PlayerA1, match.PlayerB1, false);
            match.Battle.Attack(6, 6, match.PlayerB1, match.PlayerA1, false);
            match.Battle.Attack(2, 9, match.PlayerA1, match.PlayerB1, false);
            match.Battle.Attack(1, 6, match.PlayerB1, match.PlayerA1, false);
            match.Battle.Attack(3, 9, match.PlayerA1, match.PlayerB1, false);
            match.Battle.Attack(8, 6, match.PlayerB1, match.PlayerA1, false);
            match.Battle.Attack(4, 9, match.PlayerA1, match.PlayerB1, false);
            match.Battle.Attack(3, 7, match.PlayerB1, match.PlayerA1, false);
            match.Battle.Attack(5, 3, match.PlayerA1, match.PlayerB1, false);
            match.Battle.Attack(5, 5, match.PlayerB1, match.PlayerA1, false);
            match.Battle.Attack(6, 3, match.PlayerA1, match.PlayerB1, false);
            match.Battle.Attack(5, 6, match.PlayerB1, match.PlayerA1, false);
            match.Battle.Attack(7, 3, match.PlayerA1, match.PlayerB1, false);
            match.Battle.Attack(4, 4, match.PlayerB1, match.PlayerA1, false);
            match.Battle.Attack(9, 0, match.PlayerA1, match.PlayerB1, false);
            match.Battle.Attack(8, 8, match.PlayerB1, match.PlayerA1, false);
            match.Battle.Attack(9, 1, match.PlayerA1, match.PlayerB1, false);
            match.Battle.Attack(9, 9, match.PlayerB1, match.PlayerA1, false);
            match.Battle.Attack(9, 2, match.PlayerA1, match.PlayerB1, false);
           

            match.PlayerB1.User.AddBattleWon();
            match.PlayerB1.User.AddBattleWon();
            match.PlayerB1.User.AddBattleWon();
            match.PlayerB1.User.AddBattleWon();
            match.PlayerB1.User.AddBattleWon();

            
            match.Battle.SpecialBombAttack(2, 2, match.PlayerB1, match.PlayerA1);


            ShowBoard.ShowConsoleBoard(board2);
            Console.WriteLine("-------------------------------------");
            ShowBoard.ShowConsoleBoard(match.PlayerA1.BoardWithShoots);

            Console.WriteLine(match.PlayerA1.User.BattlesWon);






        }
    }
}