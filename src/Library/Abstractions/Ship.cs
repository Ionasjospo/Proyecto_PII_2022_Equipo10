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

        // no estoy seguro de que hacer con estas 3. 
        protected string image;
        public string Image { get{return this.image;} }


        /// <param name="live"></bool>
        /// <param name="blocks"></int>
        /// <param name="image"></string>
        protected Ship(bool live, int blocks, string image)
        {
            this.live = live;
            this.blocks = blocks;
            this.image = image;
        }
    }
}