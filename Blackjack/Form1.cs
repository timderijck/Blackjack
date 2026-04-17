using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Blackjack
{
    public partial class Form1 : Form
    {
        private Deck deck;
        private List<Card> playerHand = new List<Card>();
        private List<Card> dealerHand = new List<Card>();
        private int trainingScore = 0;

        public Form1()
        {
            InitializeComponent();
            StartNewGame();
        }

        private void StartNewGame()
        {
            // hier wordt een nieuw deck gemaakt en geschud
            deck = new Deck();
            deck.Shuffle();
            playerHand.Clear();
            dealerHand.Clear();

            // hier worden de eerste kaarten gedeeld
            playerHand.Add(deck.Draw());
            dealerHand.Add(deck.Draw());
            playerHand.Add(deck.Draw());
            dealerHand.Add(deck.Draw());

            // hier pakt de speler automatisch kaarten tot 17 punten
            while (BerekenScore(playerHand) < 17) playerHand.Add(deck.Draw());

            ToonScherm(false);
        }

        private int BerekenScore(List<Card> hand)
        {
            // hier wordt de score berekend met logica voor de aas
            int totaal = 0, azen = 0;
            foreach (Card c in hand) { totaal += c.Value; if (c.Rank == "ace") azen++; }
            while (totaal > 21 && azen > 0) { totaal -= 10; azen--; }
            return totaal;
        }

        private void ToonScherm(bool reveal)
        {
            // hier wordt de tekst en hint getoond
            txtLog.Clear();
            txtLog.AppendText($"Score Training: {trainingScore}\r\n");
            txtLog.AppendText($"Punten speler: {BerekenScore(playerHand)}\r\n");

            if (!reveal)
            {
                txtLog.AppendText($"Jouw open kaart: {dealerHand[0].Value}\r\n");
                txtLog.AppendText(BerekenScore(dealerHand) < 17 ? "\r\nHINT: Je moet trekken." : "\r\nHINT: Je moet passen.");
            }

            // hier worden de plaatjes geladen (met check of bestand bestaat)
            pbPlayer1.Image = LaadKaart(playerHand[0].ImageFile);
            pbPlayer2.Image = LaadKaart(playerHand[1].ImageFile);
            pbDealer1.Image = LaadKaart(dealerHand[0].ImageFile);
            pbDealer2.Image = LaadKaart(reveal ? dealerHand[1].ImageFile : "back.png");
        }

        private Image LaadKaart(string bestand)
        {
            // hier wordt gezocht naar de afbeelding in de Cards map
            string pad = Path.Combine(Application.StartupPath, "Cards", bestand);
            if (File.Exists(pad)) return Image.FromFile(pad);
            return null;
        }

        private void btnHit_Click(object sender, EventArgs e)
        {
            // hier wordt gecontroleerd of de dealer terecht trekt
            if (BerekenScore(dealerHand) >= 17)
            {
                trainingScore -= 10;
                MessageBox.Show("Fout! Je moet passen op 17 of hoger.");
            }
            else
            {
                trainingScore += 5;
                dealerHand.Add(deck.Draw());
                ToonScherm(true);
                if (BerekenScore(dealerHand) > 21) BepaalWinnaar("Bust!");
            }
        }

        private void btnStand_Click(object sender, EventArgs e)
        {
            // hier wordt gecontroleerd of de dealer terecht past
            if (BerekenScore(dealerHand) < 17)
            {
                trainingScore -= 10;
                MessageBox.Show("Fout! Je moet trekken tot minimaal 17.");
            }
            else
            {
                trainingScore += 5;
                BepaalWinnaar("Dealer past.");
            }
        }

        private void BepaalWinnaar(string reden)
        {
            // hier wordt de winnaar bepaald en de 3:2 uitbetaling berekend
            int ps = BerekenScore(playerHand), ds = BerekenScore(dealerHand);
            string resultaat = (ds > 21 || (ps <= 21 && ps > ds)) ? "Speler wint!" : (ds == ps ? "Push!" : "Dealer wint!");
            double uitbetaling = (resultaat == "Speler wint!" && ps == 21 && playerHand.Count == 2) ? 150 : 100;

            MessageBox.Show($"{reden}\n{resultaat}\nUitbetaling: {uitbetaling}");
            StartNewGame();
        }

        private void btnNew_Click(object sender, EventArgs e) => StartNewGame();
    }
}