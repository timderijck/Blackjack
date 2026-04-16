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
            // Maakt automatisch de bestandsnaam: bijv. "ace_of_hearts.png"
            ImageFile = rank + "_of_" + suit + ".png";
        }
    }
}