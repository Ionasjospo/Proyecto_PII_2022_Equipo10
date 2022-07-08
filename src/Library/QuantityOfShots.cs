using System;
using Exceptions;

namespace Library
{
    public class QuantityOfShots
    {
        
        
        
        private int quantityOfWaterShots = 0;

        private int quantityOfShipShots = 0;

        public int QuantityOfWaterShots { get { return this.quantityOfWaterShots; } }
        public int QuantityOfShipShots { get { return this.quantityOfShipShots; } }

        public void AddWaterShot()
        {
            this.quantityOfWaterShots += 1;
        }
        public void AddShipShot()
        {
            this.quantityOfShipShots += 1;
        }
    }
}

