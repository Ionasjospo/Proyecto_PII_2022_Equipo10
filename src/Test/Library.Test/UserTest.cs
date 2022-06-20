using NUnit.Framework;
using Library;

namespace Library.Test
{
    [TestFixture]
    public class UserTest
    {


        /// <summary>
        /// en el Setup:
        ///     -   test0: se agrega un primer User a UserList para poder trabajar con este User en los siguientes casos de Test.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            UserList.Instance.addNewUser("test0");
        }

        /// <summary>
        /// Se verifica que un nuevo usuario pueda agregarse a UserTest, y persista su usuario luego de agregado otros usuarios.
        /// </summary>
        [Test]
        public void NewUserInUserList()
        {
            string test_name = "manolo";
            bool user_exist = false;
            UserList.Instance.addNewUser("test1");
            UserList.Instance.addNewUser("test2");
            UserList.Instance.addNewUser(test_name);
            UserList.Instance.addNewUser("test4");
            UserList.Instance.addNewUser("test5");
            foreach (User user in UserList.Instance.Users)
            {
                if (user.Name == test_name)
                user_exist = true;
            }
            Assert.IsTrue(user_exist);
        }

        /// <summary>
        /// Verifica que se asignen las batallas gandas.
        /// </summary>
        [Test]
        public void CheckBattlesWon()
        {
            int test_battlesWon=13;
            for (int i = 0; i < test_battlesWon; i++)
            {
                UserList.Instance.Users[0].AddBattleWon();
            }
            int user_battlesWon = UserList.Instance.Users[0].BattlesWon;
            Assert.AreEqual(test_battlesWon,user_battlesWon);
        }

        /// <summary>
        /// Se verifica un User luego de ganar "5" batallas, gane una "SpecialBomb".
        /// </summary>        
        [Test]
        public void AddSpecialBombs()
        {
            int test_battlesWon=17;
            int test_specialBombsAdded = 3;
            for (int i = 0; i < test_battlesWon; i++)
            {
                UserList.Instance.Users[0].AddBattleWon();
            }
            int user_specialBombsWon = UserList.Instance.Users[0].SpecialBomb;
            Assert.AreEqual(test_specialBombsAdded, user_specialBombsWon);
        }

        /// <summary>
        /// Se verifica que al hacer uso de SpecialBomb, estas vayan disminuyendo.
        /// </summary>
        [Test]
        public void UseOneSpecialBombs()
        {
            int test_battlesWon=23;
            int test_specialBombsAdded = 4;
            int test_specialBombsRemain = 2;
            for (int i = 0; i < test_battlesWon; i++)
            {
                UserList.Instance.Users[0].AddBattleWon();
            }
            for (int i = 0; i < (test_specialBombsAdded-test_specialBombsRemain); i++)
            {
                UserList.Instance.Users[0].SpecialBombUsed();
            }
            int user_specialBombUsed = UserList.Instance.Users[0].SpecialBomb;

            Assert.AreEqual(test_specialBombsRemain, user_specialBombUsed);
        }

    }

}