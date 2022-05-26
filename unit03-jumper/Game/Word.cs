using System;
using System.Collections.Generic;
// using System.IO;


namespace unit03_jumper 
{
    /// <summary>
    /// <para>The word the player is guessing.</para>
    /// <para>
    /// The responsibility of Word is to generate a wor and keep track of what
    /// the user has guessed.
    /// </para>
    /// </summary>
    public class Word
    {
        private string _value;
        private char _guess;
        // VVV List of characters guessed.
        private List<char> _Guesses = new List<char>();
        private string _progress;

        /// <summary>
        /// Constructs a new instance of Hider. 
        /// </summary>
        public Word()
        {
            // For now, value will always be "apple"
            _value = "apple";
            _progress = "_ _ _ _ _";

            // VVV Uncomment when program works for full list of words.
            /* 
            List<string> lines = new List<string>(File.ReadLines("Words.txt"));
            Random rand = new Random();
            int randomIndex = rand.Next(0, lines.Count());
            _value = lines[randomIndex];
            _progress = "_"
            for (int i = 0; i < _value.Length - 1; i++)
            {
                _progress += " _";
            }
            */

        }

        // GETTERS AND SETTERS
        
        public string GetProgress()
        {
            return _progress;
        }

        public void SetGuess(char guess)
        {
            _guess = guess;
        }

        public string GetValue()
        {
            return _value;
        }

        /// <summary>
        /// Updates progress for player to see.
        /// </summary>
        /// <returns>A new hint line.</returns>
        public void UpdateProgress()
        {
            // Check if it has already been guessed.
            if (!_Guesses.Contains(_guess))
            {
                // Add guess to list of guesses.
                _Guesses.Add(_guess);
                
                // if the word has that letter 
                if (_value.Contains(_guess))
                {
                    // Make value for walking through _value
                    int j = 0;
                    // Make a value for converting _progress
                    string temp_Progress = "";
                    // Start walking through _progress and make changes
                    for (int i = 0; i < _progress.Length; i++, j++)
                    {
                        // Skip the spaces
                        if (_progress[i] == ' ')
                        {
                            i++;
                        }
                        // If the guess matches the slot in value, insert into
                        // temp string.
                        if (_value[j] == (_guess))
                        {
                            temp_Progress += _guess;
                        }
                        // If not, _progress should stay the same.
                        else 
                        {
                            temp_Progress += _progress[i];
                        }
                        if (i != _progress.Length)
                        {
                            temp_Progress += " ";
                        }
                    } // exit for loop; changes to _progress has been made.
                    _progress = temp_Progress;
                } // exit if (_value.Contains(_guess))
                // guess has not been guessed yet, but is not in the word.
            } // exit if(!_Guesses.Contains(_guess))
            // Player has already guessed that.
            else
            {
                Console.WriteLine($"You've already guessed {_guess}.");
                // Initiate method in Guy that makes him lose a life.
            }
        } // exit UpdateProgress()



        /// <summary>
        /// Whether or not the hider has been found.
        /// </summary>
        /// <returns>True if guessed; false if otherwise.</returns>
        public bool IsGuessed()
        {
            foreach (char letter in _value)
            {
                if (!_Guesses.Contains(letter))
                {
                    return false;
                }
            }
            return true;
        } // exit IsGuessed()

    }
}