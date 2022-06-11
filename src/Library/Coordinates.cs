using System;
using Exceptions;

namespace Library
{
    /// <summary>
    /// Clase que convierte las coordenas que el usuario envia para colocar las naves a las posiciones (en pixeles)
    /// en la imagen de la plantilla para colocar los barcos en la posición adecuada. 
    /// /// </summary>
    public class Coordinates
    {
        /// <summary>
        /// Posicion horizontal.
        /// </summary>
        private int x;
        /// <summary>
        /// Posición vertical.
        /// </summary>
        private int y;

        /// <summary>
        /// Largo del lado del cuadrado.
        /// </summary>
        /// <returns></returns>
        private int squareLenghSide = 55;

        /// <summary>
        /// Método que convierte las coordenadas a posiciones en la imagen de fondo.
        /// </summary>
        /// <param name="xpos">Coordenada x.</param>
        /// <param name="ypos">Coordenada y.</param>
        /// <returns>Posiciones x, y para la imagen de fondo.</returns>
        public void transformPosition(int xpos, int ypos)
        {
            transformXposition(xpos);
            transformYposition(ypos);
        }

        /// <summary>
        /// Método que convierte la coordenada x a la posicion correcta de la imagen de fondo.
        /// </summary>
        /// <param name="xpos">Coordenada x.</param>
        /// <returns>Coordenada x para la imagen de fondo.</returns>
        private int transformXposition (int xpos)
        {
            if (xpos == 0)
            {
                x = (51);
            }
            else if (xpos == 1)
            {
                x = (51) + squareLenghSide;
            }
            else if (xpos == 2)
            {
                x = (51) + (2 * squareLenghSide);
            }
            else if (xpos == 3)
            {
                x = (51) + (3 * squareLenghSide);
            }
            else if (xpos == 4)
            {
                x = (51) + (4 * squareLenghSide);
            }
            else if (xpos == 5)
            {
                x = (51) + (5 * squareLenghSide);
            }
            else if (xpos == 6)
            {
                x = (51) + (6 * squareLenghSide);
            }
            else if (xpos == 7)
            {
                x = (51) + (7 * squareLenghSide);
            }
            else if (xpos == 8)
            {
                x = (51) + (8 * squareLenghSide);
            }
            else if (xpos == 9)
            {
                x = (51) + (9 * squareLenghSide);
            }
            else
            {
                throw new PositioNotFoundException("No existe tal coordenada. Intente nuevamente con una posición valida.");
            }
            return x;
        }

        /// <summary>
        /// Método que convierte la coordenada x a la posicion correcta de la imagen de fondo.
        /// </summary>
        /// <param name="ypos">Coordenada y.</param>
        /// <returns>Coordenada y para la imagen de fondo.</returns>
        private int transformYposition (int ypos)
        {
            if (ypos == 0)
            {
                y = (209);
            }
            else if (ypos == 1)
            {
                y = (209) + squareLenghSide;
            }
            else if (ypos == 2)
            {
                y = (209) + (2 * squareLenghSide);
            }
            else if (ypos == 3)
            {
                y = (209) + (3 * squareLenghSide);
            }
            else if (ypos == 4)
            {
                y = (209) + (4 * squareLenghSide);
            }
            else if (ypos == 5)
            {
                y = (209) + (5 * squareLenghSide);
            }
            else if (ypos == 6)
            {
                y = (209) + (6 * squareLenghSide);
            }
            else if (ypos == 7)
            {
                y = (209) + (7 * squareLenghSide);
            }
            else if (ypos == 8)
            {
                y = (209) + (8 * squareLenghSide);
            }
            else if (ypos == 9)
            {
                y = (209) + (9 * squareLenghSide);
            }
            else
            {
                throw new PositioNotFoundException("No existe tal coordenada. Intente nuevamente con una posición valida.");
            }
            return y;
        }

        public int X 
        { 
            get
            {
                return x;
            }
        }
        public int Y 
        { 
            get
            {
                return y;
            } 
        }
    }
}

