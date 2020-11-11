using SorteperLibrary.Cards.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SorteperLibrary.Generators
{
    /// <summary>
    /// Class to generate the cards
    /// </summary>
    public class CardGenerator
    {
        private List<ICard> _cards = new List<ICard>();

        // Method to generate cards
        public List<ICard> GenerateCards()
        {
            // needs to generate 51 cards. 13 for each suit, tho not 11 for suit clubs
            for (int i = 1; i < 5; i++)
            {
                switch (i)
                {
                    case 1:
                        for (int s = 1; s < 14; s++)
                        {
                            if (s == 11)
                            {
                                continue;
                            }
                            ICard card = new Card("Hearts", s);
                            _cards.Add(card);
                        }
                        break;
                    case 2:
                        for (int s = 1; s < 14; s++)
                        {
                            if (s == 11)
                            {
                                continue;
                            }
                            ICard card = new Card("Diamonds", s);
                            _cards.Add(card);
                        }
                        break;
                    case 3:
                        for (int s = 1; s < 14; s++)
                        {
                            ICard card = new Card("Clubs", s);
                            _cards.Add(card);
                        }
                        break;
                    case 4:
                        for (int s = 1; s < 14; s++)
                        {
                            if (s == 11)
                            {
                                continue;
                            }
                            ICard card = new Card("Spades", s);
                            _cards.Add(card);
                        }
                        break;
                }
            }
            return _cards;
        }
    }
}
