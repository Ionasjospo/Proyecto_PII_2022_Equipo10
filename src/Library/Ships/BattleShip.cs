namespace Library
{
    public class BattleShip : IShip
    {

        private string name = "battleship"; 
        private static int size = 4;

        private static string path = @"BattleShipH4.png";

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
        public string Path
        {
            get { return path; }
        }
        public int Size
        {
            get { return size; }
        }
    }
 }    

