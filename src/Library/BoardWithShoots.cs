using System.Collections.Generic;
namespace Library
{
    public class BoardWithShoots : Boards
    {
        public BoardWithShoots()
        {
            this.BoardId = Counter;
            this.CombineImage.MergeMultipleImages(@"..\Library\Images\Background.jpg", @"..\Library\Images\Background.jpg", 0, 0, this);
            this.BoardDefaultPath = @$"..\Library\CombinedImages\Shoots{this.BoardId}.jpg";
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
