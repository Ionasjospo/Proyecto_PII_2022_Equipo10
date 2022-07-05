using System;

namespace Library
{
    /// <summary>
    /// Representa un usuario.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Nombre del usuario.
        /// </summary>
        private string name;
        /// <summary>
        /// Id del usuario.
        /// </summary>
        private string id;
        /// <summary>
        /// Id del usuario correspondiente al chat actual.
        /// </summary>
        private long chatId;
        /// <summary>
        /// Historial de partidas ganadas por el usuario.
        /// </summary>
        private int battlesWon;
        /// <summary>
        /// Cantidad de bombas especiales que almacena el usuario.
        /// </summary>
        private int specialBomb;
        /// <summary>
        /// Para tener una bomba especial necesitas al menos 5 partidas ganadas, esta constante 
        /// sirve para dividir las partidas ganadas entre esta y obtener cuantas bombas especiales tiene el usuario.
        /// </summary>
        private const int battlesForWinSpecialBomb = 5;

        private List<Match> matchesPlayed;


        /// <summary>
        /// Propiedad que returna el nombre del usuario.
        /// </summary>
        /// <value>Nombre del usuario.</value>
        public string Name
        { get { return this.name; } }
        /// <summary>
        /// Propiedad que returna el id del usuario.
        /// </summary>
        /// <value>Id del usuario.</value>
        public string Id
        { get { return this.id; } set { this.id = value; } }
        /// <summary>
        /// Propiedad que retorna el Chat.ID del usuario correspondiente al chat actual.
        /// </summary>
        /// <value>Chat.Id del usuario.</value>
        public long ChatId
        { get { return this.chatId; } set { this.chatId = value; } }
        /// <summary>
        /// Propiedad que returna la cantidad de partidas ganadas del usuario.
        /// </summary>
        /// <value>Cantidad de partidas ganadas.</value>
        public int BattlesWon
        { get { return this.battlesWon; } }
        /// <summary>
        /// Propiedad que returna la cantidad de bombas especiales del usuario.
        /// </summary>
        /// <value>Bombas especiales del usuario.</value>
        public int SpecialBomb
        { get { return this.specialBomb; } }

        public List<Match> MatchesPlayed
        { get { return this.matchesPlayed; } }

        /// <summary>
        /// Constructor del usuario.
        /// </summary>
        /// <param name="name">Nombre del usuario.</param>
        public User(string name, string id)
        {
            this.name = name;
            this.Id = id;
            this.battlesWon = 0;
            this.specialBomb = 0;
            this.matchesPlayed = new List<Match>();
        }
        /// <summary>
        /// Agrega al historial una nueva partida ganada.
        /// </summary>
        public void AddBattleWon()
        {
            this.battlesWon += 1;
            if (this.battlesWon % battlesForWinSpecialBomb == 0)
                this.specialBomb++;
        }
        /// <summary>
        /// Si el usuario uso una bomba especial, se resta del total de bombas especiales que el usuario almacenaba.
        /// </summary>
        public void SpecialBombUsed()
        {
            this.specialBomb -= 1;
        }
        /// <summary>
        /// Crea una partida
        /// </summary>
        /// <param name="twoVtwo">Valor booleano, indica si es una partida 2vs2 o no.</param>
        public void NewMatch(bool twoVtwo)
        {
            Match match = new Match(this, twoVtwo);
            this.matchesPlayed.Add(match);
        }
        /// <summary>
        /// Une al usuario a una nueva partida.
        /// </summary>
        /// <param name="match">Partida.</param>
        public bool JoinMatch(Match match)
        {
            bool joined = match.Join(this);
            if (joined)
                this.matchesPlayed.Add(match);
            return joined;

        }

        public bool UserInMatchRunning()
        {
            foreach (Match match in matchesPlayed)
            {
                if (match.Battle == null)
                    return true;
                else if (match.Battle.Winner == null)
                {
                    return true;
                }
            }
            return false;
        }
    }
}










