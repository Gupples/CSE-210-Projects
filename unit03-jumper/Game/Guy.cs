using System;
using System.Collections.Generic;


namespace unit03_jumper
{
        /// <summary>
        /// <para>The person with the parachute whose life is at stake.</para>
        /// <para>
        /// The responsibility of a Guy is to keep track of its lives
        /// and to display itself.
        /// </para>
        /// </summary>
        public class Guy
        {
            private int lives;
            private bool isAlive;
            private List<string> Picture = new List<string>();
            
            /// <summary>
            /// Constructs a new instance of Guy.
            /// </summary>
            public Guy()
            {
                lives = 4;
                isAlive = true;
                Picture.Add(@"  ___ ");
                Picture.Add(@" /___\");
                Picture.Add(@" \   /");
                Picture.Add(@"  \ /");
                Picture.Add(@"   O");
                Picture.Add(@"  /|\");
                Picture.Add(@"  / \");
                Picture.Add(@" ");
                Picture.Add(@"^^^^^^^^");
            }

            /// <summary>
            /// Gets the current lives.
            /// </summary>
            /// <returns>The current lives as an int.</returns>
            public int GetLives()
            {
                return lives;
            }
                        
            /// <summary>
            /// Moves to the given lives.
            /// </summary>
            /// <param name="lives">The given lives.</param>
            public void LoseALife()
            {
                lives--;
                if (lives == 0)
                {
                    isAlive = false;  
                }
                
            }

            public void Display()
            {
                if (!isAlive)
                {
                    Picture[4] = "   X";
                    Picture.Add("You died! (>_<)");
                }
                for (int i = 4 - lives; i < Picture.Count - 1; i++)
                {
                    Console.WriteLine(Picture[i]);
                }
                Console.Write(Picture[Picture.Count - 1]);
                if (!isAlive)
                {
                    Console.WriteLine();
                }
            }

        }
}