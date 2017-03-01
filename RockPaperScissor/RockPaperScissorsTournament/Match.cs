using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissorsTournament
{
    class Match
    {
        int playerOneScore, playerTwoScore;
        Player playerOne, playerTwo;
        List<Player> matchPlayerList;

        public Player PlayerOne
        {
            get
            {
                return playerOne;
            }

            set
            {
                playerOne = value;
            }
        }

        public Player PlayerTwo
        {
            get
            {
                return playerTwo;
            }

            set
            {
                playerTwo = value;
            }
        }

        internal List<Player> MatchPlayerList
        {
            get
            {
                return matchPlayerList;
            }

            set
            {
                matchPlayerList = value;
            }
        }

        public int PlayerOneScore
        {
            get
            {
                return playerOneScore;
            }

            set
            {
                playerOneScore = value;
            }
        }

        public int PlayerTwoScore
        {
            get
            {
                return playerTwoScore;
            }

            set
            {
                playerTwoScore = value;
            }
        }

        public Match(Player playerOne, Player playerTwo)
        {
            PlayerOneScore = 0;
            PlayerTwoScore = 0;
            this.PlayerOne = playerOne;
            this.PlayerTwo = playerTwo;
            MatchPlayerList = new List<Player>();
            MatchPlayerList.Add(playerOne);
            MatchPlayerList.Add(playerTwo);
        }
    }
}
