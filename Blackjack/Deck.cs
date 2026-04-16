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
            string[] suits = { "hearts", "diamonds", "clubs", "spades" };
            string[] ranks = { "ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "jack", "queen", "king" };

            foreach (string s in suits)
            {
                foreach (string r in ranks)
                {
                    int val;
                    if (r == "ace") val = 11;
                    else if (r == "jack" || r == "queen" || r == "king") val = 10;
                    else val = int.Parse(r);

                    cards.Add(new Card(r, s, val));
                }
            }
        }

        public void Shuffle()
        {
            for (int i = 0; i < cards.Count; i++)
            {
                int j = rnd.Next(cards.Count);
                Card temp = cards[i];
                cards[i] = cards[j];
                cards[j] = temp;
            }
        }

        public Card Draw()
        {
            Card kaart = cards[0];
            cards.RemoveAt(0);
            return kaart;
        }
    }
}