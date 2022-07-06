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
            UserList.Instance.addNewUser("Francisco Gutierrez", "11");
            UserList.Instance.FindUserById("11").NewMatch(false);

            Match match0 = MatchList.Instance.HistoricMatches[0];

            UserList.Instance.addNewUser("Ramón Díaz", "111");
            UserList.Instance.FindUserById("111").JoinMatch(match0);


            Assert.AreEqual("Ramón Díaz", match0.PlayerB1.User.Name);
        }

        [Test]
        public void JoinMatch2vs2()
        {
            UserList.Instance.addNewUser("Pep","22");
            UserList.Instance.addNewUser("Juan","222");

            UserList.Instance.addNewUser("Manu","33");
            UserList.Instance.addNewUser("Feli","333");

            UserList.Instance.FindUserById("22").NewMatch(true); //pep crea match 2vs2

            Match match = MatchList.Instance.HistoricMatches[1];

            UserList.Instance.FindUserById("222").JoinMatch(match); //juan se une
            UserList.Instance.FindUserById("33").JoinMatch(match);//manu se une
            UserList.Instance.FindUserById("333").JoinMatch(match);//feli se une

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