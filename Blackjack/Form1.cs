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
        private int trainingScore = 0; 
        private bool isRondeBezig = false;

        public Form1()
        {
            InitializeComponent();
            StartNewGame();
        }

        private void StartNewGame()
        {
            deck = new Deck(4);
            deck.Shuffle();
            playerHand.Clear();
            dealerHand.Clear();
            isRondeBezig = true;

            // Delen: dealer krijgt 1 open, 1 dicht (Must Have)
            playerHand.Add(deck.Draw());
            dealerHand.Add(deck.Draw());
            playerHand.Add(deck.Draw());
            dealerHand.Add(deck.Draw());

            // AI Speler stopt automatisch op 17
            while (BerekenScore(playerHand) < 17) playerHand.Add(deck.Draw());

            ToonScherm(false);
        }

        private int BerekenScore(List<Card> hand)
        {
            int totaal = 0, azen = 0;
            foreach (Card c in hand) { totaal += c.Value; if (c.Rank == "ace") azen++; }
            while (totaal > 21 && azen > 0) { totaal -= 10; azen--; }
            return totaal;
        }

        private void ToonScherm(bool toonAlles)
        {
            txtLog.Clear();
            txtLog.AppendText($"TRAINING SCORE: {trainingScore}\r\n");
            txtLog.AppendText($"Speler score: {BerekenScore(playerHand)}\r\n");

            if (!toonAlles)
            {
                txtLog.AppendText($"Jouw zichtbare kaart: {dealerHand[0].Value}\r\n");
                // Hint (Should Have)
                txtLog.AppendText(BerekenScore(dealerHand) < 17 ? "HINT: Trek een kaart." : "HINT: Je moet passen.");
            }
            else
            {
                txtLog.AppendText($"Jouw totale score: {BerekenScore(dealerHand)}\r\n");
            }

            // Plaatjes
            pbPlayer1.Image = Image.FromFile("Cards/" + playerHand[0].ImageFile);
            pbPlayer2.Image = Image.FromFile("Cards/" + playerHand[1].ImageFile);
            pbDealer1.Image = Image.FromFile("Cards/" + dealerHand[0].ImageFile);
            // Must Have: tweede kaart dealer is dicht
            pbDealer2.Image = Image.FromFile(toonAlles ? "Cards/" + dealerHand[1].ImageFile : "Cards/back.png");
        }

        private void btnHit_Click(object sender, EventArgs e)
        {
            if (!isRondeBezig) return;

            // Validatie: mag dealer hitten? (Must Have)
            if (BerekenScore(dealerHand) >= 17)
            {
                trainingScore -= 10;
                MessageBox.Show("FOUT! Dealer moet passen op 17+.");
            }
            else
            {
                trainingScore += 5;
                dealerHand.Add(deck.Draw());
                ToonScherm(true);
                if (BerekenScore(dealerHand) > 21) EindRonde("Bust!");
            }
        }

        private void btnStand_Click(object sender, EventArgs e)
        {
            if (!isRondeBezig) return;

            // Validatie: mag dealer passen? (Must Have)
            if (BerekenScore(dealerHand) < 17)
            {
                trainingScore -= 10;
                MessageBox.Show("FOUT! Je moet trekken tot minimaal 17.");
            }
            else
            {
                trainingScore += 5;
                EindRonde("Je past.");
            }
        }

        private void EindRonde(string reden)
        {
            isRondeBezig = false;
            ToonScherm(true);
            int ps = BerekenScore(playerHand), ds = BerekenScore(dealerHand);
            double winst = 100;

            string resultaat = (ds > 21 || (ps <= 21 && ps > ds)) ? "Speler wint!" : (ds == ps ? "Gelijkspel!" : "Je hebt gewonnen!");

            // Should Have: 3:2 uitbetaling bij Blackjack
            if (resultaat == "Speler wint!" && ps == 21 && playerHand.Count == 2) winst = 150;

            MessageBox.Show($"{reden}\n{resultaat}\nUitbetaling: {winst}");
            StartNewGame();
        }

        private void btnNew_Click(object sender, EventArgs e) => StartNewGame();
    }
}