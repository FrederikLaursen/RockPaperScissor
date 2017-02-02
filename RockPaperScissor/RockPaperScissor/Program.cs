using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissor
{
    class Program
    {
        static Player playerOne;
        static Player playerTwo;
        static Player currentPlayer;
        static Player winner;
        static void Main(string[] args)
        {
            playerOne = new Player();
            playerTwo = new Player();
            currentPlayer = playerOne;
            StartGame();

            do
            {
                GameLoop();

                if (playerOne.ChosenGesture != Gesture.None && playerTwo.ChosenGesture != Gesture.None)
                {
                    DetermineWinner();
                }
            } while (true);
        }
        public static void StartGame()
        {
            Console.WriteLine("Player one, enter your name");
            playerOne.Name = Console.ReadLine();
            Console.WriteLine("Player two, enter your name");
            playerTwo.Name = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Welcome {0} and {1}. Press Enter to continue...", playerOne.Name, playerTwo.Name);
            Console.ReadLine();
        }
        public static void DetermineWinner()
        {
            switch (playerOne.ChosenGesture)
            {
                case Gesture.Rock:
                    if (playerTwo.ChosenGesture == Gesture.Scissor)
                        winner = playerOne;
                    else if (playerTwo.ChosenGesture == Gesture.Paper)
                        winner = playerTwo;
                    break;
                case Gesture.Paper:
                    if (playerTwo.ChosenGesture == Gesture.Rock)
                        winner = playerOne;
                    else if (playerTwo.ChosenGesture == Gesture.Scissor)
                        winner = playerTwo;
                    break;
                case Gesture.Scissor:
                    if (playerTwo.ChosenGesture == Gesture.Paper)
                        winner = playerOne;
                    else if (playerTwo.ChosenGesture == Gesture.Rock)
                        winner = playerTwo;
                    break;
            }

            if (winner == null)
            {
                Console.WriteLine("Tie");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("{0} chose {1}", playerOne.Name, playerOne.ChosenGesture.ToString());
                Console.WriteLine("{0} chose {1}", playerTwo.Name, playerTwo.ChosenGesture.ToString());
                Console.WriteLine("{0} wins", winner.Name);
                Console.ReadLine();
            }

            winner = null;
            playerOne.ChosenGesture = Gesture.None;
            playerTwo.ChosenGesture = Gesture.None;
        }

        public static void GameLoop()
        {
            Console.Clear();
            Console.WriteLine("{0} choose your gesture.", currentPlayer.Name);
            switch (Console.ReadLine().ToLower())
            {
                case "r":
                    currentPlayer.ChosenGesture = Gesture.Rock;
                    break;
                case "p":
                    currentPlayer.ChosenGesture = Gesture.Paper;
                    break;
                case "s":
                    currentPlayer.ChosenGesture = Gesture.Scissor;
                    break;
                case "exit":
                    Environment.Exit(0);
                    break;
            }

            if (currentPlayer == playerOne)
            {
                currentPlayer = playerTwo;
            }
            else
            {
                currentPlayer = playerOne;
            }
        }
    }

}
