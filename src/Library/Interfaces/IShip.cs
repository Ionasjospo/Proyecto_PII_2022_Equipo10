namespace Library
{
    /// <summary>
    /// Interface para generar las distintas naves y lorgar el  mismo comportamiento aunque tengan atributos diferentes.
    /// </summary>
    public interface IShip
    {
        /// <summary>
        /// Nombre de la nave.
        /// </summary>
        /// <value>Name.</value>
        public string Name { get; }
        /// <summary>
        /// Tamaño de la nave.
        /// </summary>
        /// <value>tamaño.</value>
        public int Size { get;}

        /// <summary>
        /// Ruta de la imagen vertical de la nave.
        /// </summary>
        /// <value>path.</value>
        public string PathV { get;}

        /// <summary>
        /// Ruta de la imagen horizontal de la nave.
        /// </summary>
        /// <value>path.</value>
        public string PathH { get;}
    }
}