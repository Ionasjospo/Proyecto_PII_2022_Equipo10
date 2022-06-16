using System;
using Library;
using NUnit.Framework;

namespace Library.Test;

public class NewMatchTest
{
    [SetUp]
    public void Setup()
    {
/*
            /// <summary>
            /// COMENZAR LA PARTIDA, EN MODO SIN BOT.
            /// </summary>
            /// <returns></returns>

            
            // varias variables...
            string message = "";
            bool user_exist = false;
            //User user;
            int user_list_index = 0;


            //bienvenida al juego
            Console.WriteLine("\n");
            Console.WriteLine("Bienvenido al esta nueva Batalla.\n");
            
            //consulto nombre de jugador
            Console.WriteLine("Cómo es tu nombre?\n");
            message = Console.ReadLine();

            //verifico si el jugador esta registrado
            foreach (User user_registered in UserList.Instance.Players)
            {
                if (user_registered.Name == message)
                {
                    user_exist = true;
                    user_list_index = UserList.Instance.Players.IndexOf(user_registered);
                }
            }

            //en caso que no estaba registrado
            if (!user_exist)
            {
                Console.WriteLine("Parece que no eras un jugador registrado...\n");
                user_list_index = UserList.Instance.addNewUser(message);
                Console.WriteLine(".\n");
                Console.WriteLine("..\n");
                Console.WriteLine("...pero ya has quedado registrado.\n");
            }

            //consulta si quiere una partida nueva o unirse a una existente
            Console.WriteLine("Quiere una partida nueva? (responder con '0') ?\n");
            Console.WriteLine("O prefiere unirse a una partida existente (responder con '1') ?\n");
            message = Console.ReadLine();

            switch(message)
            {
                case "0":
                    // creo una nueva partida.
                    UserList.Instance.Players[user_list_index].NewMatch();
                break;
                case "1":
                    // se une a una partida una nueva partida.
                    UserList.Instance.Players[user_list_index].JoinMatch();
                break;
                default:
                break;
            }


            // foreach (Match match in match_list)
            // {

            // }
            
            // match_list.addNewMatch();


//user_list.Players[user_list_index].Name

*/

    }


}
