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
        int currentPlayer = 0;

        public void EndTurn()
        {
            if (currentPlayer == players.Count - 1)
            {
                currentPlayer = 0;
            }
            else
            {
                currentPlayer++;
            }
        }

        public void CheckVictory()
        {
            List<IPlayer> tempPlayers = new List<IPlayer>(players);
            foreach (IPlayer player in players)
            {
                if (player.GetCardAmount() == 0)
                {
                    tempPlayers.Remove(player);
                }
            }
            players = tempPlayers;
        }

        public void PlayerMatchCards()
        {
            cards = players[currentPlayer].GetCards();
            List<ICard> tempCards = new List<ICard>(cards);
            // edits the count and crashes
            foreach (ICard card in cards)
            {
                var x = cards.FindAll(c => c.GetSuit() == card.GetSuit() && c.GetValue() == card.GetValue());
                if (x.Count == 2)
                {
                    foreach (ICard matchingCard in x)
                    {
                        tempCards.Remove(matchingCard);
                    }
                }
            }
            players[currentPlayer].AddCards(tempCards);
        }

        public string PlayerTakeCard(int selectedCard)
        {
            // return the name of the card as well??
            // return color for now

            if (currentPlayer == players.Count)
            {
                ICard card = players[0].RemoveCard(selectedCard - 1);
                players[currentPlayer].AddCard(card);
                switch (card.GetSuit())
                {
                    case 1:
                        return "You got a red " + card.GetValue();
                    case 2:
                        return "You got a black " + card.GetValue();
                }
                return "take card error";
            }
            else if (currentPlayer == 0)
            {
                ICard card = players[players.Count - 1].RemoveCard(selectedCard - 1);
                players[currentPlayer].AddCard(card);
                switch (card.GetSuit())
                {
                    case 1:
                        return "You got a red " + card.GetValue();
                    case 2:
                        return "You got a black " + card.GetValue();
                }
                return "take card error";
            }
            else
            {
                ICard card = players[currentPlayer - 1].RemoveCard(selectedCard - 1);
                players[currentPlayer].AddCard(card);

                switch (card.GetSuit())
                {
                    case 1:
                        return "You got a red " + card.GetValue();
                    case 2:
                        return "You got a black " + card.GetValue();
                }
                return "take card error";
            }
        }
        public int ActivePlayers()
        {
            return players.Count;
        }

        public int[] PlayerSelectCard()
        {
            if (currentPlayer == players.Count)
            {
                return new int[] { 1, players[0].GetCardAmount() };
            }
            else if (currentPlayer == 0)
            {
                return new int[] { 1, players[players.Count - 1].GetCardAmount() };
            }
            else
            {
                return new int[] { 1, players[currentPlayer - 1].GetCardAmount() };
            }
        }

        public int CardsInPlay()
        {
            int cards = 0;
            foreach (IPlayer player in players)
            {
                cards += player.GetCards().Count;
            }
            return cards;
        }

        public void CreatePlayer(string name)
        {
            players.Add(new Human(name, players.Count, new List<ICard>()));
        }

        public string GetPlayerName()
        {
            return players[currentPlayer].GetName();
        }

        public int GetCurrentPlayer()
        {
            return currentPlayer;
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
