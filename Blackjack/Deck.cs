using System;
using System.Collections.Generic;

namespace Blackjack
{
    internal class Deck
    {
        private List<Card> cards = new List<Card>();
        private Random random = new Random();

        public Deck()
        {
            string[] suits = { "Hearts", "Diamonds", "Clubs", "Spades" };
            string[] ranks = { "Ace", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "J", "Q", "K" };

            // maakt 52 kaarten
            for (int i = 0; i < suits.Length; i++)
            {
                for (int j = 0; j < ranks.Length; j++)
                {
                    int value = random.Next(1, 12); // dit is willekeurig 1 t/m 11

                    Card card = new Card(suits[i], ranks[j], value);
                    cards.Add(card);
                }
            }
        }
        // hier gebeurt het shufflen van de kaarten
        public void Shuffle()
        {
            for (int i = 0; i < cards.Count; i++)
            {
                int randomIndex = random.Next(cards.Count);

                Card temp = cards[i];
                cards[i] = cards[randomIndex];
                cards[randomIndex] = temp;
            }
        }
        // het drawen van een card
        public Card Draw()
        {
            Card card = cards[0];
            cards.RemoveAt(0);
            return card;
        }
    }
}