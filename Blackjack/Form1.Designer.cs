using System;
using System.Drawing;
using System.Windows.Forms;

namespace Blackjack
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.txtLog = new TextBox();
            this.btnHit = new Button();
            this.btnStand = new Button();
            this.btnNew = new Button();
            this.SuspendLayout();
            // 
            // txtLog
            // 
            this.txtLog.Location = new Point(12, 12);
            this.txtLog.Multiline = true;
            this.txtLog.ScrollBars = ScrollBars.Vertical;
            this.txtLog.ReadOnly = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.Size = new Size(736, 330);
            this.txtLog.TabIndex = 0;
            this.txtLog.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            // 
            // btnHit
            // 
            this.btnHit.Location = new Point(12, 360);
            this.btnHit.Name = "btnHit";
            this.btnHit.Size = new Size(240, 60);
            this.btnHit.TabIndex = 1;
            this.btnHit.Text = "Hit (Dealer)";
            this.btnHit.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            this.btnHit.Font = new Font(this.btnHit.Font.FontFamily, 12);
            this.btnHit.UseVisualStyleBackColor = true;
            this.btnHit.Click += btnHit_Click;
            // 
            // btnStand
            // 
            this.btnStand.Location = new Point(262, 360);
            this.btnStand.Name = "btnStand";
            this.btnStand.Size = new Size(240, 60);
            this.btnStand.TabIndex = 2;
            this.btnStand.Text = "Stand (Dealer)";
            this.btnStand.Anchor = AnchorStyles.Bottom;
            this.btnStand.Font = new Font(this.btnStand.Font.FontFamily, 12);
            this.btnStand.UseVisualStyleBackColor = true;
            this.btnStand.Click += btnStand_Click;
            // 
            // btnNew
            // 
            this.btnNew.Location = new Point(512, 360);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new Size(236, 60);
            this.btnNew.TabIndex = 3;
            this.btnNew.Text = "New Game";
            this.btnNew.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            this.btnNew.Font = new Font(this.btnNew.Font.FontFamily, 12);
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += btnNew_Click;
            // 
            // lstNames
            // 
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new SizeF(8F, 20F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(760, 440);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnStand);
            this.Controls.Add(this.btnHit);
            this.Controls.Add(this.txtLog);
            this.Name = "Form1";
            this.Text = "Blackjack";
            // 
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private TextBox txtLog;
        private Button btnHit;
        private Button btnStand;
        private Button btnNew;
    }
}
