using System;
namespace Library
{
    public abstract class Board
    {
        protected int sizeH;
        protected int sizeV;

        public int SizeH { get{return this.sizeH;} }
        public int SizeV { get{return this.sizeV;} }
        
        protected bool shipsReady;
        // public bool ShipsReady {set{}}

        protected List<Ship> shipList;
        public List<Ship> ShipList
        {
            get
            {
                return this.shipList;
            }
        }

        protected char blocks; //{ get{sizeH} get{sizeV}} ?? 


        /// <param name="sizeH"></int>
        /// <param name="sizeV"></int>
        protected Board(int sizeH, int sizeV)
        {
            this.sizeH = sizeH;
            this.sizeV = sizeV;
            shipList = new List<Ship>();
        }

        public void AddShipToLisT (Ship ship)
        {
            this.shipList.Add(ship);
        }
        public void RemoveShipFromList (Ship ship)
        {
            this.shipList.Remove(ship);
        }

        // public void AddShipsToBoards (Ship ship)
        // {

        // }
    }
}