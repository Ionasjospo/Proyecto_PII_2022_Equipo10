using System;

namespace Library
{
    public class Player
    {
        private User user;
        private Board defenseBoard;
        private Board attackBoard;

        public User User 
        { get { return this.user; } }
        public Board DefenseBoard 
        { get { return this.defenseBoard; } }
        public Board AttackBoard 
        { get { return this.attackBoard; } }

        public Player (User user)
        {
            this.user = user;
        }

        public void CreateBoard()
        {
            //this.defenseBoard = new Board();
            //this.attackBoard = new Board();
        }
    }
}