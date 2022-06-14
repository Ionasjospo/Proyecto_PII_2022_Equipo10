using System;

namespace Library
{
    public class Player
    {
        private User user;
        private Board board;

        public User User 
        { get { return this.user; } }
        public Board Board 
        { get { return this.board; } }

        public Player (User user)
        {
            this.user = user;
        }

        public void CreateBoard()
        {
            this.board = new Board();
        }
    }
}