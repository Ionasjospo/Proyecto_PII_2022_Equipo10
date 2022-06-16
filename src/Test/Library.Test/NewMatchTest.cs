using System;
using Library;
using NUnit.Framework;

namespace Library.Test;

public class NewMatchTest
{
    [SetUp]
    public void Setup()
    {

            /// <summary>
            /// COMENZAR LA PARTIDA, EN MODO SIN BOT.
            /// </summary>
            /// <returns></returns>

            
            // varias variables...
            MatchList match_list = new MatchList();
            UserList user_list = new UserList();
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
            foreach (User user_registered in user_list.Players)
            {
                if (user_registered.Name == message)
                {
                    user_exist = true;
                    user_list_index = user_list.Players.IndexOf(user_registered);
                }
            }

            //en caso que no estaba registrado
            if (!user_exist)
            {
                Console.WriteLine("Parece que no eras un jugador registrado...\n");
                user_list_index = user_list.addNewUser(message);
                Console.WriteLine(".\n");
                Console.WriteLine("..\n");
                Console.WriteLine("...pero ya has quedado registrado.\n");
            }

            // consulta si quiere una partida nueva o unirse a una existente
            // Console.WriteLine("Quiere una partida nueva? (responder con '0') ?\n");
            // Console.WriteLine("O prefiere unirse a una partida existente (responder con '1') ?\n");
            // message = Console.ReadLine();

            // switch(message)
            // {
            //     case "0":
            //         // creo una nueva partida.
            //         match_list.addNewMatch();
            //     break;
            //     case "1":

            //     break;
            //     default:
            //     break;
            // }


            // foreach (Match match in match_list)
            // {

            // }
            
            // match_list.addNewMatch();


//user_list.Players[user_list_index].Name



    }


}
