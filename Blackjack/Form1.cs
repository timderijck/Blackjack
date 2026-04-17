using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Blackjack
{
    public partial class Form1 : Form
    {
        private Deck deck;
        private List<Card> playerHand = new List<Card>();
        private List<Card> dealerHand = new List<Card>();

        public Form1()
        {
            InitializeComponent();

            // hier wordt de nieuw spel knop aangezet
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);

            StartNewGame();
        }

        private void StartNewGame()
        {
            // hier wordt een nieuw deck gemaakt en geschud
            deck = new Deck();
            deck.Shuffle();
            playerHand.Clear();
            dealerHand.Clear();

            // hier worden de eerste kaarten uitgedeeld
            playerHand.Add(deck.Draw());
            dealerHand.Add(deck.Draw());
            playerHand.Add(deck.Draw());
            dealerHand.Add(deck.Draw());

            // hier pakt de speler automatisch kaarten tot 17 punten
            while (BerekenScore(playerHand) < 17)
            {
                playerHand.Add(deck.Draw());
            }

            ToonScherm();
        }

        private int BerekenScore(List<Card> hand)
        {
            // hier wordt de score van een hand berekend
            int totaal = 0;
            int azen = 0;
            foreach (Card c in hand)
            {
                totaal += c.Value;
                if (c.Rank == "ace") azen++;
            }
            // hier wordt de aas van 11 naar 1 gezet bij meer dan 21 punten
            while (totaal > 21 && azen > 0)
            {
                totaal -= 10;
                azen--;
            }
            return totaal;
        }

        private void ToonScherm()
        {
            // hier wordt de tekst in het vak gezet (zonder de score van de speler)
            txtLog.Clear();
            txtLog.AppendText("De speler heeft zijn kaarten gepakt.\r\n");
            txtLog.AppendText("Jouw punten: " + BerekenScore(dealerHand) + "\r\n");
            txtLog.AppendText("\r\nKlik op 'Hit' voor een kaart of 'Stand' om te stoppen.");

            // hier worden de plaatjes van de kaarten geladen
            pbPlayer1.Image = Image.FromFile("Cards/" + playerHand[0].ImageFile);
            pbPlayer2.Image = Image.FromFile("Cards/" + playerHand[1].ImageFile);
            pbDealer1.Image = Image.FromFile("Cards/" + dealerHand[0].ImageFile);
            pbDealer2.Image = Image.FromFile("Cards/" + dealerHand[1].ImageFile);
        }

        private void btnHit_Click(object sender, EventArgs e)
        {
            // hier krijgt de dealer een kaart als hij op hit klikt
            dealerHand.Add(deck.Draw());
            ToonScherm();

            // hier wordt gekeken of de dealer over de 21 is
            if (BerekenScore(dealerHand) > 21)
            {
                MessageBox.Show("Bust!");
                StartNewGame();
            }
        }

        private void btnStand_Click(object sender, EventArgs e)
        {
            // hier worden de scores vergeleken als de dealer stopt
            int scoreSpeler = BerekenScore(playerHand);
            int scoreDealer = BerekenScore(dealerHand);

            string bericht = "Punten speler: " + scoreSpeler + "\r\nJouw punten: " + scoreDealer + "\r\n\r\n";

            if (scoreSpeler > 21 || scoreDealer > scoreSpeler)
            {
                MessageBox.Show(bericht + "Je hebt gewonnen!");
            }
            else if (scoreSpeler > scoreDealer)
            {
                MessageBox.Show(bericht + "Helaas! Je hebt verloren.");
            }
            else
            {
                MessageBox.Show(bericht + "Gelijkspel!");
            }

            StartNewGame();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            // hier wordt een nieuw spel gestart als je op de knop klikt
            StartNewGame();
        }
    }
}