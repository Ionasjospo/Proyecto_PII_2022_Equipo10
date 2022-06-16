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

        private static UserList userlist;

        public static UserList Instance
        {
            get
            {
                if (userlist == null)
                {
                    userlist = new UserList();
                }
                return userlist;
            }
        }

        private UserList ()
        {
            players = new List<User>();
        }

        public void addMatch(User user)
        {
            players.Add(user);
        }

        public int addNewUser(string name)
        {
            User user = new User(name);
            players.Add(user);
            return players.IndexOf(user);
        }
    }
}
