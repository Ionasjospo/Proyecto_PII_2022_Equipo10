using System;

namespace Library
{
    public class User
    {
        private string name;
        private int id;
        private int battlesWon;
        private int specialBomb;
        private static int contador = 0;

        public string Name
        {get{return this.name;}}

        // public int shipSetCount = 0;

        public int Id
        {get{return this.id;}}

        public int BattlesWon
        {get{return this.battlesWon;}}

        public int SpecialBomb
        {get{return this.specialBomb;}}
        
        public User (string name)
        {
            this.name = name;
            //this.id = id;
            this.battlesWon = 0;
            this.specialBomb = 0;
        }

        public void AddBattleWon()
        {
            this.battlesWon += 1;
            if (this.battlesWon % 5 == 0)
                this.specialBomb += 1;
        }

        public void SpecialBombUsed()
        {
            this.specialBomb -= 1;
        }


        public int Contador
        {
            get { return contador; }  
        }

        // public int ShipSetCount
        // {
        //     get 
        //     { 
        //         return this.shipSetCount; 
        //     }
        // }

    }
}



   

        

        
         

