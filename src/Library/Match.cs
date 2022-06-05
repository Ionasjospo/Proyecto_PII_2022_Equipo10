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

        public string Name
        { get { return this.name; } }
        public Board BoardA
        { get { return this.boardA; } }
        public Board BoardB
        { get { return this.boardB; } }
        public Board playerA1
        { get { return this.playerA1; } }
        public Board playerB1
        { get { return this.playerB1; } }
        public Board playerA2
        { get { return this.playerA2; } }
        public Board playerB2
        { get { return this.playerB2; } }
        public bool TwoVtwo
        { get { return this.twoVtwo; } }


        public Match()
        {

        }


    }
}
