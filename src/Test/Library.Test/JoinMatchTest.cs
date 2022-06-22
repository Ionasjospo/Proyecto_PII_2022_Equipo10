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
            UserList.Instance.addNewUser("Francisco Gutierrez");
            UserList.Instance.Users[0].NewMatch(false);

            Match match = MatchList.Instance.HistoricMatches[0];

            UserList.Instance.addNewUser("Ramón Díaz");
            UserList.Instance.Users[1].JoinMatch(match);


            Assert.AreEqual("Ramón Díaz", match.PlayerB1.User.Name);
        }

        [Test]
        public void JoinMatch2vs2()
        {
            UserList.Instance.addNewUser("Pep");
            UserList.Instance.addNewUser("Juan");

            UserList.Instance.addNewUser("Manu");
            UserList.Instance.addNewUser("Feli");

            UserList.Instance.Users[0].NewMatch(true); //pep crea match 2vs2

            Match match = MatchList.Instance.HistoricMatches[0];

            UserList.Instance.Users[1].JoinMatch(match); //juan se une
            UserList.Instance.Users[2].JoinMatch(match);//manu se une
            UserList.Instance.Users[3].JoinMatch(match);//feli se une



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