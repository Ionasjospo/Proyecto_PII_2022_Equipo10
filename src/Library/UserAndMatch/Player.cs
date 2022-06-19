using System;

namespace Library
{
    public class Player
    {
        private User user;
        private Boards boardWithShips;
        private Boards boardWithShoots;

        public User User 
        { get { return this.user; } }
        public Boards BoardWithShips
        { get { return this.boardWithShips; } }
        public Boards BoardWithShoots 
        { 
            get { return this.boardWithShoots; } 
        }

        public Player (User user)
        {
            this.user = user;
            this.boardWithShips = new BoardWithShips();
            this.boardWithShoots = new BoardWithShoots();
        }
        public Player (User user, Player player)
        {
            this.user = user;
            this.boardWithShips = player.BoardWithShips;
            this.boardWithShoots = player.BoardWithShoots;
        }
    }
}