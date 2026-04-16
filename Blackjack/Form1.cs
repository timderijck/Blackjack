using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Blackjack
{
    public partial class Form1 : Form
    {
        private Deck deck;
        private List<Card> playerHand = new List<Card>(); // De tegenstander
        private List<Card> dealerHand = new List<Card>(); // Jij (de gebruiker)

        public Form1()
        {
            InitializeComponent();

            // Koppel de New Game knop aan de functie
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);

            StartNewGame();
        }

        private void StartNewGame()
        {
            deck = new Deck();
            deck.Shuffle();
            playerHand.Clear();
            dealerHand.Clear();

            // Deel de eerste kaarten
            playerHand.Add(deck.Draw());
            dealerHand.Add(deck.Draw());
            playerHand.Add(deck.Draw());
            dealerHand.Add(deck.Draw());

            // De tegenstander (speler) speelt direct volgens de regels (stoppen bij 17)
            while (BerekenScore(playerHand) < 17)
            {
                playerHand.Add(deck.Draw());
            }

            ToonScherm();
        }

        private int BerekenScore(List<Card> hand)
        {
            int totaal = 0;
            int azen = 0;
            foreach (Card c in hand)
            {
                totaal += c.Value;
                if (c.Rank == "ace") azen++;
            }
            while (totaal > 21 && azen > 0)
            {
                totaal -= 10;
                azen--;
            }
            return totaal;
        }

        private void ToonScherm()
        {
            txtLog.Clear();
            txtLog.AppendText("Punten speler: " + BerekenScore(playerHand) + "\r\n");
            txtLog.AppendText("Jouw punten: " + BerekenScore(dealerHand) + "\r\n");
            txtLog.AppendText("\r\nKlik op 'Hit' voor een kaart of 'Stand' om te stoppen.");

            // Plaatjes laden
            pbPlayer1.Image = Image.FromFile("Cards/" + playerHand[0].ImageFile);
            pbPlayer2.Image = Image.FromFile("Cards/" + playerHand[1].ImageFile);
            pbDealer1.Image = Image.FromFile("Cards/" + dealerHand[0].ImageFile);
            pbDealer2.Image = Image.FromFile("Cards/" + dealerHand[1].ImageFile);
        }

        private void btnHit_Click(object sender, EventArgs e)
        {
            dealerHand.Add(deck.Draw());
            ToonScherm();

            if (BerekenScore(dealerHand) > 21)
            {
                MessageBox.Show("Je bent helaas bust (over de 21). De speler wint!");
                StartNewGame();
            }
        }

        private void btnStand_Click(object sender, EventArgs e)
        {
            int scoreSpeler = BerekenScore(playerHand);
            int scoreDealer = BerekenScore(dealerHand);

            string bericht = $"Punten speler: {scoreSpeler}\r\nJouw punten: {scoreDealer}\r\n\r\n";

            if (scoreSpeler > 21 || scoreDealer > scoreSpeler)
            {
                MessageBox.Show(bericht + "Gefeliciteerd, je hebt gewonnen!");
            }
            else if (scoreSpeler > scoreDealer)
            {
                MessageBox.Show(bericht + "Helaas, de speler heeft een hogere score.");
            }
            else
            {
                MessageBox.Show(bericht + "Het is een gelijkspel!");
            }

            StartNewGame();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            StartNewGame();
        }
    }
}