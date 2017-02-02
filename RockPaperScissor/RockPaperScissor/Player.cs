using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissor
{
    enum Gesture { Rock, Paper, Scissor, None };

    class Player
    {
        string name;
        int score;
        bool hasTurn = false;
        Gesture chosenGesture;

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
                return score;
            }

            set
            {
                score = value;
            }
        }

        public bool HasTurn
        {
            get
            {
                return hasTurn;
            }

            set
            {
                hasTurn = value;
            }
        }

        public Gesture ChosenGesture
        {
            get
            {
                return chosenGesture;
            }

            set
            {
                chosenGesture = value;
            }
        }

        public Player()
        {
            chosenGesture = Gesture.None;
        }
    }
}
