using System;


namespace unit02_hilo
{
    /// <summary>
    /// A random card to be flipped by the director
    /// It will generate a new card when 'flipped'
    /// by the Director.
    /// </summary>
    public class Card
    {
        public int value; // 1-13.

        /// <summary>
        /// Constructs a new instance of Card
        /// </summary>
        public Card()
        {
            value = -1;
        }

        /// <summary>
        /// will generate a new value for Card
        /// between 1 and 13
        /// </summary>
        public void Draw()
        {
            Random random = new Random();
            value = random.Next(1, 14);
        }
    }
}