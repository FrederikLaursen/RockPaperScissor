using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissorsTournament
{
    enum Gesture { Rock, Paper, Scisssor, None}
    class Player
    {
        string name;
        int score, matchesWon;
        Gesture selectedGesture = Gesture.None;
        bool isBot;      

        public Player(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public int Score
        {
            get
            {
                return Score1;
            }

            set
            {
                Score1 = value;
            }
        }

        internal Gesture SelectedGesture
        {
            get
            {
                return selectedGesture;
            }

            set
            {
                selectedGesture = value;
            }
        }

        public bool IsBot
        {
            get
            {
                return isBot;
            }

            set
            {
                isBot = value;
            }
        }

        public int Score1
        {
            get
            {
                return score;
            }

            set
            {
                score = value;
            }
        }

        public int MatchesWon
        {
            get
            {
                return matchesWon;
            }

            set
            {
                matchesWon = value;
            }
        }
    }
}
