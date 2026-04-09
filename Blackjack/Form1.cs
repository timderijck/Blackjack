using System;
using System.Collections.Generic;
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
            StartNewGame();
        }

        private void StartNewGame()
        {
            deck = new Deck();
            deck.Shuffle();
            playerHand.Clear();
            dealerHand.Clear();
            txtLog.Clear();

            // initial deal: two cards each
            playerHand.Add(deck.Draw());
            dealerHand.Add(deck.Draw());
            playerHand.Add(deck.Draw());
            dealerHand.Add(deck.Draw());

            UpdateDisplay();
        }

        private int HandValue(List<Card> hand)
        {
            int total = 0;
            int aces = 0;
            foreach (var c in hand)
            {
                total += c.Value;
                if (c.Rank == "Ace") aces++;
            }
            // adjust aces from 11 to 1 if bust
            while (total > 21 && aces > 0)
            {
                total -= 10; // make one Ace worth 1 instead of 11
                aces--;
            }
            return total;
        }

        private void UpdateDisplay()
        {
            txtLog.Clear();
            // From dealer perspective: show dealer fully, player hidden partly
            txtLog.AppendText("Dealer (you):\r\n");
            foreach (var c in dealerHand)
                txtLog.AppendText($"{c.Rank} of {c.Suit} ({c.Value})\r\n");
            txtLog.AppendText($"Total: {HandValue(dealerHand)}\r\n\r\n");

            txtLog.AppendText("Player:\r\n");
            txtLog.AppendText($"{playerHand[0].Rank} of {playerHand[0].Suit} ({playerHand[0].Value})\r\n");
            txtLog.AppendText("(second card hidden)\r\n");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // kept for compatibility if designer wires old name - treat as Hit
            DoHit();
        }

        private void btnHit_Click(object sender, EventArgs e)
        {
            DoHit();
        }

        private void DoHit()
        {
            // Dealer takes a card
            dealerHand.Add(deck.Draw());
            UpdateDisplay();
            int d = HandValue(dealerHand);
            if (d > 21)
            {
                MessageBox.Show($"Dealer busted with {d}! Player wins.");
                StartNewGame();
            }
        }

        private void btnStand_Click(object sender, EventArgs e)
        {
            // Dealer stands -> player auto-plays simple strategy: hit until 17
            while (HandValue(playerHand) < 17)
                playerHand.Add(deck.Draw());

            int p = HandValue(playerHand);
            int d = HandValue(dealerHand);

            txtLog.AppendText("\r\nPlayer reveals:\r\n");
            foreach (var c in playerHand)
                txtLog.AppendText($"{c.Rank} of {c.Suit} ({c.Value})\r\n");
            txtLog.AppendText($"Total: {p}\r\n");

            // determine outcome from dealer perspective
            if (p > 21 || d > p)
                MessageBox.Show("Dealer wins.");
            else if (d == p)
                MessageBox.Show("Push.");
            else
                MessageBox.Show("Player wins.");

            StartNewGame();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            StartNewGame();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }
    }
}
