namespace Blackjack
{
    internal class Card
    {
        public string Rank;
        public string Suit;
        public int Value;
        public string ImageFile;

        public Card(string rank, string suit, int value, string imageFile)
        {
            Rank = rank;
            Suit = suit;
            Value = value;
            ImageFile = imageFile;
        }
    }
}