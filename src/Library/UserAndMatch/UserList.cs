using System;

namespace Library
{
    /// <summary>
    /// Clase que garantiza una lista de usuarios.
    /// </summary>
    public class UserList
    {
        /// <summary>
        /// Lista de usuarios.
        /// </summary>
        private List<User> users;
        /// <summary>
        /// Propiedad que devuelve la lista de Usuarios.
        /// </summary>
        /// <value>Lista de usuarios.</value>
        public List<User> Users
        {
            get
            {
                return this.users;
            }
        }
        /// <summary>
        /// Lista de usuarios.
        /// </summary>
        private static UserList userlist;
        /// <summary>
        /// Para crear o retornar la instancia de UserList, usamos el patrón de singleton.
        /// </summary>
        /// <value></value>
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
        /// <summary>
        /// Constructor de UserList.
        /// </summary>
        private UserList ()
        {
            users = new List<User>();
        }


        /// <summary>
        /// Método para agregar un nuevo usuario a la lista de usuarios.
        /// </summary>
        /// <param name="name">Nombre del usuario.</param>
        /// <returns>El número que tiene en la lista.</returns>
        public int addNewUser(string name)
        {
            User user = new User(name);
            users.Add(user);
        }
    }
}
