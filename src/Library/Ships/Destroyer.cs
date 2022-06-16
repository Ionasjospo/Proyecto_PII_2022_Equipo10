namespace Library
{
    public class Destroyer : IShip
    {

        private string name = "destroyer"; 
        private const int size = 4;
        private string letterId = "D";
        private const string pathV = @"../Library/Images/DestroyerV4.png";
        private const string pathH = @"../Library/Images/DestroyerH4.png";

        public Destroyer()
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

    