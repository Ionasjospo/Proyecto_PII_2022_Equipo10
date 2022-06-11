namespace Library
{
    public class AirCraftCarrier : IShip
    {

        private string name = "aircraftcarrier"; 
        private static int size = 3;

        private static string path = @"AirCraftCarrierH5.png";

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

    