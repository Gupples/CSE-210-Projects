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
                Compare();
                // Add this round's score to totalScore
                UpdateScores();
                // Display the results of the round
                DoOutputs();
                // Ask the user if they would like to keep
                // playing (if they haven't lost yet)
                if (isPlaying)
                {
                    KeepPlaying();
                }

            } // exit (isPlaying) loop
        } // exit StartGame()

        /// <summary>
        /// Turns the flipped card of the last round into the current card
        /// for this round. Also generates a new flipped card and resets
        /// the round's score to 0.
        /// 
        /// </summary>
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

        /// <summary>
        /// Determines if the flipped card is higher or lower than the
        /// current card and determines if the player's guess was
        /// correct.
        /// 
        /// </summary>
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

        /// <summary>
        /// Adds the score from this round to the total score for the game.
        /// If the score is equal to or less than 0, it also ends the game.
        /// 
        /// </summary>
        public void UpdateScores()
        {
            totalScore += score;
            // if score <= 0, game is over.
            if (totalScore <= 0)
            {
                isPlaying = false;
            }
        }


        /// <summary>
        /// Displays what the results for the round were.
        /// 
        /// </summary>
        public void DoOutputs()
        {
            Console.WriteLine($"Next card was: {card2.value}");
            Console.WriteLine($"Your score is: {totalScore}");
        } // exit DoOutputs()

        /// <summary>
        /// Prompts the user if they would like to keep playing
        /// (if they haven't lost yet.)
        /// 
        /// </summary>
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