using System;

namespace Library
{
    public class Match
    {
        private Player playerA1;
        private Player playerB1;
        private Player playerA2;
        private Player playerB2;
        private bool twoVtwo = false;
        private Batlle battle;
        private bool openToJoin;


        /// <summary>
        /// opciones para mostrar al usuario
        /// </summary>
        // public enum  Options
        // {
        //     NewUser,
        //     NewMatch,
        //     JoinCurrentMatch
        // }

        public Player PlayerA1
        { get { return this.playerA1; } }
        public Player PlayerB1
        { get { return this.playerB1; } }
        public Player PlayerA2
        { get { return this.playerA2; } }
        public Player PlayerB2
        { get { return this.playerB2; } }       

        public bool TwoVtwo
        { get { return this.twoVtwo; } }


        public Match(User user,bool twoVtwo)
        {
            this.openToJoin = true;
            this.twoVtwo = twoVtwo;
            MatchList.Instance.addNewMatch(this);
            this.playerA1 = new Player(user);
        }

        /// <summary>
        /// Un usuario decide unirse a una partida (simple)
        /// </summary>
        private void JoinB1(User user)
        {
            if (!twoVtwo)
                this.openToJoin = false;
            this.playerB1 = new Player(user);
            if (!twoVtwo)
                NewBattle();
        }
        /// <summary>
        /// Un usuario decide unirse a una partida 2v2
        /// siendo player A
        /// </summary>
        /// <param name="user"></param>
        private void JoinA2(User user)
        {
            this.openToJoin = false;
            this.playerB1 = new Player(user);
        }
        /// <summary>
        /// Un usuario decide unirse a una partida 2v2
        /// siendo player B
        /// </summary>
        /// <param name="user"></param>
        private void JoinB2(User user)
        {
            this.openToJoin = false;
            this.playerB1 = new Player(user);

        }
        /// <summary>
        /// Una vez prontos ambos jugadores con sus tableros, comienza la partida.
        /// </summary>
        private void NewBattle()
        {
            //battle = new Batlle(playerA1,playerA2);
            battle = new Batlle();
        }
    }
}
