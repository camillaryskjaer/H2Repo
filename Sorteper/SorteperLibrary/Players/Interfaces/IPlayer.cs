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
        int GetCards();
        void AddCard(ICard card);
        ICard RemoveCard(int index);
    }
}
