using System;

namespace Library
{
    public class Match
    {
        private Board boardA;
        private Board boardB;
        private User playerA1;
        private User playerB1;
        private User playerA2;
        private User playerB2;
        private bool twoVtwo;

        /// <summary>
        /// opciones para mostrar al usuario
        /// </summary>
        public enum  Options
        {
            NewUser,
            NewMatch,
            JoinCurrentMatch
        }

        // public string Name
        // { get { return this.name; } }
        public Board BoardA
        { get { return this.boardA; } }
        public Board BoardB
        { get { return this.boardB; } }
        public User PlayerA1
        { get { return this.playerA1; } }
        public User PlayerB1
        { get { return this.playerB1; } }
        public User PlayerA2
        { get { return this.playerA2; } }
        public User PlayerB2
        { get { return this.playerB2; } }
        public bool TwoVtwo
        { get { return this.twoVtwo; } }


        public Match()
        {
            User playerA1 = new User("Pepe");
            ShowOptions(Options.NewUser, playerA1);         
            ShowOptions(Options.NewMatch, playerA1);
            CreateMatch(playerA1);
            Console.WriteLine ("Aqui tienes tu tablero\n");
            boardA.ShowBoard();

            User playerB1 = new User("Lola");
            ShowOptions(Options.NewUser, playerB1);
            ShowOptions(Options.JoinCurrentMatch, playerB1);
            CreateBoardPlayerB();
            boardB.ShowBoard();

            
        }


        /// <summary>
        /// Envía las opciones disponibles al los usuarios que desean comenzar una partida.
        /// </summary>
        public void ShowOptions(Options option, User user)
        {
            switch(option)
            {
                case Options.NewUser:
                Console.WriteLine ("Welcome!!!. \n");
                Console.WriteLine ($"We created your User called {user.Name} \n");
                Console.WriteLine ("Congrats!! \n");
                break;
                case Options.NewMatch:
                Console.WriteLine ("We are creating a new match, \n");
                Console.WriteLine ("and now, you only need to set the position of the ships \n");
                Console.WriteLine ("on your board while we waiting for another player. \n");
                break;
                case Options.JoinCurrentMatch:
                Console.WriteLine ("We have been waiting for you. \n");
                Console.WriteLine ("and now, you only need to set the position of the ships. \n");
                break;
                default:
                break;
            }

        }

        /// <summary>
        /// Un usuario decide unirse a una partida
        /// </summary>
        private void Join()
        {

        }

        /// <summary>
        /// Crea una partida de 2 jugadores
        /// </summary>
        private void CreateMatch(User pA1)
        {
            this.playerA1 = pA1;
            this.twoVtwo = false;
            CreateBoardPlayerA();
        }

        /// <summary>
        /// Crea una partida de 4 jugadores
        /// </summary>
        private void CreateMatchTwoVTwo()
        {

        }

        /// <summary>
        /// Crea el tablero del primer jugador para que vaya ubicando sus barcos
        /// </summary>
        private void CreateBoardPlayerA()
        {
            this.boardA = new Board();
        }

        /// <summary>
        /// Crea el tablero del segundo jugador para que vaya ubicando sus barcos
        /// </summary>
        private void CreateBoardPlayerB()
        {
            this.boardB = new Board();
        }

        /// <summary>
        /// Una vez prontos ambos jugadores con sus tableros, comienza la partida.
        /// </summary>
        private void NewBattle()
        {

        }


    }
}
