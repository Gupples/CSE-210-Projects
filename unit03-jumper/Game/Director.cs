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
            while (!isVerified)
            {
                string input = terminalService.ReadText("\nGuess a letter [a-z]: ");
                input = "yo";
                // Verify input is only one character long and is a letter.
                /*
                // {Initiate (and make) such a method.}
                if (isVerified)
                {
                    input = input.ToLower();
                    guess = input[0];
                }

                */
            }    
            word.SetGuess(guess);
        }

        /// <summary>
        /// Keeps watch on where the Guy is moving.
        /// </summary>
        private void DoUpdates()
        {
            word.UpdateProgress();
        }

        /// <summary>
        /// Provides a hint for the Guy to use.
        /// </summary>
        private void DoOutputs()
        {
            string hint = word.GetProgress();
            terminalService.WriteText(hint);
            if (word.IsGuessed())
            {
                isPlaying = false;
            }
            
        }
    }
}