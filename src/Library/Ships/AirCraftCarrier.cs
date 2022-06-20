namespace Library
{
    /// <summary>
    /// El Buque de guerra más grande, ocupa 5 espacios en el tablero.
    /// </summary>
    public class AirCraftCarrier : IShip
    {

        /// <summary>
        /// Nombre del buque.
        /// </summary>
        private string name = "aircraftcarrier"; 
        /// <summary>
        /// Tamaño que ocupa en el tablero.
        /// </summary>
        private const int size = 5;
        /// <summary>
        /// Letra la cual identifica al buque.
        /// </summary>
        private string letterId = "A";
        /// <summary>
        /// Ruta de la imagen vértical que lo representa.
        /// </summary>
        private const string pathV = @"../Library/Images/AirCraftCarrierV5.png";
        /// <summary>
        /// Ruta de la imagen horizontal que lo representa.
        /// </summary>
        private const string pathH = @"../Library/Images/AirCraftCarrierH5.png";

        /// <summary>
        /// Constructor del buque.
        /// </summary>
        public AirCraftCarrier()
        {
        }
        
        /// <summary>
        /// Propiedad que devuelve el nombre del buque.
        /// </summary>
        /// <value>Nombre.</value>
        public string Name 
        {
            get 
            {
                return this.name;
            }
        }
        /// <summary>
        /// Propiedad que devuelve el path vértical del buque.
        /// </summary>
        /// <value>Path vértical.</value>
        public string PathV
        {
            get { return pathV; }
        }
        /// <summary>
        /// Propiedad que devuelve el path horizontal del buque.
        /// </summary>
        /// <value>Path horizontal.</value>
        public string PathH
        {
            get { return pathH; }
        }
        
        /// <summary>
        /// Propiedad que devuelve el tamaño del buque.
        /// </summary>
        /// <value>Tamaño del buque.</value>
        public int Size
        {
            get { return size; }
        }
        /// <summary>
        /// Propiedad que devuelve la letra identificadora del buque.
        /// </summary>
        /// <value>Letra identificadora del buque.</value>
        public string LetterId 
        {
            get 
            {
                return this.letterId;
            }
        }
    }
 }    

    