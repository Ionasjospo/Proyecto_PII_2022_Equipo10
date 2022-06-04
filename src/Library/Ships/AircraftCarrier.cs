using System;
namespace Library
{
    public class AircraftCarrier : Ship
    {
        public AircraftCarrier (bool live = true, int blocks = 5, string image = " ") : base(live, blocks, image) { }

    }
}