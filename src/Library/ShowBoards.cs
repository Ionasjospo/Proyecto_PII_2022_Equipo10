using System;
using System.Collections.Generic;
using ImageMagick;

namespace Library
{
    public class ShowBoards
    {   
        private static ShowBoards showBoards;

        public  static ShowBoards Instance
        {
            get
            {
                if (showBoards == null)
                {
                    showBoards = new ShowBoards() ;
                }
                return showBoards;
            }
        }
        private ShowBoards ()
        {

        }
        
        public void ShowConsoleBoard(Boards board)
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
        
        
        
