using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissorsTournament
{
    class GameLoop
    {
        public List<Player> playerList;
        public List<Match> matchList;
        private const int MAX_WINS = 5;

        public GameLoop()
        {
            playerList = new List<Player>();
            matchList = new List<Match>();
        }
        /// <summary>
        /// Command.
        /// post-condition: 
        ///     new player as AI added to playerList
        ///     A match has been created between the player and AI
        ///     SingleMode with AI match start
        /// </summary>
        public void StartAIGame()
        {             
            Player AI = new Player("ButtBot");
            playerList.Add(AI);
            Console.WriteLine("{0} joined the game", AI.Name);
            AI.IsBot = true;
            Match botMatch = new Match(playerList[0], playerList[1]);        
            SingleMode(botMatch);
        }


        /// <summary>
        /// Command
        /// pre-condition
        ///     match not null
        /// post-condition
        ///     winner of match.MAtchesWon++
        ///     match particpants score set to 0
        /// </summary>
        /// <param name="match"></param>
        public void SingleMode(Match match)
        {
            Console.Clear();
            do
            {
                SelectGestures(match);

                //Both players have chosen a gesture
                if(GetWinner(match) != null)
                {
                    Console.WriteLine("\n{0} wins the round!", GetWinner(match).Name);
                    GetWinner(match).Score++;
                    Console.WriteLine("\nCURRENT SCORE");
                    Console.WriteLine("\n{0} {1} - {2} {3}", match.PlayerOne.Name, match.PlayerOne.Score, match.PlayerTwo.Score, match.PlayerTwo.Name);
                }
                else
                {
                    Console.WriteLine("Draw");
                }

                Console.Read();
            } while (!MaxWinsReached());

            GetWinner(match).MatchesWon++;
            Console.Clear();
            Console.WriteLine("Game ended");
            if(match.PlayerOne.Score > match.PlayerTwo.Score)
            {
                Console.WriteLine("{0} wins the match with {1} points vs {2}", match.PlayerOne.Name, match.PlayerOne.Score, match.PlayerTwo.Score);
            }
            else
            {
                Console.WriteLine("{0} wins the match with {1} points vs {2}", match.PlayerTwo.Name, match.PlayerTwo.Score, match.PlayerOne.Score);
            }

            match.PlayerOne.Score = 0;
            match.PlayerTwo.Score = 0;
            Console.WriteLine("Press enter to continue..");
            Console.ReadKey();
        }

        /// <summary>
        /// Command
        /// pre-condition
        ///     count > 0
        /// post-condition
        ///     count number of players added to playerList
        /// </summary>
        /// <param name="count"></param>
        public void StartGame(int count)
        {
            for (int i = 0; i < count; i++)
            {
                Player player;
                Console.Clear();
                Console.WriteLine("player {0} type your name.", i + 1);
                player = new Player(Console.ReadLine());
                playerList.Add(player);
            }
            if (playerList.Count > 1)
            {
                SetupMatches();
            }
        }

        /// <summary>
        /// Command
        /// Pre-condition
        ///     playerlist not null
        ///     matchlist not null
        /// Post-condition
        ///     matchList.count > old matchlist.count
        ///     matchList order has been shuffled (randomized)
        ///     a match or tournament has been started
        /// </summary>
        public void SetupMatches()
        {
            for (int x = 0; x < playerList.Count; x++)
            {
                for (int y = x; y < playerList.Count; y++)
                {
                    if (x != y)
                    {
                        matchList.Add(new Match(playerList[x], playerList[y]));
                    }
                }
            }
            var rnd = new Random();
            matchList = matchList.OrderBy(a => rnd.Next()).ToList();
            if (matchList.Count > 1)
            {
                StartTournament();
            }
            else
            {
                SingleMode(matchList[0]);
            }
        }

        /// <summary>
        /// Command
        /// pre-condition:
        ///     matchList not null
        ///     matchList.count > 0
        ///     playerList not null
        /// post-condition
        ///     ????
        /// frame-rule:
        ///     Content of playerList unchanged
        /// </summary>
        public void StartTournament()
        {
            for (int i = 0; i < matchList.Count; i++)
            {
                SingleMode(matchList[i]);

                if (i < matchList.Count - 2)
                {
                    Console.WriteLine("NEW MATCH STARTING");
                    Console.WriteLine("{0} vs. {1}", matchList[i + 1], matchList[i + 2]);
                }
                Console.ReadLine();
            }
           
            // All initial matches have been played

            Console.Clear();
            List<Player> tempSortedList = new List<Player>();

            tempSortedList = playerList.OrderByDescending(x => x.MatchesWon).ToList();
            matchList.Clear();
            if (!HasWinner(tempSortedList))
            {
                int winnersCount = NumberofWinners(tempSortedList);
                for (int x = 0; x < winnersCount; x++)
                {
                    for (int y = x; y < winnersCount; y++)
                    {
                        if (x != y)
                        {
                            matchList.Add(new Match(playerList[x], playerList[y]));
                        }
                    }
                }

                StartTournament();
            }

            // All matches have been played and a winner has been found

            foreach (Player item in tempSortedList)
            {
                Console.WriteLine("{0} has {1} points", item.Name, item.MatchesWon);
            }
            Console.WriteLine("Press enter to continue..");
            Console.Read();
        }

        /// <summary>
        /// Query
        /// Pre-conditon
        ///     Playerlist.count > 0
        /// Post-condition
        ///     returns true if a player score >= MAX_WINS
        /// </summary>
        /// <returns></returns>
        public bool MaxWinsReached()
        {
            for (int i = 0; i < playerList.Count; i++)
            {
                if(playerList[i].Score >= MAX_WINS)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Query
        /// Pre-condition
        ///     Match not null
        ///     playerOne & playerTwo selectedGesture != Gesture.None
        /// Post-condition
        ///     returns player with winning hand
        /// </summary>
        /// <param name="match"></param>
        /// <returns></returns>
        public static Player GetWinner(Match match)
        {
            switch (match.PlayerOne.SelectedGesture)
            {
                case Gesture.Rock:
                    if (match.PlayerTwo.SelectedGesture == Gesture.Scisssor)
                        return match.PlayerOne;
                    else if (match.PlayerTwo.SelectedGesture == Gesture.Paper)
                        return match.PlayerTwo;
                    break;
                case Gesture.Paper:
                    if (match.PlayerTwo.SelectedGesture == Gesture.Rock)
                        return match.PlayerOne;
                    else if (match.PlayerTwo.SelectedGesture == Gesture.Scisssor)
                        return match.PlayerTwo;
                    break;
                case Gesture.Scisssor:
                    if (match.PlayerTwo.SelectedGesture == Gesture.Paper)
                        return match.PlayerOne;
                    else if (match.PlayerTwo.SelectedGesture == Gesture.Rock)
                        return match.PlayerTwo;
                    break;
            }
            return null;
        }


        public void CleanUp()
        {
            playerList.Clear();
            matchList.Clear();
        }
        
        /// <summary>
        /// Queury
        /// Pre-condition
        ///     playerList not null
        ///     playerList.count >= 2
        /// Post-condition
        ///     returns true if two players are tied for the win
        /// </summary>
        /// <param name="playerList"></param>
        /// <returns></returns>
        public bool HasWinner(List<Player> playerList)
        {
            return playerList[0].MatchesWon != playerList[1].MatchesWon;
        }

        /// <summary>
        /// Query
        /// Pre-condition
        ///     playerList not null
        ///     playerList.count >= 2
        /// Post-condition
        ///     returns amount of tied "winner"/players, at least 1
        /// </summary>
        /// <param name="playerList"></param>
        /// <returns></returns>
        public int NumberofWinners(List<Player> playerList)
        {
            int winnerCount = 1;
            for (int i = 1; i < playerList.Count; i++)
            {
                if (playerList[i].MatchesWon == playerList[0].MatchesWon)
                {
                    winnerCount++;
                }
            }
            return winnerCount;
        }

        /// <summary>
        /// Command
        /// Pre-Condition:
        ///     Match is not null
        /// Post-Condition:
        ///     Both players has selected a gesture
        /// </summary>
        /// <param name="match"></param>
        public void SelectGestures(Match match)
        {
            for (int i = 0; i < match.MatchPlayerList.Count; i++)
            {
                bool invalidGestureChosen = false;
                do
                {
                    invalidGestureChosen = false;
                    Console.Clear();
                    Console.WriteLine("{0} choose your gesture (r,p,s)", match.MatchPlayerList[i].Name);
                    if (!match.MatchPlayerList[i].IsBot)
                        switch (Console.ReadLine().ToLower())
                        {
                            case "r":
                                match.MatchPlayerList[i].SelectedGesture = Gesture.Rock;
                                break;
                            case "p":
                                match.MatchPlayerList[i].SelectedGesture = Gesture.Paper;
                                break;
                            case "s":
                                match.MatchPlayerList[i].SelectedGesture = Gesture.Scisssor;
                                break;
                            default:
                                invalidGestureChosen = true;
                                break;
                        }
                    else
                        match.MatchPlayerList[i].SelectedGesture = Gesture.Rock; //TODO: Add random
                } while (invalidGestureChosen);
            }
        }
    }
}
