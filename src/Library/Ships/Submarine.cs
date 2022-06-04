using System;
namespace Library
{
    public class Submarine : Ship
    {
        public Submarine (bool live = true, int blocks = 3, string image = " ") : base(live, blocks, image) { }
        
    }
}