using SorteperLibrary.Cards.Interfaces;
using SorteperLibrary.Players.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SorteperLibrary.Players
{
    /// <summary>
    /// Class to simulate a computer player.
    /// Not implemented!
    /// </summary>
    class Computer : Player, IPlayer
    {
        public Computer(int number)
        {
            _playerName = "Computer";
            _playerNumber = number;
        }
        public void AddCard(ICard card)
        {
            throw new NotImplementedException();
        }

        public void AddCards(List<ICard> cards)
        {
            throw new NotImplementedException();
        }

        public int GetCardAmount()
        {
            throw new NotImplementedException();
        }

        public List<ICard> GetCards()
        {
            throw new NotImplementedException();
        }

        public string GetName()
        {
            throw new NotImplementedException();
        }

        public int GetNumber()
        {
            throw new NotImplementedException();
        }

        public ICard RemoveCard(int index)
        {
            throw new NotImplementedException();
        }
    }
}
