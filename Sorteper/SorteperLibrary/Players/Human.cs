using SorteperLibrary.Cards.Interfaces;
using SorteperLibrary.Players.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SorteperLibrary.Players
{
    /// <summary>
    /// Class for human players.
    /// </summary>
    public abstract class Human : IPlayer
    {
        private int _playerNumber;
        private string _playerName;
        private List<ICard> _cards;

        // Constructor for a human player
        public Human(string name, int number)
        {
            _playerName = name;
            _playerNumber = number;
        }

        // Method to add a card to the player
        public void AddCard(ICard card)
        {
            _cards.Add(card);
        }

        // Method to return the number off cards a player have
        public int GetCards()
        {
            return _cards.Count;
        }

        // Method to get the players name
        public string GetName()
        {
            return _playerName;
        }

        // Method to get the players number
        public int GetNumber()
        {
            return _playerNumber;
        }

        // Method to remove and return the removed card
        public ICard RemoveCard(int index)
        {
            ICard result = _cards[index];
            _cards.RemoveAt(index);
            return result;
        }
    }
}
