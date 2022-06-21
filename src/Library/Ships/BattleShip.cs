namespace Library
{
    /// <summary>
    /// Buque de guerra que ocupa 3 espacios en nuestro tablero.
    /// </summary>
    public class BattleShip : IShip
    {
        /// <summary>
        /// Nombre del buque.
        /// </summary>
        private string name = "battleship"; 
        /// <summary>
        /// Tamaño del buque.
        /// </summary>
        private const int size = 3;
        /// <summary>
        /// Letra la cual identifica al buque.
        /// </summary>
        private string letterId = "B";

        /// <summary>
        /// Ruta de la imagen vértical que lo representa.
        /// </summary>
        private const string pathV = @"../Library/Images/BattleShipV3.png";
        /// <summary>
        /// Ruta de la imagen horizontal que lo representa.
        /// </summary>
        private const string pathH = @"../Library/Images/BattleShipH3.png";

        /// <summary>
        /// Constructor del buque.
        /// </summary>
        public BattleShip()
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
            set {this.Size=value;}
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
         public bool IsAlive()
        {
            if (this.Size == 0)
            {
                this.Alive = false;
                return false;
            }
            return true;
        }

        /// <summary>
        /// Estado del buque
        /// </summary>
        private bool alive = false;

        public bool Alive { get { return alive; } set { this.alive = value;} }
    }
 }    

    