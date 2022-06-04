using System;
namespace Library
{
    public class BattleShip : Ship
    {
        public BattleShip (bool live = true, int blocks = 2, string image = " ") : base(live, blocks, image) { }
        
    }
}