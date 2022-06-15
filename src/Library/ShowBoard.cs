using System;
using System.Collections.Generic;
using ImageMagick;

namespace Library
{
    // public enum Paths
    // {
    //     pathSubmarineH,
    //     pathSubmarineV,
    //     pathDestroyerH,
    //     pathDestroyerV,
    //     pathBattleShipH,
    //     pathBattleShipV,
    //     pathAirCraftCarrierH,
    //     pathAirCraftCarrierV
    // }
    public static class ShowBoard
    {
        private static int positionYinColumsn = 0;
        private static bool combinedImage = false;
        private static CombineImage combineImage = new CombineImage();
        private static Coordinates coordinates = new Coordinates();
        private static List<string> lettersIds = new List<string>();
        private static List<string> horizontalPaths = new List<string>();
        private static List<string> verticalPaths = new List<string>();
        //private static Dictionary<string, string> paths = new Dictionary<string, string>();
        private static int i = 0;
        public static bool ShowImageBoard(Board board)
        {
            lettersIds.Add("S");// i=0
            lettersIds.Add("B");// i=1
            lettersIds.Add("D");// i=2
            lettersIds.Add("A");// i=3

            horizontalPaths.Add(@"..\Library\Images\SubmarineH2.png"); // i=0
            verticalPaths.Add(@"..\Library\Images\SubmarineV2.png"); // i=0

            horizontalPaths.Add(@"..\Library\Images\BattleShipH3.png"); // i=1
            verticalPaths.Add(@"..\Library\Images\BattleShipV3.png"); // i=1

            horizontalPaths.Add(@"..\Library\Images\DestroyerH4.png"); // i=2
            verticalPaths.Add(@"..\Library\Images\DestroyerV4.png"); // i=2

            horizontalPaths.Add(@"..\Library\Images\AirCraftCarrierH5.png"); // i=3
            verticalPaths.Add(@"..\Library\Images\AirCraftCarrierV5.png"); // i=3

            while (i != 4)
            {
                for (int positionXinFila = 0; positionXinFila <= board.SizeH - 1; positionXinFila++)
                {
                    for (int positionYinColumn = 0; positionYinColumn < board.SizeV - 1; positionYinColumn++)
                    {
                        if (board.Ocean[positionXinFila, positionYinColumn] == lettersIds[i])
                        {
                            if (board.Ocean[positionXinFila, positionYinColumn + 1] == lettersIds[i])
                            {
                                coordinates.transformPosition(positionYinColumn, positionXinFila);
                                combineImage.MergeMultipleImages(@"..\Program\FinalImage.jpg", horizontalPaths[i], coordinates.X, coordinates.Y);
                                i++;

                            }
                            if (board.Ocean[positionXinFila + 1, positionYinColumn] == lettersIds[i])
                            {
                                coordinates.transformPosition(positionYinColumn, positionXinFila);
                                combineImage.MergeMultipleImages(@"..\Program\FinalImage.jpg", verticalPaths[i], coordinates.X, coordinates.Y);
                                i++;
                            }
                        }
                    }
                }
            }
            return true;
        }
        public static void ShowConsoleBoard(Board board)
        {
            for (int filas = 0; filas < board.SizeH; filas++)
            {
                for (int col = 0; col < board.SizeV; col++)
                {
                    Console.Write(board.Ocean[filas, col]);
                }
                Console.Write("\n");
            }
        }
    }
}
