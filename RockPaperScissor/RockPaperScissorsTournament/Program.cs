using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissorsTournament
{
    class Program
    {
        static GameLoop gameLoop;
        static void Main(string[] args)
        {
            gameLoop = new GameLoop();
            do
            {
                gameLoop.CleanUp();
                Console.Clear();
                Console.WriteLine("Welcome to Rock, Paper, Scissor. Select game mode");
                Console.WriteLine("1) 1v1");
                Console.WriteLine("2) vs AI");
                Console.WriteLine("3) Tournament mode");
                Console.WriteLine("4) Exit");
                //Decide game mode
                switch (Console.ReadLine())
                {
                    case "1":
                        gameLoop.StartGame(2);
                        break;
                    case "2":
                        gameLoop.StartGame(1);
                        gameLoop.StartAIGame();
                        break;
                    //Get count of players
                    case "3":
                        Console.Clear();
                        Console.WriteLine("Specify number of participants (max 4)");
                        gameLoop.StartGame(Convert.ToInt32(Console.ReadLine()));
                        break;
                    case "4":
                        Environment.Exit(0);
                        break;
                    default:
                        break;
                }
            } while (true);
        }
    }
}
