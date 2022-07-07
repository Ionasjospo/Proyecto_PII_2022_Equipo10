using System;

namespace Library
{
    /// <summary>
    /// Clase que cuenta la cantidad de disparos realizados durante la batalla
    /// </summary>
    public class ShootsCount
    {
        /// <summary>
        /// 
        /// </summary>
        private int water;

        private int ship;
        public int Water
        {
            get {return this.water;}
            set {this.water = value;}
        }
        public int Ship
        {
            get {return this.ship;}
            set {this.ship = value;}
        }


        public ShootsCount()
        {
            this.Water = 0;
            this.Ship = 0;
        }

        public void AddWater()
        {
            this.Water++;
        }

        public void AddShip()
        {
            this.Ship++;
        }
    }
}
