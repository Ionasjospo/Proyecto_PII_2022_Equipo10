using System;

namespace Library
{
    public class Player
    {
        private User user;
        private Board boardWithShips;
        private Board boardWithShoots;

        public User User 
        { get { return this.user; } }
        public Board BoardWithShips
        { get { return this.boardWithShips; } }
        public Board BoardWithShoots 
        { 
            get { return this.boardWithShoots; } 
        }

        public Player (User user)
        {
            this.user = user;
            this.boardWithShips = new Board();
            //this.boardWithShips.SetPosition();
            this.boardWithShoots = new Board();
        }
        public Player (User user, Player player)
        {
            this.user = user;
            this.boardWithShips = player.BoardWithShips;
            this.boardWithShoots = player.BoardWithShoots;
        }
    }
}