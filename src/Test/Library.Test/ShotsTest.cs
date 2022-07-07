using System;
using Library;
using NUnit.Framework;
using System.Collections.Generic;

namespace Library.Test;
public class ShotsTest
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Shots()
    {

        User user1 = new User("Luis Suarez", "91899");
        User user2 = new User("Cavani", "2341");
        UserList.Instance.Users[0].NewMatch(false);
        user1.NewMatch(false);
        Match match = MatchList.Instance.HistoricMatches[0];
        user2.JoinMatch(match);

        Player player1 = new Player(user1);
        Player player2 = new Player(user2);
        BoardWithShips board = new BoardWithShips();
        // BoardWithShips board2 = new BoardWithShips();
        // BoardWithShips board = match.PlayerA1.BoardWithShips as BoardWithShips;
        // BoardWithShips board2 = match.PlayerB1.BoardWithShips as BoardWithShips;
        

        board.SetPosition(board.Ship[0], 0, 0, "vertical");
        board.SetPosition(board.Ship[1], 2, 2, "horizontal");
        // board.SetPosition(board.Ship[2], 4, 4, "vertical");
        // board.SetPosition(board.Ship[3], 5, 2, "horizontal");
        

        match.NewBattle();

        match.Battle.Attack(2, 2, match.PlayerB1, match.PlayerA1, false);
        match.Battle.Attack(0, 0, match.PlayerB1, match.PlayerA1, false);
        match.Battle.Attack(2, 0, match.PlayerB1, match.PlayerA1, false);
        match.Battle.Attack(1, 0, match.PlayerB1, match.PlayerA1, false);
        match.Battle.Attack(2, 4, match.PlayerB1, match.PlayerA1, false);
        match.Battle.Attack(2, 3, match.PlayerB1, match.PlayerA1, false);
        match.Battle.Attack(1, 9, match.PlayerB1, match.PlayerA1, false);
        match.Battle.Attack(6, 6, match.PlayerB1, match.PlayerA1, false);
        match.Battle.Attack(2, 9, match.PlayerB1, match.PlayerA1, false);
        match.Battle.Attack(1, 6, match.PlayerB1, match.PlayerA1, false);
        match.Battle.Attack(3, 9, match.PlayerB1, match.PlayerA1, false);
        match.Battle.Attack(8, 6, match.PlayerB1, match.PlayerA1, false);
        match.Battle.Attack(4, 9, match.PlayerB1, match.PlayerA1, false);
        match.Battle.Attack(3, 7, match.PlayerB1, match.PlayerA1, false);

        Assert.AreEqual(5, match.Battle.ShotsOnShips);
        Assert.AreEqual(8, match.Battle.ShotsOnWater);

    }
}
