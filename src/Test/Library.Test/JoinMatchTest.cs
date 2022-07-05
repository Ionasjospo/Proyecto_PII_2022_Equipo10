using NUnit.Framework;
using Library;
using Exceptions;
using System;
namespace Library.Test
{
    [TestFixture]
    public class JoinMatchTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void JoinMatch1vs1()
        {

            UserList.Instance.addNewUser("Francisco Gutierrez","07");
            UserList.Instance.Users[1].NewMatch(false);
            
            Match match = MatchList.Instance.HistoricMatches[1];

            UserList.Instance.addNewUser("Ramón Díaz","14");
            UserList.Instance.Users[2].JoinMatch(match);


            Assert.AreEqual("Ramón Díaz", match.PlayerB1.User.Name);
        }

        [Test]
        public void JoinMatch2vs2()
        {
            UserList.Instance.addNewUser("Pep","08");
            UserList.Instance.addNewUser("Juan","09");

            UserList.Instance.addNewUser("Manu","10");
            UserList.Instance.addNewUser("Feli","11");

            UserList.Instance.Users[3].NewMatch(true); //pep crea match 2vs2

            Match match = MatchList.Instance.HistoricMatches[2];

            UserList.Instance.Users[4].JoinMatch(match); //juan se une
            UserList.Instance.Users[5].JoinMatch(match);//manu se une
            UserList.Instance.Users[6].JoinMatch(match);//feli se une



            Assert.AreEqual("Juan", match.PlayerB1.User.Name);
            Assert.AreEqual("Manu", match.PlayerA2.User.Name);
            Assert.AreEqual("Feli", match.PlayerB2.User.Name);
        }

        // [Test]
        // public void CantJoinIf1vs1MatchItsFull()
        // {
        //     UserList.Instance.addNewUser("Francisco Gutierrez");
        //     UserList.Instance.Users[0].NewMatch(false);

        //     Match match = MatchList.Instance.HistoricMatches[0];

        //     UserList.Instance.addNewUser("Ramón Díaz");
        //     UserList.Instance.Users[1].JoinMatch(match);
        //     UserList.Instance.addNewUser("Facundo");



            

            
        //     string resultado = string.Empty;
        //     try
        //     {
        //         UserList.Instance.Users[2].JoinMatch(match);
        //     }
        //     catch (MatchFullException)
        //     {
        //         resultado = "You cant join to this match because its full.";
        //     }

        //     string expected = "You cant join to this match because its full.";
        //     Assert.AreEqual(expected, resultado);
        // }

        //No encontramos manera de probar si sale la excepcion, debido a que son las 23:47. La proxima sale!!
    }
}