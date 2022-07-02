using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Exceptions;

namespace Library
{
    /// <summary>
    /// Clase que garantiza una lista de usuarios.
    /// </summary>
    public class UserList : IJsonConvertible
    {
        /// <summary>
        /// Lista de usuarios.
        /// </summary>
        [JsonInclude]
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
        [JsonConstructor]
        private UserList()
        {
            users = new List<User>();
        }





        /// <summary>
        /// Método para agregar un nuevo usuario a la lista de usuarios.
        /// </summary>
        /// <param name="name">Nombre del usuario.</param>
        /// <returns>El número que tiene en la lista.</returns>
        public void addNewUser(string name, string id)
        {
            User user = new User(name, id);

            users.Add(user);
        }

        /// <summary>
        /// Método para buscar usuario por su ID.
        /// </summary>
        /// <param name="id">identificador del usuario</param>
        /// <returns>un objeto User</returns>
        public User FindUserById(string id)
        {
            try
            {
                foreach (User user in this.Users)
                {
                    if (user.Id == id)
                        return user;
                }
            }
            catch
            {
                throw new UserNotFoundException("Usuario no registrado.");
            }
            return new User("nonuser", "nonuser");
        }
        public bool UsernameIsUsed(string name)
        {

            foreach (User user in this.Users)
            {
                if (user.Name == name)
                {
                    return true;
                }
            }
            return false;
        }
        public bool UsernameAreUsed(string name)
        {

            foreach (User user in this.Users)
            {
                if (user.Name == name)
                {
                    return true;
                }
            }
            return false;
        }

        public bool IdIsRegister(string id)
        {

            foreach (User user in this.Users)
            {
                if (user.Id == id)
                {
                    return true;
                }
            }
            return false;
        }
        public string ConvertToJson()
        {
            return JsonSerializer.Serialize(this.users);
        }

        public void LoadFromJson(string json)
        {
            List<User> lista = JsonSerializer.Deserialize<List<User>>(json);
            this.users = lista;
        }
    }
}

