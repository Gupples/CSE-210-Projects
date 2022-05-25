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

        /// <summary>
        /// Updates progress for player to see.
        /// </summary>
        /// <returns>A new hint line.</returns>
        public void UpdateProgress()
        {
            _Guesses.Add(_guess);
            for (int i = 0; i > _progress.Length; i += 2)
            {
                ...
            }
        }

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

        /// <summary>
        /// Watches the seeker by keeping track of how far away it is.
        /// </summary>
        /// <param name="seeker">The seeker to watch.</param>
        public void WatchSeeker(Word word)
        {
            int newDistance = Math.Abs(location - word.GetLocation());
            distance.Add(newDistance);
        }
    }
}