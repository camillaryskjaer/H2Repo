using SorteperLibrary.Cards.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SorteperLibrary.Players
{
    public abstract class Player
    {
        protected int _playerNumber;
        protected string _playerName;
        protected List<ICard> _cards;
    }
}
