namespace Library
{
    public class Submarine : IShip
    {

        private string name = "submarine"; 
        private const int size = 2;
        private  string letterId = "S";
        private const string pathV = @"../Library/Images/SubmarinoV2.png";
        private const string pathH = @"../Library/Images/SubmarinoH2.png";
        //hacer 2 tipos de iship, iverticalship y ihorizontalship y q cada barco 
        //implemente esas 2 abstracciones o que se la pase por parametro algun mensaje que indique si el path es v o h.
        // o simplemente sea submarino.PathV o .PathH
        public Submarine()
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

    