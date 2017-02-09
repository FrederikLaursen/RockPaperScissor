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

        /// <summary>
        /// require
        ///     player_already_exists:
        ///         player \= void
        ///         
        /// ensure:
        ///     player_name_set
        /// </summary>
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
        /// <summary>
        /// require:
        ///     player_gesture_set
        ///         player.ChosenGesture /= void
        /// 
        /// ensure:
        ///     winner = null
        ///     player.ChosenGesture = Gesture.None
        /// </summary>
        public static void DetermineWinner()
        {
            winner = GetWinner(playerOne, playerTwo);

            if (winner == null)
            {
                Console.WriteLine("Tie");
                Console.ReadLine();
            }
            else
            //Player list which contains a list of players. Used to store player information. Foreach player we go until count is 2 which would match up the players. If a player gets "Kicked out" were
            //just gonna remove them from the list. In case of a 3 player tournament were just gonna make the first winner go into the winners bracket and match the losers.
            //Foreach loop resets the players gestures and makes sure that we "reset" everything.
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
        /// <summary>
        /// require:
        ///     currentPlayer.Name /= void
        ///     
        /// ensure:
        ///     currentPlayer.ChosenGesture /= Gesture.None
        ///     or else
        ///     Enviroment.Exit
        /// </summary>
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

        /// <summary>
        /// Query
        /// Require: 
        ///     playerOne /= void
        ///     playerTwo /= void
        ///     
        /// Ensure:
        ///     Result playerOne
        ///     or else
        ///     Result playerTwo
        ///     or else
        ///     Result void
        /// </summary>
        /// <param name="playerOne"></param>
        /// <param name="playerTwo"></param>
        /// <returns></returns>
        public static Player GetWinner(Player playerOne, Player playerTwo)
        {
            switch (playerOne.ChosenGesture)
            {
                case Gesture.Rock:
                    if (playerTwo.ChosenGesture == Gesture.Scissor)
                        return playerOne;
                    else if (playerTwo.ChosenGesture == Gesture.Paper)
                        return playerTwo;
                    break;
                case Gesture.Paper:
                    if (playerTwo.ChosenGesture == Gesture.Rock)
                        return playerOne;
                    else if (playerTwo.ChosenGesture == Gesture.Scissor)
                        return playerTwo;
                    break;
                case Gesture.Scissor:
                    if (playerTwo.ChosenGesture == Gesture.Paper)
                        return playerOne;
                    else if (playerTwo.ChosenGesture == Gesture.Rock)
                        return playerTwo;
                    break;
            }
            return null;
        }
    }
}
