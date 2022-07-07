using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InputFiles;
using Nito.AsyncEx;
using System.Text;
using System.Collections.ObjectModel;
using NUnit.Framework;


namespace Library.Test;

public class HeatTest
{


    [SetUp]
    public void Setup()
    {


        UserList.Instance.addNewUser("Richi", "67890");
        UserList.Instance.addNewUser("Ionas", "12345");
        UserList.Instance.addNewUser("Richi2", "321");
        UserList.Instance.addNewUser("Ionas2", "456");

        //Correr los test individualmente
    }

    [Test]
    public void WaterHeatTest()
    {


        UserList.Instance.FindUserById("12345").NewMatch(false);
        Match match = MatchList.Instance.FindMatch("12345");
        UserList.Instance.FindUserById("67890").JoinMatch(match);

        BoardWithShips board1 = match.PlayerA1.BoardWithShips as BoardWithShips;

        BoardWithShips board2 = match.PlayerB1.BoardWithShips as BoardWithShips;



        board1.SetPosition(board1.Ship[3], 1, 1, "vertical");
        board1.SetPosition(board1.Ship[2], 2, 2, "vertical");
        board1.SetPosition(board1.Ship[1], 3, 3, "vertical");
        board1.SetPosition(board1.Ship[0], 4, 4, "vertical");

        board2.SetPosition(board2.Ship[3], 1, 1, "horizontal");
        board2.SetPosition(board2.Ship[2], 2, 2, "horizontal");
        board2.SetPosition(board2.Ship[1], 3, 3, "horizontal");
        board2.SetPosition(board2.Ship[0], 4, 4, "horizontal");

        match.NewBattle();

        match.Battle.Attack(0, 0, match.PlayerA1, match.PlayerB1, false);//AGUA

        match.Battle.Attack(9, 9, match.PlayerB1, match.PlayerA1, false);//AGUA

        match.Battle.Attack(1, 1, match.PlayerA1, match.PlayerB1, false);//BARCO


        Assert.AreEqual(2, match.Battle.WaterHeat);
    }

    [Test]
    public void ShipHeatTest()
    {


        UserList.Instance.FindUserById("321").NewMatch(false);
        Match match = MatchList.Instance.FindMatch("321");
        UserList.Instance.FindUserById("456").JoinMatch(match);

        BoardWithShips board1 = match.PlayerA1.BoardWithShips as BoardWithShips;

        BoardWithShips board2 = match.PlayerB1.BoardWithShips as BoardWithShips;


        board1.SetPosition(board1.Ship[3], 1, 1, "vertical");
        board1.SetPosition(board1.Ship[2], 2, 2, "vertical");
        board1.SetPosition(board1.Ship[1], 3, 3, "vertical");
        board1.SetPosition(board1.Ship[0], 4, 4, "vertical");

        board2.SetPosition(board2.Ship[3], 1, 1, "horizontal");
        board2.SetPosition(board2.Ship[2], 2, 2, "horizontal");
        board2.SetPosition(board2.Ship[1], 3, 3, "horizontal");
        board2.SetPosition(board2.Ship[0], 4, 4, "horizontal");

        match.NewBattle();

        match.Battle.Attack(1, 1, match.PlayerA1, match.PlayerB1, false);//BARCO

        match.Battle.Attack(2, 2, match.PlayerB1, match.PlayerA1, false);//BARCO

        match.Battle.Attack(9, 9, match.PlayerA1, match.PlayerB1, false);//AGUA


        Assert.AreEqual(2, match.Battle.ShipHeat);

    }
   

}
