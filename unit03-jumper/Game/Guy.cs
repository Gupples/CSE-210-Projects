using System;
using System.Collections.Generic;


namespace unit03_jumper
{
    // TODO: Implement the Seeker class as follows...

    // 1) Add the class declaration. Use the following class comment.

        /// <summary>
        /// <para>The person looking for the Hider.</para>
        /// <para>
        /// The responsibility of a Seeker is to keep track of its lives.
        /// </para>
        /// </summary>
        public class Guy
        {
            private int lives;
            private bool isAlive;
            private List<string> Picture = new List<string>();


        // 2) Create the class constructor. Use the following method comment.
            
            /// <summary>
            /// Constructs a new instance of Seeker.
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

        // 3) Create the GetLives() method. Use the following method comment.
            
            /// <summary>
            /// Gets the current lives.
            /// </summary>
            /// <returns>The current lives as an int.</returns>
            public int GetLives()
            {
                return lives;
            }
            

        // 4) Create the Movelives(int lives) method. Use the following method comment.
            
            /// <summary>
            /// Moves to the given lives.
            /// </summary>
            /// <param name="lives">The given lives.</param>
            public void LoseALife()
            {
                lives--;
                isAlive = false;
            }

            public void Display()
            {
                if (!isAlive)
                {
                    Picture[4] = "   X";
                    Picture.Add("You died!");
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