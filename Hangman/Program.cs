using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    class Program
    {
        static void Main(string[] args)
        {
            string newGame = "new";
            string quitGame = "quit";
            do
            {
                Console.WriteLine("Hello. Type {0} to start a new game, type {1} to quit", newGame, quitGame);
                string user = Console.ReadLine();
                if (user == newGame)
                {
                    // Declaring the variable myGame as type Game
                    Game myGame;
                    // Creating a new game and assigning it to myGame
                    myGame = new Game();
                    myGame.Start();
                }
                else if (user == quitGame)
                {
                    Environment.Exit(0);
                    
                }
                else
                {
                    Console.WriteLine("Sorry, I dont understand");
                }
            } while (true);

        }
    }
}
