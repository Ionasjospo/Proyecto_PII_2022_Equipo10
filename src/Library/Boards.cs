using System.Collections.Generic;
namespace Library
{
    public abstract class Boards
    {
        private const int sizeH = 10;
        private const int sizeV = 10;
        private int boardId;
        private static int counter = 0;
        private string boardDefaultPath;
        private string[,] ocean = new string[sizeH, sizeV];
        private Coordinates coordinates = new Coordinates();
        private CombineImage combineImage = new CombineImage();
        private static int controlador = 0;
        public int Counter { get { return counter; } set { counter = value; } }
        public string[,] Ocean { get { return ocean; } set { this.ocean = value; } }
        public int BoardId { get { return this.boardId; } set { this.boardId = value; } }
        public string BoardDefaultPath { get { return this.boardDefaultPath; } set { this.boardDefaultPath = value; } }

        public Coordinates Coordinates { get { return this.coordinates; } set { this.coordinates = value; } }

        public CombineImage CombineImage { get { return this.combineImage; } set { this.combineImage = value; } }

        public int SizeH {get{return sizeH;}}
        public int SizeV {get{return sizeV;}}














    }

}
