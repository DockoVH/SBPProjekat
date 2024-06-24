namespace Projekat2SBP.Forme
{
    partial class JedanVlasnik
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
            JMBGLabel = new Label();
            AdresaLabel = new Label();
            ImeLabel = new Label();
            ImeRoditeljaLabel = new Label();
            PrezimeLabel = new Label();
            BrojeviTelefonaLabel = new Label();
            JMBGTextBox = new TextBox();
            AdresaTextBox = new TextBox();
            ImeTextBox = new TextBox();
            ImeRoditeljaTextBox = new TextBox();
            PrezimeTextBox = new TextBox();
            PrikaziTelefoneDugme = new Button();
            SuspendLayout();
            // 
            // JMBGLabel
            // 
            JMBGLabel.AutoSize = true;
            JMBGLabel.Location = new Point(46, 33);
            JMBGLabel.Name = "JMBGLabel";
            JMBGLabel.Size = new Size(49, 20);
            JMBGLabel.TabIndex = 0;
            JMBGLabel.Text = "JMBG:";
            // 
            // AdresaLabel
            // 
            AdresaLabel.AutoSize = true;
            AdresaLabel.Location = new Point(46, 66);
            AdresaLabel.Name = "AdresaLabel";
            AdresaLabel.Size = new Size(58, 20);
            AdresaLabel.TabIndex = 1;
            AdresaLabel.Text = "Adresa:";
            // 
            // ImeLabel
            // 
            ImeLabel.AutoSize = true;
            ImeLabel.Location = new Point(46, 99);
            ImeLabel.Name = "ImeLabel";
            ImeLabel.Size = new Size(37, 20);
            ImeLabel.TabIndex = 2;
            ImeLabel.Text = "Ime:";
            // 
            // ImeRoditeljaLabel
            // 
            ImeRoditeljaLabel.AutoSize = true;
            ImeRoditeljaLabel.Location = new Point(46, 132);
            ImeRoditeljaLabel.Name = "ImeRoditeljaLabel";
            ImeRoditeljaLabel.Size = new Size(97, 20);
            ImeRoditeljaLabel.TabIndex = 3;
            ImeRoditeljaLabel.Text = "Ime roditelja:";
            // 
            // PrezimeLabel
            // 
            PrezimeLabel.AutoSize = true;
            PrezimeLabel.Location = new Point(46, 165);
            PrezimeLabel.Name = "PrezimeLabel";
            PrezimeLabel.Size = new Size(65, 20);
            PrezimeLabel.TabIndex = 4;
            PrezimeLabel.Text = "Prezime:";
            // 
            // BrojeviTelefonaLabel
            // 
            BrojeviTelefonaLabel.AutoSize = true;
            BrojeviTelefonaLabel.Location = new Point(46, 200);
            BrojeviTelefonaLabel.Name = "BrojeviTelefonaLabel";
            BrojeviTelefonaLabel.Size = new Size(117, 20);
            BrojeviTelefonaLabel.TabIndex = 5;
            BrojeviTelefonaLabel.Text = "Brojevi telefona:";
            // 
            // JMBGTextBox
            // 
            JMBGTextBox.Enabled = false;
            JMBGTextBox.Location = new Point(211, 26);
            JMBGTextBox.Name = "JMBGTextBox";
            JMBGTextBox.Size = new Size(125, 27);
            JMBGTextBox.TabIndex = 6;
            // 
            // AdresaTextBox
            // 
            AdresaTextBox.Enabled = false;
            AdresaTextBox.Location = new Point(211, 59);
            AdresaTextBox.Name = "AdresaTextBox";
            AdresaTextBox.Size = new Size(125, 27);
            AdresaTextBox.TabIndex = 7;
            // 
            // ImeTextBox
            // 
            ImeTextBox.Enabled = false;
            ImeTextBox.Location = new Point(211, 92);
            ImeTextBox.Name = "ImeTextBox";
            ImeTextBox.Size = new Size(125, 27);
            ImeTextBox.TabIndex = 8;
            // 
            // ImeRoditeljaTextBox
            // 
            ImeRoditeljaTextBox.Enabled = false;
            ImeRoditeljaTextBox.Location = new Point(211, 125);
            ImeRoditeljaTextBox.Name = "ImeRoditeljaTextBox";
            ImeRoditeljaTextBox.Size = new Size(125, 27);
            ImeRoditeljaTextBox.TabIndex = 9;
            // 
            // PrezimeTextBox
            // 
            PrezimeTextBox.Enabled = false;
            PrezimeTextBox.Location = new Point(211, 158);
            PrezimeTextBox.Name = "PrezimeTextBox";
            PrezimeTextBox.Size = new Size(125, 27);
            PrezimeTextBox.TabIndex = 10;
            // 
            // PrikaziTelefoneDugme
            // 
            PrikaziTelefoneDugme.Location = new Point(211, 191);
            PrikaziTelefoneDugme.Name = "PrikaziTelefoneDugme";
            PrikaziTelefoneDugme.Size = new Size(125, 29);
            PrikaziTelefoneDugme.TabIndex = 11;
            PrikaziTelefoneDugme.Text = "Prikaži";
            PrikaziTelefoneDugme.UseVisualStyleBackColor = true;
            PrikaziTelefoneDugme.Click += PrikaziTelefoneDugme_Click;
            // 
            // JedanVlasnik
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(379, 252);
            Controls.Add(PrikaziTelefoneDugme);
            Controls.Add(PrezimeTextBox);
            Controls.Add(ImeRoditeljaTextBox);
            Controls.Add(ImeTextBox);
            Controls.Add(AdresaTextBox);
            Controls.Add(JMBGTextBox);
            Controls.Add(BrojeviTelefonaLabel);
            Controls.Add(PrezimeLabel);
            Controls.Add(ImeRoditeljaLabel);
            Controls.Add(ImeLabel);
            Controls.Add(AdresaLabel);
            Controls.Add(JMBGLabel);
            Name = "JedanVlasnik";
            Text = "JedanVlasnik";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label JMBGLabel;
        private Label AdresaLabel;
        private Label ImeLabel;
        private Label ImeRoditeljaLabel;
        private Label PrezimeLabel;
        private Label BrojeviTelefonaLabel;
        private TextBox JMBGTextBox;
        private TextBox AdresaTextBox;
        private TextBox ImeTextBox;
        private TextBox ImeRoditeljaTextBox;
        private TextBox PrezimeTextBox;
        private Button PrikaziTelefoneDugme;
    }
}