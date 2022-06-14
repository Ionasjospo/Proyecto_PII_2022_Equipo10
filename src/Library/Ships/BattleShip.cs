namespace Library
{
    public class BattleShip : IShip
    {

        private string name = "battleship"; 
        private static int size = 4;

        private static string pathV = @"../Library/Images/BattleShipV3.png";
        private static string pathH = @"../Library/Images/BattleShipH3.png";

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
    }
 }    

    