using System;
namespace Library
{
    public abstract class Ship
    {
        protected bool live;
        protected int blocks;

        public bool Live { get{return this.live;} }
        public int Blocks { get{return this.blocks;} }
        
        protected int blocksAlive;
        protected int setPlacesBlock;
        protected int setPlacesDirection;
        
        protected string image;
        public string Image { get{return this.image;} }

        protected Ship(bool live, int blocks, string image)
        {
            this.live = live;
            this.blocks = blocks;
            this.image = image;
        }
    }
}