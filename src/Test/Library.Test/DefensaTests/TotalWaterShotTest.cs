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

namespace Library.Test
{
    public class TotalWaterShotsTest
    {


        [SetUp]
        public void Setup()
        {


        }
        
        

        [Test]
        public void TotalWaterShotTest()
        {
            
            UserList.Instance.addNewUser("ionas", "1");
            UserList.Instance.addNewUser("pepe", "2");

            UserList.Instance.FindUserById("1").NewMatch(false);

            UserList.Instance.FindUserById("2").JoinMatch(MatchList.Instance.FindMatch("1"));

            Match match = MatchList.Instance.FindMatch("1");
            match.NewBattle();
            
            match.Battle.Attack(0,0,match.PlayerA1, match.PlayerB1, false);
            match.Battle.Attack(0,3,match.PlayerB1, match.PlayerA1, false);
            match.Battle.Attack(1,0,match.PlayerA1, match.PlayerB1, false);
            match.Battle.Attack(5,0,match.PlayerB1, match.PlayerA1, false);
            match.Battle.Attack(6,0,match.PlayerA1, match.PlayerB1, false);
            match.Battle.Attack(7,0,match.PlayerB1, match.PlayerA1, false);
            match.Battle.Attack(8,0,match.PlayerA1, match.PlayerB1, false);
            match.Battle.Attack(9,0,match.PlayerB1, match.PlayerA1, false);
            
            
            
            

            Assert.AreEqual(8, match.Battle.quantityOfShots.QuantityOfWaterShots);
        }

      

    }
}








