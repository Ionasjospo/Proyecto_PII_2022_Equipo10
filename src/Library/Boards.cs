using System.Collections.Generic;
namespace Library
{
    /// <summary>
    /// Clase abstracta que representa a los tableros.
    /// </summary>
    public abstract class Boards
    {
        /// <summary>
        /// Tamaño horizontal de los tableros.
        /// </summary>
        private const int sizeH = 10;
        /// <summary>
        /// Tamaño vértical de los tableros. 
        /// </summary>
        private const int sizeV = 10;
        /// <summary>
        /// Id que identifica a los tableros.
        /// </summary>
        private int boardId;
        /// <summary>
        /// Contador de los tableros que se crearon.
        /// </summary>
        private static int counter = 0;
        /// <summary>
        /// Path de los tableros vacios.
        /// </summary>
        private string boardDefaultPath;
        /// <summary>
        /// Matríz que representa el oceano.
        /// </summary>
        private string[,] ocean = new string[sizeH, sizeV];
        /// <summary>
        /// Instancia de la clase coordinates.
        /// </summary>
        /// <returns>Coordinates.</returns>
        private Coordinates coordinates = new Coordinates();
        /// <summary>
        /// Instancia de la clase CombineImages.
        /// </summary>
        /// <returns>CombineImages.</returns>
        private CombineImage combineImage = new CombineImage();
        // ????????????????????????????
        private static int controlador = 0;
        /// <summary>
        /// Propiedad que devuelve o "setea" la cantidad de tableros que se craron, sirve para identificar tableros.
        /// </summary>
        /// <value>Número entero</value>
        public int Counter { get { return counter; } set { counter = value; } }
        /// <summary>
        /// Propiedad que devuelve la matríz oceano,
        /// </summary>
        /// <value>Matriz oceano.</value>
        public string[,] Ocean { get { return ocean; } set { this.ocean = value; } }
        /// <summary>
        /// Propiedad que devuelve el id del tablero.
        /// </summary>
        /// <value>Número entero</value>
        public int BoardId { get { return this.boardId; } set { this.boardId = value; } }
        /// <summary>
        /// Propiedad que devuelve o "setea" el path del tablero.
        /// </summary>
        /// <value>string con el path del tablero.</value>
        public string BoardDefaultPath { get { return this.boardDefaultPath; } set { this.boardDefaultPath = value; } }
        /// <summary>
        /// Propiedad que devuelve o "setea" la instacia de Coordinates.
        /// </summary>
        /// <value>Instancia de Coordinates</value>
        public Coordinates Coordinates { get { return this.coordinates; } set { this.coordinates = value; } }
        /// <summary>
        /// Propiedad que devuelve o "setea" la instacia de CombineImage.
        /// </summary>
        /// <value>Instancia de CombineImage</value>
        public CombineImage CombineImage { get { return this.combineImage; } set { this.combineImage = value; } }
        /// <summary>
        /// Propiedad que devuelve el largo del tablero.
        /// </summary>
        /// <value>Largo del tablero</value>
        public int SizeH {get{return sizeH;}}
        /// <summary>
        /// Propiedad que devuelve el ancho del tablero.
        /// </summary>
        /// <value>Ancho del tablero</value>
        public int SizeV {get{return sizeV;}}

        














    }

}
