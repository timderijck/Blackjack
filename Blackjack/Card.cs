namespace Blackjack
{
    internal class Card
    {
        public string Suit;
        public string Rank;
        public int Value;

        public Card(string suit, string rank, int value)
        {
            Suit = suit;
            Rank = rank;
            Value = value;
        }
    }
}