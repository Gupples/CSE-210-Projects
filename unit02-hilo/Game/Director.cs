using System;
using System.Collections.Generic;


namespace unit02_hilo
{
    /// <summary>
    /// A person who directs the game.
    /// 
    /// The Director controls the flow of the game
    /// </summary>
    public class Director
    {
        Card card1;
        Card card2;
        bool isPlaying;
        int score;
        int totalScore;
        char guess;

        /// <summary>
        /// Constructs a new instance of Director.
        /// Will also initialize a value for the first 
        /// card.
        /// 
        /// </summary>
        public Director()
        {
            card1.Draw();
        }

        /// <summary>
        /// Starts the game by running the game's loop.
        /// 
        /// </summary>

        public void StartGame()
        {
            while (isPlaying)
            {
                
            } // exit (isPlaying) loop
        } // exit StartGame()

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
                        Console.WriteLine($"input. Please type 'h' or 'l'. ");
                    }
                    Console.WriteLine($"The card is :{card1.value}");
                    Console.Write("Higher or lower? [h/l] ");
                    hiloInput = Console.ReadLine();  
                }
            } // exit (!validInput) loop
        } // exit Hilo()






    } // exit Director class
}