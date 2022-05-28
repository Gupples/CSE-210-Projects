namespace unit03_jumper
{
    /// <summary>
    /// <para>A person who directs the game.</para>
    /// <para>
    /// The responsibility of a Director is to control the sequence of play.
    /// </para>
    /// </summary>
    public class Director
    {
        private Word word = new Word();
        private bool isPlaying = true;
        private Guy Guy = new Guy();
        private TerminalService terminalService = new TerminalService();

        /// <summary>
        /// Constructs a new instance of Director.
        /// </summary>
        public Director()
        {
        }

        /// <summary>
        /// Starts the game by running the main game loop.
        /// </summary>
        public void StartGame()
        {
            DoOutputs();
            while (isPlaying)
            {
                GetInputs();
                DoUpdates();
                DoOutputs();
            }
        }

        /// <summary>
        /// Moves the Guy to a new location.
        /// </summary>
        private void GetInputs()
        {

            bool isVerified = false;
            char guess = '_';
            string input = "_";
            while (!isVerified)
            {
                if (isPlaying)
                {
                    input = terminalService.ReadText("\nGuess a letter [a-z]: ");
                    terminalService.WriteText("");
                }
                // Verify input is only one character long and is a letter.
                isVerified = VerifyInput(input);
                if (isVerified)
                {
                    input = input.ToLower();
                    guess = input[0];
                }                
            }    
            word.SetGuess(guess);
        }

        /// <summary>
        /// Keeps track of whether Guy lost a life.
        /// </summary>
        private void DoUpdates()
        {
            string keyword = word.GetValue();
            word.UpdateProgress();
            if (!keyword.Contains(word.GetGuess()))
            {
                Guy.LoseALife();
            }
        }

        /// <summary>
        /// Displays guesses and guessed letters, as well as the 
        /// Guy. Also writes end message if the game is over.
        /// </summary>
        private void DoOutputs()
        {
            word.ShowGuesses();
            string hint = word.GetProgress();
            terminalService.WriteText(hint);
            terminalService.WriteText("");
            Guy.Display();
            if (Guy.GetLives() == 0)
            {
                terminalService.WriteText($"The word was '{word.GetValue()}'.");
                isPlaying = false;
            }

            if (word.IsGuessed())
            {
                terminalService.WriteText("\nYou win! ^_^");
                isPlaying = false;
            }
            terminalService.WriteText("");
            
        } // exit DoOutputs()

        /// <summary>
        /// Verifies user's input is only a single alphabetical character.
        /// </summary>
        /// <param name="input">The proposed input to be verified</param>
        /// <returns>True if it is verified, false if not.</returns>
        private bool VerifyInput(string input)
        {
            bool verified = false;
            // Is input alphabetical?
            foreach (char c in input)
            {
                // thanks docs.microsoft.com for the char.IsLetter() method.
                if (!char.IsLetter(c))
                {
                    terminalService.WriteText("Input must only contain letters.");
                    return verified;
                }
            }
            // Is input only one character long?
            if (input.Length == 1)
            {
                verified = true;
            }
            // String is too long.
            else
            {
                terminalService.WriteText("Input must be only one character long.");
            }
            return verified;
        } // exit VerifyInput()
    } // exit Director class
} // exit namespace