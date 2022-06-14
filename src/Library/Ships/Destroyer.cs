namespace Library
{
    public class Destroyer : IShip
    {

        private string name = "destroyer"; 
        private static int size = 3;

        private static string pathV = @"../Library/Images/DestroyerV4.png";
        private static string pathH = @"../Library/Images/DestroyerH4.png";

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
    }
 }    

    