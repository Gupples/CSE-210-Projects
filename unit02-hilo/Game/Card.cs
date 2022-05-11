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
        public char suit; // (S)pades, (H)earts, (C)lubs, (D)iamonds

        /// <summary>
        /// Constructs a new instance of Card
        /// </summary>
        public Card()
        {
            value = -1;
            suit = '_';
        }

        /// <summary>
        /// Will generate a new value 
        /// and suit for the card.
        /// </summary>
        public void Draw()
        {
            DetermineSuit();
            DetermineValue();
        }
        
        /// <summary>
        /// Will generate a new value for Card
        /// between 1 and 13
        /// </summary>
        public void DetermineValue()
        {
            Random random = new Random();
            value = random.Next(1, 14);
        }
        
        /// <summary>
        /// Will randomly generate a suit for the card.
        /// </summary>
        public void DetermineSuit()
        {
            Random random = new Random();
            int suitHolder = random.Next(1, 5);
            // Credit to w3schools for syntax and
            // CS124 and CS165 for the idea to use a switch case.
            switch (suitHolder)
            {
                case 1:
                    suit = 'S';
                    break;
                case 2:
                    suit = 'H';
                    break;
                case 3:
                    suit = 'C';
                    break;
                case 4:
                    suit = 'D';
                    break;
            } // exit switch case
            
        } // exit Draw()

        public void Display()
        {
            string val;
            switch(value)
            {
                case 1:
                    val = "A";
                    break;
                case 11:
                    val = "J";
                    break;
                case 12:
                    val = "Q";
                    break;
                case 13:
                    val = "K";
                    break;
                default:
                    val = $"{value}";
                    break;
                
            } // exit switch case
            Console.WriteLine($"{val}{suit}");
        } // exit Display
    }
}