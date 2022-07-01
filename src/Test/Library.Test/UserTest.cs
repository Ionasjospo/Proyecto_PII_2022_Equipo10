// using NUnit.Framework;
// using Library;

// namespace Library.Test
// {
//     [TestFixture]
//     public class UserTest
//     {
//         [SetUp]
//         public void Setup()
//         {
            
//         }

//         [Test]
//         public void CheckBattlesWon()
//         {
//             UserList.Instance.addNewUser("Juan");
//             int test_battlesWon=13;
//             for (int i = 0; i < test_battlesWon; i++)
//             {
//                 UserList.Instance.Users[0].AddBattleWon();
//             }
//             int user_battlesWon = UserList.Instance.Users[0].BattlesWon;
//             Assert.AreEqual(test_battlesWon,user_battlesWon);
//         }
       
//         [Test]
//         public void AddSpecialBombs()
//         {
//             UserList.Instance.addNewUser("Juan");
//             int test_battlesWon=17;
//             int test_specialBombsAdded = 3;
//             for (int i = 0; i < test_battlesWon; i++)
//             {
//                 UserList.Instance.Users[0].AddBattleWon();
//             }
//             int user_specialBombsWon = UserList.Instance.Users[0].SpecialBomb;
//             Assert.AreEqual(test_specialBombsAdded, user_specialBombsWon);
//         }

//         [Test]
//         public void UseOneSpecialBombs()
//         {
//             UserList.Instance.addNewUser("Juan");
            
//             int juanBattlesWon=23;
//             int juanSpecialBombs = 4;            
//             for (int i = 0; i < juanBattlesWon; i++)
//             {
//                 UserList.Instance.Users[0].AddBattleWon();
//             }

//             UserList.Instance.Users[0].SpecialBombUsed();
            
//             int juanSpecialBombsRemain = UserList.Instance.Users[0].SpecialBomb;

//             Assert.AreEqual(3, juanSpecialBombsRemain);
//         }
//     }
// }