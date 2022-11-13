﻿/* Card.cs
 * Class of a Card that needs to be guessed.
 */

namespace GuessMyCard
{
    internal class Card
    {
        public static string[] suits = { "Hearts", "Spades", "Clubs", "Diamonds" };
        public static string[] values = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace" };

        public string? CardSuit { get; set; }
        public string? CardValue { get; set; }

        public Card()
        {
            // Generate a random suit and value
            Random rand = new Random();
            int index = 0;

            // Get a random index from the array of suits and set it to the object's CardValue
            index = rand.Next(suits.Length);
            this.CardSuit = suits[index];

            // Get random index from the values and set it to CardValue
            index = rand.Next(values.Length);
            this.CardValue = values[index];
        }

    }
}
