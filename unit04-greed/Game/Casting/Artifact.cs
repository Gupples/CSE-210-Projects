using System;

namespace Unit04.Game.Casting
{

    /// <summary>
    /// <para>An item of cultural or historical interest.</para>
    /// <para>
    /// The responsibility of an Artifact is to hold a score value.
    /// </para>
    /// </summary>
    public class Artifact : Actor
    {
        private int _value;

      
        /// <summary>
        /// Constructs a new instance of Artifact.
        /// </summary>
        public Artifact()
        {}
       

        /// <summary>
        /// Gets the artifact's value.
        /// </summary>
        /// <returns>The value as an int.</returns>
        public int GetValue()
        {
            return _value;
        }
        

        /// <summary>
        /// Sets the artifact's value to the given value.
        /// </summary>
        /// <param name="number">The given number.</param>
        public void SetValue(int number)
        {
            _value = number;
        }
    
    } // exit Artifact class
} // exit namespace