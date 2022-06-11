namespace Library
{
    public class Jet : IShip
    {

        private string name = "jet"; 
        private static int size = 2;

        private static string path = @"JetH.png";

        public Jet()
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

    