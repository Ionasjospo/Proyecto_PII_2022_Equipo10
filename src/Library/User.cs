namespace Library
{

    public class User
    {
        private string name;

        private static int contador = 0;

        private int id;

        public User(string name)
        {
            this.Name = name;
            this.Id = Contador;
            contador++;
        }

        public string Name
        {
            get { return name; }
            set { this.name = value; }

        }
        public int Id
        {
            get { return id; }
            set { this.id = value; }

        }

         public int Contador
        {
            get { return contador; }
            
        }

    }
}