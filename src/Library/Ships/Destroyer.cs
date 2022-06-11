namespace Library
{
    public class Destroyer : IShip
    {

        private string name = "destroyer"; 
        private static int size = 3;

        private static string path = @"DestroyerH.png";

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

