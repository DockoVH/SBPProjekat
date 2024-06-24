namespace Projekat2SBP.Forme
{
    partial class JedanProstor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            RedniBrojLabel = new Label();
            SpratLabel = new Label();
            TipLabel = new Label();
            DodatnoLabel = new Label();
            RedniBrojTextBox = new TextBox();
            SpratTextBox = new TextBox();
            TipTextBox = new TextBox();
            DodatnoTextBox = new TextBox();
            BrojStanaraLabel = new Label();
            BrojStanaraTextBox = new TextBox();
            PrikaziStanareDugme = new Button();
            SuspendLayout();
            // 
            // RedniBrojLabel
            // 
            RedniBrojLabel.AutoSize = true;
            RedniBrojLabel.Location = new Point(32, 30);
            RedniBrojLabel.Name = "RedniBrojLabel";
            RedniBrojLabel.Size = new Size(81, 20);
            RedniBrojLabel.TabIndex = 0;
            RedniBrojLabel.Text = "Redni broj:";
            // 
            // SpratLabel
            // 
            SpratLabel.AutoSize = true;
            SpratLabel.Location = new Point(32, 63);
            SpratLabel.Name = "SpratLabel";
            SpratLabel.Size = new Size(47, 20);
            SpratLabel.TabIndex = 1;
            SpratLabel.Text = "Sprat:";
            // 
            // TipLabel
            // 
            TipLabel.AutoSize = true;
            TipLabel.Location = new Point(32, 96);
            TipLabel.Name = "TipLabel";
            TipLabel.Size = new Size(33, 20);
            TipLabel.TabIndex = 2;
            TipLabel.Text = "Tip:";
            // 
            // DodatnoLabel
            // 
            DodatnoLabel.AutoSize = true;
            DodatnoLabel.Location = new Point(32, 129);
            DodatnoLabel.Name = "DodatnoLabel";
            DodatnoLabel.Size = new Size(71, 20);
            DodatnoLabel.TabIndex = 3;
            DodatnoLabel.Text = "Dodatno:";
            // 
            // RedniBrojTextBox
            // 
            RedniBrojTextBox.Enabled = false;
            RedniBrojTextBox.Location = new Point(193, 23);
            RedniBrojTextBox.Name = "RedniBrojTextBox";
            RedniBrojTextBox.Size = new Size(125, 27);
            RedniBrojTextBox.TabIndex = 4;
            // 
            // SpratTextBox
            // 
            SpratTextBox.Enabled = false;
            SpratTextBox.Location = new Point(193, 56);
            SpratTextBox.Name = "SpratTextBox";
            SpratTextBox.Size = new Size(125, 27);
            SpratTextBox.TabIndex = 5;
            // 
            // TipTextBox
            // 
            TipTextBox.Enabled = false;
            TipTextBox.Location = new Point(193, 89);
            TipTextBox.Name = "TipTextBox";
            TipTextBox.Size = new Size(125, 27);
            TipTextBox.TabIndex = 6;
            // 
            // DodatnoTextBox
            // 
            DodatnoTextBox.Enabled = false;
            DodatnoTextBox.Location = new Point(193, 122);
            DodatnoTextBox.Name = "DodatnoTextBox";
            DodatnoTextBox.Size = new Size(125, 27);
            DodatnoTextBox.TabIndex = 7;
            // 
            // BrojStanaraLabel
            // 
            BrojStanaraLabel.AutoSize = true;
            BrojStanaraLabel.Location = new Point(32, 162);
            BrojStanaraLabel.Name = "BrojStanaraLabel";
            BrojStanaraLabel.Size = new Size(91, 20);
            BrojStanaraLabel.TabIndex = 8;
            BrojStanaraLabel.Text = "Broj stanara:";
            // 
            // BrojStanaraTextBox
            // 
            BrojStanaraTextBox.Enabled = false;
            BrojStanaraTextBox.Location = new Point(193, 155);
            BrojStanaraTextBox.Name = "BrojStanaraTextBox";
            BrojStanaraTextBox.Size = new Size(33, 27);
            BrojStanaraTextBox.TabIndex = 9;
            // 
            // PrikaziStanareDugme
            // 
            PrikaziStanareDugme.Location = new Point(232, 155);
            PrikaziStanareDugme.Name = "PrikaziStanareDugme";
            PrikaziStanareDugme.Size = new Size(86, 29);
            PrikaziStanareDugme.TabIndex = 10;
            PrikaziStanareDugme.Text = "Prikaži";
            PrikaziStanareDugme.UseVisualStyleBackColor = true;
            PrikaziStanareDugme.Click += PrikaziStanareDugme_Click;
            // 
            // JedanProstor
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(350, 197);
            Controls.Add(PrikaziStanareDugme);
            Controls.Add(BrojStanaraTextBox);
            Controls.Add(BrojStanaraLabel);
            Controls.Add(DodatnoTextBox);
            Controls.Add(TipTextBox);
            Controls.Add(SpratTextBox);
            Controls.Add(RedniBrojTextBox);
            Controls.Add(DodatnoLabel);
            Controls.Add(TipLabel);
            Controls.Add(SpratLabel);
            Controls.Add(RedniBrojLabel);
            Name = "JedanProstor";
            Text = "JedanProstor";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label RedniBrojLabel;
        private Label SpratLabel;
        private Label TipLabel;
        private Label DodatnoLabel;
        private TextBox RedniBrojTextBox;
        private TextBox SpratTextBox;
        private TextBox TipTextBox;
        private TextBox DodatnoTextBox;
        private Label BrojStanaraLabel;
        private TextBox BrojStanaraTextBox;
        private Button PrikaziStanareDugme;
    }
}