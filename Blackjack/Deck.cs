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
                    int val = 10;
                    if (int.TryParse(r, out int n)) val = n;
                    if (r == "ace") val = 11;

                    cards.Add(new Card(r, s, val, r + "_of_" + s + ".png"));
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
            Card c = cards[0];
            cards.RemoveAt(0);
            return c;
        }
    }
}