using SorteperLibrary.Cards.Interfaces;
using SorteperLibrary.Generators;
using SorteperLibrary.Players;
using SorteperLibrary.Players.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SorteperLibrary
{
    public class GameManager
    {
        List<ICard> cards = new CardGenerator().GenerateCards();

        List<IPlayer> players = new List<IPlayer>();
        Random random = new Random();

        public void CreatePlayer(string name)
        {
            players.Add(new Human(name, players.Count, new List<ICard>()));
        }

        public void DealCards()
        {
            while (cards.Count != 0)
            {
                foreach (IPlayer player in players)
                {
                    if (cards.Count != 0)
                    {
                        int select = random.Next(0, cards.Count);
                        player.AddCard(cards[select]);
                        cards.RemoveAt(select);
                    }
                }
            }
        }
    }
}
