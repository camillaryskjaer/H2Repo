using SorteperLibrary.Cards.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SorteperLibrary
{
    /// <summary>
    /// Class for cards.
    /// </summary>
    public class Card : ICard
    {
        private string _suit;
        private int _value;

        // Constructor for card class
        public Card(string suit, int value)
        {
            _suit = suit;
            _value = value;
        }

        // Method to get the suit of the card
        public string GetSuit()
        {
            return _suit;
        }

        // Method to get the value of the card
        public int GetValue()
        {
            return _value;
        }
    }
}
