using System;
using System.Text.Json;
using System.Text.Json.Serialization;

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

        public UserList(string json)
        {
            this.LoadFromJson(json);
        }

        /// <summary>
        /// Método para agregar un nuevo usuario a la lista de usuarios.
        /// </summary>
        /// <param name="name">Nombre del usuario.</param>
        /// <returns>El número que tiene en la lista.</returns>
        public void addNewUser(string name, string id)
        {
            User user = new User(name, id);
            HistorialUser.Instance.UserID.Add(id, user);
            users.Add(user);
        }


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
                throw new Exception("Usuario no registrado.");
            }
            return new User("nonuser", "nonuser");
        }

        public string ConvertToJson()
        {
            return JsonSerializer.Serialize(this);
        }


        public void LoadFromJson(string json)
        {
            UserList userListeserialized = JsonSerializer.Deserialize<UserList>(json);
            // this.Name = deserialized.Name;
            // this.FamilyName = deserialized.FamilyName;

        }
    }
}
