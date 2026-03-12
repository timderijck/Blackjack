namespace Blackjack
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
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

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtName = new Button();
            lstNames = new ListBox();
            textBox1 = new TextBox();
            Names = new Label();
            SuspendLayout();
            // 
            // txtName
            // 
            txtName.Location = new Point(201, 99);
            txtName.Name = "txtName";
            txtName.Size = new Size(94, 29);
            txtName.TabIndex = 0;
            txtName.Text = "Add Name";
            txtName.UseVisualStyleBackColor = true;
            txtName.Click += button1_Click;
            // 
            // lstNames
            // 
            lstNames.FormattingEnabled = true;
            lstNames.Location = new Point(12, 27);
            lstNames.Name = "lstNames";
            lstNames.Size = new Size(120, 84);
            lstNames.TabIndex = 2;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(331, 46);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 27);
            textBox1.TabIndex = 3;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // Names
            // 
            Names.AutoSize = true;
            Names.Location = new Point(12, 9);
            Names.Name = "Names";
            Names.Size = new Size(55, 20);
            Names.TabIndex = 4;
            Names.Text = "Names";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(Names);
            Controls.Add(textBox1);
            Controls.Add(lstNames);
            Controls.Add(txtName);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button txtName;

        public Label Names { get; private set; }

        private Label label1;
        private ListBox lstNames;
        private TextBox textBox1;
        private Label Names;
    }
}
