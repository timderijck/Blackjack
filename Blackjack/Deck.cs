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
                    // bepaal waarde gebaseerd op rang
                    int value;
                    string rank = ranks[j];
                    if (rank == "Ace")
                        value = 11; // Ace = 11, wordt aangepast bij optelling
                    else if (rank == "J" || rank == "Q" || rank == "K")
                        value = 10;
                    else
                    {
                        // Two-Ten -> 2-10
                        switch (rank)
                        {
                            case "Two": value = 2; break;
                            case "Three": value = 3; break;
                            case "Four": value = 4; break;
                            case "Five": value = 5; break;
                            case "Six": value = 6; break;
                            case "Seven": value = 7; break;
                            case "Eight": value = 8; break;
                            case "Nine": value = 9; break;
                            case "Ten": value = 10; break;
                            default: value = 0; break;
                        }
                    }

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