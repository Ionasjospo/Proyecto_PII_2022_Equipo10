using System;

namespace Library
{
    public class UserList
    {
        private List<User> players;

        public List<User> Players
        {
            get
            {
                return this.players;
            }
        }

        public UserList ()
        {
            players = new List<User>();
        }

        public void addMatch(User user)
        {
            players.Add(user);
        }
    }
}
