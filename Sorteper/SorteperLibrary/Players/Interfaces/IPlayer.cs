using SorteperLibrary.Cards.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SorteperLibrary.Players.Interfaces
{
    /// <summary>
    /// Interface to handle player functions
    /// </summary>
    public interface IPlayer
    {
        int GetNumber();
        string GetName();
        int GetCardAmount();
        List<ICard> GetCards();
        void AddCard(ICard card);
        void AddCards(List<ICard> cards);
        ICard RemoveCard(int index);
        void RemoveCard(ICard card);
    }
}
