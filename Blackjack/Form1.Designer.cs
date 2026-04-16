using System;
using System.Drawing;
using System.Windows.Forms;

namespace Blackjack
{
    partial class Form1
    {
        // storage voor alle controls (buttons, boxes, etc)
        private System.ComponentModel.IContainer components = null;

        // cleanup als form sluit
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        // build het hele scherm
        private void InitializeComponent()
        {
            // maak alle controls aan
            this.txtLog = new TextBox(); // grote text box voor info
            this.pbDealer1 = new PictureBox(); // dealer kaart 1
            this.pbDealer2 = new PictureBox(); // dealer kaart 2
            this.pbPlayer1 = new PictureBox(); // speler kaart 1
            this.pbPlayer2 = new PictureBox(); // speler kaart 2
            this.btnHit = new Button(); // knop "Hit"
            this.btnStand = new Button(); // knop "Stand"
            this.btnNew = new Button(); // knop "New Game"
            this.SuspendLayout();
            
            // ============ DEALER KAARTEN LINKSBOVEN ============
            
            // pbDealer1: eerste kaart dealer (linksboven)
            this.pbDealer1.Location = new Point(12, 12); // plaats: x=12, y=12
            this.pbDealer1.Name = "pbDealer1";
            this.pbDealer1.Size = new Size(100, 150); // groot: 100x150 pixels
            this.pbDealer1.SizeMode = PictureBoxSizeMode.Zoom; // zorg dat plaatje mooi past
            this.pbDealer1.TabIndex = 0;
            this.pbDealer1.TabStop = false;
            
            // pbDealer2: tweede kaart dealer (naast eerste)
            this.pbDealer2.Location = new Point(122, 12); // x=122 (12 + 100 + kleine ruimte)
            this.pbDealer2.Name = "pbDealer2";
            this.pbDealer2.Size = new Size(100, 150);
            this.pbDealer2.SizeMode = PictureBoxSizeMode.Zoom;
            this.pbDealer2.TabIndex = 1;
            this.pbDealer2.TabStop = false;
            
            // ============ SPELER KAARTEN LINKSMIDDEN ============
            
            // pbPlayer1: eerste kaart speler (onder dealer 1)
            this.pbPlayer1.Location = new Point(12, 170); // y=170 (12 + 150 + ruimte)
            this.pbPlayer1.Name = "pbPlayer1";
            this.pbPlayer1.Size = new Size(100, 150);
            this.pbPlayer1.SizeMode = PictureBoxSizeMode.Zoom;
            this.pbPlayer1.TabIndex = 2;
            this.pbPlayer1.TabStop = false;
            
            // pbPlayer2: tweede kaart speler (naast eerste)
            this.pbPlayer2.Location = new Point(122, 170);
            this.pbPlayer2.Name = "pbPlayer2";
            this.pbPlayer2.Size = new Size(100, 150);
            this.pbPlayer2.SizeMode = PictureBoxSizeMode.Zoom;
            this.pbPlayer2.TabIndex = 3;
            this.pbPlayer2.TabStop = false;
            
            // ============ TEKSTVAK RECHTS (INFO) ============
            
            // txtLog: groot tekstvak voor spelinfo (rechts van kaarten)
            this.txtLog.Location = new Point(240, 12); // x=240, na de kaarten
            this.txtLog.Multiline = true; // meerdere regels
            this.txtLog.ScrollBars = ScrollBars.Vertical; // scroll knop
            this.txtLog.ReadOnly = true; // je kan hier niet typen
            this.txtLog.Name = "txtLog";
            this.txtLog.Size = new Size(508, 330); // 508 pixels breed, 330 hoog
            this.txtLog.TabIndex = 4;
            // anchor: zorg dat txt box mee groeit/krimpt met venster
            this.txtLog.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            
            // ============ KNOPPEN ONDERAAN ============
            
            // btnHit: knop "Hit" (kaart nemen)
            this.btnHit.Location = new Point(12, 360); // onderaan links
            this.btnHit.Name = "btnHit";
            this.btnHit.Size = new Size(240, 60); // brede knop
            this.btnHit.TabIndex = 1;
            this.btnHit.Text = "Hit"; // tekst op knop
            this.btnHit.Anchor = AnchorStyles.Bottom | AnchorStyles.Left; // stays onderaan links
            this.btnHit.Font = new Font(this.btnHit.Font.FontFamily, 12); // grotere font
            this.btnHit.UseVisualStyleBackColor = true;
            this.btnHit.Click += btnHit_Click; // als geklikt: btnHit_Click oproepen
            
            // btnStand: knop "Stand" (stoppen)
            this.btnStand.Location = new Point(262, 360); // in het midden
            this.btnStand.Name = "btnStand";
            this.btnStand.Size = new Size(240, 60);
            this.btnStand.TabIndex = 2;
            this.btnStand.Text = "Stand"; // tekst op knop
            this.btnStand.Anchor = AnchorStyles.Bottom; // stays onderaan midden
            this.btnStand.Font = new Font(this.btnStand.Font.FontFamily, 12);
            this.btnStand.UseVisualStyleBackColor = true;
            this.btnStand.Click += btnStand_Click;
            
            // btnNew: knop "New Game" (nieuw spel)
            this.btnNew.Location = new Point(512, 360); // onderaan rechts
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new Size(236, 60);
            this.btnNew.TabIndex = 3;
            this.btnNew.Text = "New Game"; // tekst op knop
            this.btnNew.Anchor = AnchorStyles.Bottom | AnchorStyles.Right; // stays onderaan rechts
            this.btnNew.Font = new Font(this.btnNew.Font.FontFamily, 12);
            this.btnNew.UseVisualStyleBackColor = true;
            
            // ============ VENSTER ZELF ============
            
            // Form1 instellingen
            this.AutoScaleDimensions = new SizeF(8F, 20F);
            this.AutoScaleMode = AutoScaleMode.Font; // schaal goed op verschillende schermen
            this.ClientSize = new Size(760, 440); // grote: 760 x 440 pixels
            
            // voeg alle controls toe aan het venster
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnStand);
            this.Controls.Add(this.btnHit);
            this.Controls.Add(this.txtLog); // tekstvak op achtergrond
            this.Controls.Add(this.pbPlayer2); // kaarten ervoor
            this.Controls.Add(this.pbPlayer1);
            this.Controls.Add(this.pbDealer2);
            this.Controls.Add(this.pbDealer1);
            
            this.Name = "Form1";
            this.Text = "Blackjack"; // titel van venster
            
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        // declareer alle controls zodat Form1.cs ze kan gebruiken
        private TextBox txtLog;
        private Button btnHit;
        private Button btnStand;
        private Button btnNew;
        private PictureBox pbDealer1;
        private PictureBox pbDealer2;
        private PictureBox pbPlayer1;
        private PictureBox pbPlayer2;
    }
}
