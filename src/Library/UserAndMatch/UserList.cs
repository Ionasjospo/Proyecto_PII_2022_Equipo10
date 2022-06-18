using System;

namespace Library
{
    public class UserList
    {
        private List<User> users;

        public List<User> Users
        {
            get
            {
                return this.users;
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
            users = new List<User>();
        }

        public void addMatch(User user)
        {
            users.Add(user);
        }

        public int addNewUser(string name)
        {
            User user = new User(name);
            users.Add(user);
            return users.IndexOf(user);
        }
    }
}
