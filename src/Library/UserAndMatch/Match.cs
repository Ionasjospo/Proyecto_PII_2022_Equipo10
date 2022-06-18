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
        private Battle battle;
        private bool openToJoin;
        private int countPlayers = 0;


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
            countPlayers++;
            this.openToJoin = true;
            this.twoVtwo = twoVtwo;
            MatchList.Instance.addNewMatch(this);
            this.playerA1 = new Player(user);
            NewBattle();
        }

        /// <summary>
        /// Un usuario decide unirse a una partida (simple)
        /// </summary>
        private void JoinB1(User user)
        {
            countPlayers++;
            JoinMatchStatus();
            this.playerB1 = new Player(user);
            NewBattle();
        }
        /// <summary>
        /// Un usuario decide unirse a una partida 2v2
        /// siendo player A
        /// </summary>
        /// <param name="user"></param>
        private void JoinA2(User user)
        {
            countPlayers++;
            JoinMatchStatus();
            this.playerA2 = new Player(user,playerA1);
            NewBattle();
        }
        /// <summary>
        /// Un usuario decide unirse a una partida 2v2
        /// siendo player B
        /// </summary>
        /// <param name="user"></param>
        private void JoinB2(User user)
        {
            countPlayers++;
            JoinMatchStatus();
            this.playerB2 = new Player(user,playerB1);
            NewBattle();
        }
        /// <summary>
        /// Una vez prontos ambos jugadores con sus tableros, comienza la partida.
        /// </summary>
        private void NewBattle()
        {
            if (twoVtwo && countPlayers == 4)
            {
                battle = new Battle(this);
            }
            if (!twoVtwo && countPlayers == 2)
            {
                battle = new Battle(this);
            }
        }

        private void JoinMatchStatus()
        {
            if (twoVtwo && countPlayers == 4)
            {
                this.openToJoin = false;
            }
            if (!twoVtwo && countPlayers == 2)
            {
                this.openToJoin = false;
            }
        }
    }
}
