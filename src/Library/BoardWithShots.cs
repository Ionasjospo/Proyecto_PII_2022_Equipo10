using System.Collections.Generic;
namespace Library
{
    /// <summary>
    /// Tablero el cual contiene los disparos del jugador.
    /// </summary>
    public class BoardWithShots : Boards
    {
        /// <summary>
        /// Constructor del tablero.
        /// </summary>
        public BoardWithShots()
        {
            this.BoardId = Counter;
            this.CombineImage.MergeMultipleImages(@"C:\Images\Background.jpg", @"C:\Images\Background.jpg", 0, 0, this);
            this.BoardDefaultPath = @$"C:\Images\CombinedImages\Board{this.BoardId}.jpg";
            for (int filas = 0; filas < this.SizeH; filas++)
            {
                for (int col = 0; col < this.SizeV; col++)
                {
                    this.Ocean[filas, col] = "O";
                }
            }
            Counter++;
        }
    }
}
