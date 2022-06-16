namespace Library
{
    public class BattleShip : IShip
    {

        private string name = "battleship"; 
        private const int size = 3;
        private string letterId = "B";

        private const string pathV = @"../Library/Images/BattleShipV3.png";
        private const string pathH = @"../Library/Images/BattleShipH3.png";

        public BattleShip()
        {
        }
        
        public string Name 
        {
            get 
            {
                return this.name;
            }
        }
        public string PathV
        {
            get { return pathV; }
        }

        public string PathH
        {
            get { return pathH; }
        }
        public int Size
        {
            get { return size; }
        }

        public string LetterId 
        {
            get 
            {
                return this.letterId;
            }
        }
    }
 }    

    