using System;

namespace Library
{
    public class Match
    {
        /// <summary>
        /// Primer jugador en la partida. 
        /// </summary>
        private Player playerA1;
        /// <summary>
        /// Segundo jugador en la partida. Si la partida es 1vs1 es rival del "playerA1". 
        /// </summary>
        private Player playerB1;
        /// <summary>
        /// Si la partida es 2vs2, este jugador es compañero del "playerA1".
        /// </summary>
        private Player playerA2;
        /// <summary>
        /// Si la partida es 2vs2, este jugador es compañero del "playerB2".
        /// </summary>
        private Player playerB2;
        /// <summary>
        /// Valor booleano que indica si la partida es 2vs2.
        /// </summary>
        private bool twoVtwo = false;
        /// <summary>
        /// Instancia de battle.
        /// </summary>
        private Battle battle;
        /// <summary>
        /// Indica si la partida esta pronta para recibir otros jugadores.
        /// </summary>
        private bool openToJoin;
        /// <summary>
        /// Contador de jugadores en la partida.
        /// </summary>
        private int countPlayers = 0;
        /// <summary>
        /// Propiedad que retorna el jugador A1.
        /// </summary>
        /// <value>PlayerA1.</value>
        public Player PlayerA1
        { get { return this.playerA1; } }
        /// <summary>
        /// Propiedad que retorna el jugador B1.
        /// </summary>
        /// <value>PlayerB1.</value>
        public Player PlayerB1
        { get { return this.playerB1; } }
        /// <summary>
        /// Propiedad que retorna el jugador A2.
        /// </summary>
        /// <value>PlayerA2.</value>
        public Player PlayerA2
        { get { return this.playerA2; } }
        /// <summary>
        /// Propiedad que retorna el jugador B2
        /// </summary>
        /// <value>PlayerB2</value>
        public Player PlayerB2
        { get { return this.playerB2; } }       
        /// <summary>
        /// Propiedad que retorna si la partida es 2vs2.
        /// </summary>
        /// <value>Valor booleano.</value>
        public bool TwoVtwo
        { get { return this.twoVtwo; } }
        /// <summary>
        /// Constructor de match.
        /// </summary>
        /// <param name="user"Usuario.></param>
        /// <param name="twoVtwo">Si es 2vs2 o no.
        /// </param>
        public Match(User user,bool twoVtwo)
        {
            countPlayers++;
            this.openToJoin = true;
            this.twoVtwo = twoVtwo;
            MatchList.Instance.addNewMatch(this);
            this.playerA1 = new Player(user);
           //NewBattle();
        }
        /// <summary>
        /// Método para que un usuario se une a una partida.
        /// </summary>
        public void Join(User user)
        {
            countPlayers++;
            JoinMatchStatus();
            switch (countPlayers)
            {
                case 2:
                this.playerB1 = new Player(user);
                break;
                case 3:
                this.playerA2 = new Player(user);
                break;
                case 4:
                this.playerB2 = new Player(user);
                break;
                default:
                break;
            }
            //NewBattle();
        }
        /// <summary>
        /// Verificador si es posible unirse a una partida.
        /// </summary>
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
        /// <summary>
        /// Metodo para comenzar la partida.
        /// </summary>
        public void NewBattle()
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

        public Battle Battle
        {get{return battle; } set{this.battle=value;}} 
    }
}
