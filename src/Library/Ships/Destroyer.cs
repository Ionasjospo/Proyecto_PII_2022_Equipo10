using System;
namespace Library
{
    public class Destroyer : Ship
    {
        public Destroyer (bool live = true, int blocks = 4, string image = " ") : base(live, blocks, image) { }
        
    }
}