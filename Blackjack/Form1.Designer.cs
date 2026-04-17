namespace Blackjack
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtLog = new System.Windows.Forms.TextBox();
            this.pbDealer1 = new System.Windows.Forms.PictureBox();
            this.pbDealer2 = new System.Windows.Forms.PictureBox();
            this.pbPlayer1 = new System.Windows.Forms.PictureBox();
            this.pbPlayer2 = new System.Windows.Forms.PictureBox();
            this.btnHit = new System.Windows.Forms.Button();
            this.btnStand = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();

            // Form instellingen
            this.Text = "Blackjack Dealer Trainer - Tim de Rijck";
            this.ClientSize = new System.Drawing.Size(760, 440);

            // Controls configureren via helper
            SetupPB(pbDealer1, 12, 12); SetupPB(pbDealer2, 122, 12);
            SetupPB(pbPlayer1, 12, 170); SetupPB(pbPlayer2, 122, 170);

            txtLog.Multiline = true; txtLog.ReadOnly = true;
            txtLog.Bounds = new System.Drawing.Rectangle(240, 12, 500, 330);

            btnHit.Text = "Hit"; btnHit.Bounds = new System.Drawing.Rectangle(12, 360, 240, 60);
            btnStand.Text = "Stand"; btnStand.Bounds = new System.Drawing.Rectangle(260, 360, 240, 60);
            btnNew.Text = "New Game"; btnNew.Bounds = new System.Drawing.Rectangle(508, 360, 240, 60);

            // Events koppelen
            btnHit.Click += btnHit_Click;
            btnStand.Click += btnStand_Click;
            btnNew.Click += btnNew_Click;

            this.Controls.AddRange(new System.Windows.Forms.Control[] { txtLog, pbDealer1, pbDealer2, pbPlayer1, pbPlayer2, btnHit, btnStand, btnNew });
        }

        private void SetupPB(System.Windows.Forms.PictureBox pb, int x, int y)
        {
            pb.Bounds = new System.Drawing.Rectangle(x, y, 100, 150);
            pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
        }

        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.PictureBox pbDealer1, pbDealer2, pbPlayer1, pbPlayer2;
        private System.Windows.Forms.Button btnHit, btnStand, btnNew;
    }
}