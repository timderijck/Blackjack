using System;
using System.Collections.Generic;

namespace Blackjack
{
    internal class Deck
    {
        private List<Card> cards = new List<Card>();
        private Random rnd = new Random();

        public Deck()
        {
            // hier worden 4 decks aan de lijst toegevoegd (de shoe)
            string[] suits = { "hearts", "diamonds", "clubs", "spades" };
            string[] ranks = { "ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "jack", "queen", "king" };

            for (int i = 0; i < 4; i++)
            {
                foreach (string s in suits)
                {
                    foreach (string r in ranks)
                    {
                        int val = (r == "ace") ? 11 : (r == "jack" || r == "queen" || r == "king") ? 10 : int.Parse(r);
                        cards.Add(new Card(r, s, val));
                    }
                }
            }
        }

        public void Shuffle()
        {
            // hier worden de kaarten geschud
            for (int i = cards.Count - 1; i > 0; i--)
            {
                int j = rnd.Next(i + 1);
                Card temp = cards[i];
                cards[i] = cards[j];
                cards[j] = temp;
            }
        }

        public Card Draw()
        {
            // hier wordt de bovenste kaart getrokken
            if (cards.Count == 0) return null;
            Card kaart = cards[0];
            cards.RemoveAt(0);
            return kaart;
        }
    }
}