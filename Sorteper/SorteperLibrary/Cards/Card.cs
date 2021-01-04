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
        private string _name;
        private int _suit;
        private int _value;

        // Constructor for card class
        public Card(int suit, int value, string name)
        {
            _name = name;
            _suit = suit;
            _value = value;
        }

        public string GetName()
        {
            return _name;
        }

        // Method to get the suit of the card
        public int GetSuit()
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
