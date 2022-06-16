using System;

namespace Library
{
    public class Player
    {
        private User user;
        private Board board;
        private bool readyToBattle = false;

        public User User 
        { get { return this.user; } }
        public Board Board 
        { get { return this.board; } }
        public bool ReadyToBattle 
        { get { return this.readyToBattle; } }

        public Player (User user)
        {
            this.user = user;
            this.board = new Board();
            this.readyToBattle = true;
        }
    }
}