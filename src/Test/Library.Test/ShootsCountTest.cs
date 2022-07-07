using System;
using Library;
using NUnit.Framework;
using System.Collections.Generic;

namespace Library.Test
{
    public class ShootsCountTest
    {
        [SetUp]
        public void Setup()
        {


        }

        [Test]
        public void ShootsCounter_Water()
        {
            User user = new User("pepe", "123456789_1");
            Match match = new Match(user, false);
            Battle battle = new Battle(match);

            int water_test = 15;
            for (int i = 0; i < water_test; i++)
            {
                battle.Shoots.AddWater();
            }
            int water_real = battle.Shoots.Water;

            Assert.AreEqual(water_test, water_real);
        }
        
        [Test]
        public void ShootsCounter_Ship()
        {
            User user = new User("pepe", "123456789_2");
            Match match = new Match(user, false);
            Battle battle = new Battle(match);

            int ship_test = 15;
            for (int i = 0; i < ship_test; i++)
            {
                battle.Shoots.AddShip();
            }
            int ship_real = battle.Shoots.Ship;

            Assert.AreEqual(ship_test, ship_real);
        }


    }
}





