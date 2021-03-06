namespace Library
{
    /// <summary>
    /// Interfaz para generar los distintas buques y lorgar el  mismo comportamiento aunque tengan atributos diferentes.
    /// </summary>
    public interface IShip
    {
        /// <summary>
        /// Nombre del buque.
        /// </summary>
        /// <value>Name.</value>
        public string Name { get; }
        /// <summary>
        /// Tamaño del buque.
        /// </summary>
        /// <value>tamaño.</value>
        public int Size { get; set; }
        /// <summary>
        /// Ruta de la imagen vertical del buque.
        /// </summary>
        /// <value>path.</value>
        public string PathV { get; }
        /// <summary>
        /// Ruta de la imagen horizontal del buque.
        /// </summary>
        /// <value>path.</value>
        public string PathH { get; }
        /// <summary>
        /// Letra identificadora del buque.
        /// </summary>
        /// <value>Un string con una letra identificadora.</value>
        public string LetterId { get; }
        /// <summary>
        /// Propiedad para saber si el barco esta vivo.
        /// </summary>
        /// <returns>true si esta vivo, false si no esta vivo</returns>
        public bool IsAlive();
        /// <summary>
        /// Determina si esta con vida el barco.
        /// </summary>
        /// <value>true si esta vivo, false si esta hundido</value>
        public bool Alive {get; set;}
    }
}