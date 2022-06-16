namespace Library
{
    public class AirCraftCarrier : IShip
    {

        private string name = "aircraftcarrier"; 
        private static int size = 5;

        private static string pathV = @"../Library/Images/AirCraftCarrierV5.png";
        private static string pathH = @"../Library/Images/AirCraftCarrierH5.png";

        public AirCraftCarrier()
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

    