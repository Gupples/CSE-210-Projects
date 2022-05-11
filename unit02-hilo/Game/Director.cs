using System;

namespace unit02_hilo
{
    /// <summary>
    /// A person who directs the game.
    /// 
    /// The Director controls the flow of the game
    /// </summary>
    public class Director
    {
        Card card1 = new Card();
        Card card2 = new Card();
        bool isPlaying;
        int score;
        int totalScore;
        char guess;
        char status;

        /// <summary>
        /// Constructs a new instance of Director.
        /// Will also initialize a random value for the first card
        /// and all initial values as 0, 't' (for tie) or true as applicable.
        /// 
        /// </summary>
        public Director()
        {
            card1.Draw();
            score = 0;
            totalScore = 300;
            guess = '0';
            isPlaying = true;
            status = 't'; //
        }

        /// <summary>
        /// Starts the game by running the game's loop.
        /// 
        /// </summary>

        public void StartGame()
        {
            while (isPlaying)
            {
                // Generate new values for the cards
                NewRound();
                // Ask for higher or lower
                Hilo();
                // Compare card values. 
                // VVV MOVE CARD UPDATES FROM DoUpdates() TO HERE. 
                Compare();
                // VVV NEEDS TO UPDATE SCORES
                UpdateScores();
                DoOutputs();
                if (isPlaying)
                {
                    KeepPlaying();
                }

            } // exit (isPlaying) loop
        } // exit StartGame()


        public void NewRound()
        {
            // Moved draws here. MAKE SURE IT WORKS
            // WITH THE FIRST TIME THING (see class diagrams)
            if (card2.value != -1)
            {
                card1.value = card2.value;
            }
            card2.Draw();
            score = 0;
            
        } // exit UpdateCards()

        /// <summary>
        /// Displays the current card's value and 
        /// asks for the user's guess.
        /// </summary>
        public void Hilo()
        {
            string hiloInput = "USER HAS NOT GUESSED YET.";
            bool validInput = false;
            while (!validInput)
            {
                if (hiloInput.ToLower() == "h")
                {
                    guess = 'h';
                    validInput = true;
                }
                else if (hiloInput.ToLower() == "l")
                {
                    guess = 'l';
                    validInput = true;
                }
                else
                {
                    if (hiloInput != "USER HAS NOT GUESSED YET.")
                    {
                        Console.WriteLine($"I'm sorry; '{hiloInput}' was not valid");
                        Console.WriteLine($"input. Please type 'h' or 'l'. \n");
                    }
                    Console.WriteLine($"The card is: {card1.value}");
                    Console.Write("Higher or lower? [h/l] ");
                    hiloInput = Console.ReadLine();  
                }
            } // exit (!validInput) loop
        } // exit Hilo()

        public void Compare()
        {
            status = 't';
            if (card1.value > card2.value)
            {
                status = 'l';
            }
            else if (card1.value < card2.value)
            {
                status = 'h';
            }

            if (guess == status)
            {
                score = 100;
            }
            // Ties are not higher OR lower, so technically, are wrong either
            // way.
            else
            {
                score = -75;
            }

        } // exit Compare()

        public void UpdateScores()
        {
            totalScore += score;
            // if score <= 0, game is over.
            if (totalScore <= 0)
            {
                isPlaying = false;
            }
        }


        public void DoOutputs()
        {
            Console.WriteLine($"Next card was: {card2.value}");
            Console.WriteLine($"Your score is: {totalScore}");
        } // exit DoOutputs()

        public void KeepPlaying()
        {
            Console.Write("Play again? [y/n] ");
            string playAgain = Console.ReadLine();
            if (playAgain.ToLower() != "y")
            {
                isPlaying = false;
            } 
            Console.WriteLine();
        }


    } // exit Director class
}