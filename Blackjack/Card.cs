namespace Blackjack
{
    internal class Card
    {
        public string Rank;
        public int Value;
        public string ImageFile;

        public Card(string rank, string suit, int value)
        {
            Rank = rank;
            Value = value;
            // hier wordt de bestandsnaam samengesteld
            ImageFile = rank + "_of_" + suit + ".png";
        }
    }
}