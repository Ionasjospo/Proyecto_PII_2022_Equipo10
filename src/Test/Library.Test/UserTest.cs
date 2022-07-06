using NUnit.Framework;
using Library;

namespace Library.Test
{
    [TestFixture]
    public class UserTest
    {
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void CheckBattlesWon()
        {
            UserList.Instance.addNewUser("Juan", "1000");
            int test_battlesWon=13;
            for (int i = 0; i < test_battlesWon; i++)
            {
                UserList.Instance.FindUserById("1000").AddBattleWon();
            }
            int user_battlesWon = UserList.Instance.FindUserById("1000").BattlesWon;
            Assert.AreEqual(test_battlesWon,user_battlesWon);
        }
       
        [Test]
        public void AddSpecialBombs()
        {
            UserList.Instance.addNewUser("Juanjo","1200");
            int test_battlesWon=17;
            int test_specialBombsAdded = 3;
            for (int i = 0; i < test_battlesWon; i++)
            {
                UserList.Instance.FindUserById("1200").AddBattleWon();
            }
            int user_specialBombsWon = UserList.Instance.FindUserById("1200").SpecialBomb;
            Assert.AreEqual(test_specialBombsAdded, user_specialBombsWon);
        }

        [Test]
        public void UseOneSpecialBombs()
        {
            UserList.Instance.addNewUser("JuanJose", "2");
            
            int juanBattlesWon=23;
            int juanSpecialBombs = 4;            
            for (int i = 0; i < juanBattlesWon; i++)
            {
                UserList.Instance.FindUserById("2").AddBattleWon();
            }

            UserList.Instance.FindUserById("2").SpecialBombUsed();
            
            int juanSpecialBombsRemain = UserList.Instance.FindUserById("2").SpecialBomb;

            Assert.AreEqual(3, juanSpecialBombsRemain);
        }
        
        [Test]
        public void FindUser()
        {
            UserList.Instance.addNewUser("pepe", "19");
            
            Assert.AreEqual("pepe", UserList.Instance.FindUserById("19").Name);
        }
        [Test]
        public void CreateNewUser()
        {
            UserList.Instance.addNewUser("ionas", "9");
            Assert.IsTrue(UserList.Instance.IdItsUsed("9"));
        }
    }
}