namespace Projekat2SBP.Forme
{
    partial class NoviZaposleni
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
            NoviZaposleniLabel = new Label();
            JMBGLabel = new Label();
            AdresaLabel = new Label();
            ImeLabel = new Label();
            ImeRodLabel = new Label();
            PrezimeLabel = new Label();
            BrojTelefonaLabel = new Label();
            DatumRodjenjaLabel = new Label();
            MestoIzdLKLabel = new Label();
            BrojLKLabel = new Label();
            PosaoLabel = new Label();
            JMBGTextBox = new TextBox();
            BrojeviListView = new ListView();
            AdresaTextBox = new TextBox();
            ImeTextBox = new TextBox();
            ImeRodTextBox = new TextBox();
            PrezimeTextBox = new TextBox();
            BrojLKTextBox = new TextBox();
            MestoIzdLKTextBox = new TextBox();
            DatumRodjDateTimePicker = new DateTimePicker();
            PosaoTextBox = new TextBox();
            BrojTelTextBox = new TextBox();
            DodajTelDugme = new Button();
            DodajZaposlenogDugme = new Button();
            OdbaciDugme = new Button();
            SuspendLayout();
            // 
            // NoviZaposleniLabel
            // 
            NoviZaposleniLabel.AutoSize = true;
            NoviZaposleniLabel.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            NoviZaposleniLabel.Location = new Point(52, 9);
            NoviZaposleniLabel.Name = "NoviZaposleniLabel";
            NoviZaposleniLabel.Size = new Size(255, 46);
            NoviZaposleniLabel.TabIndex = 0;
            NoviZaposleniLabel.Text = "Novi zaposleni";
            // 
            // JMBGLabel
            // 
            JMBGLabel.AutoSize = true;
            JMBGLabel.Location = new Point(12, 78);
            JMBGLabel.Name = "JMBGLabel";
            JMBGLabel.Size = new Size(49, 20);
            JMBGLabel.TabIndex = 1;
            JMBGLabel.Text = "JMBG:";
            // 
            // AdresaLabel
            // 
            AdresaLabel.AutoSize = true;
            AdresaLabel.Location = new Point(12, 115);
            AdresaLabel.Name = "AdresaLabel";
            AdresaLabel.Size = new Size(58, 20);
            AdresaLabel.TabIndex = 2;
            AdresaLabel.Text = "Adresa:";
            // 
            // ImeLabel
            // 
            ImeLabel.AutoSize = true;
            ImeLabel.Location = new Point(12, 148);
            ImeLabel.Name = "ImeLabel";
            ImeLabel.Size = new Size(37, 20);
            ImeLabel.TabIndex = 3;
            ImeLabel.Text = "Ime:";
            // 
            // ImeRodLabel
            // 
            ImeRodLabel.AutoSize = true;
            ImeRodLabel.Location = new Point(12, 181);
            ImeRodLabel.Name = "ImeRodLabel";
            ImeRodLabel.Size = new Size(148, 20);
            ImeRodLabel.TabIndex = 4;
            ImeRodLabel.Text = "Ime jednog roditelja:";
            // 
            // PrezimeLabel
            // 
            PrezimeLabel.AutoSize = true;
            PrezimeLabel.Location = new Point(12, 214);
            PrezimeLabel.Name = "PrezimeLabel";
            PrezimeLabel.Size = new Size(65, 20);
            PrezimeLabel.TabIndex = 5;
            PrezimeLabel.Text = "Prezime:";
            // 
            // BrojTelefonaLabel
            // 
            BrojTelefonaLabel.AutoSize = true;
            BrojTelefonaLabel.Location = new Point(12, 379);
            BrojTelefonaLabel.Name = "BrojTelefonaLabel";
            BrojTelefonaLabel.Size = new Size(100, 20);
            BrojTelefonaLabel.TabIndex = 6;
            BrojTelefonaLabel.Text = "Broj Telefona:";
            // 
            // DatumRodjenjaLabel
            // 
            DatumRodjenjaLabel.AutoSize = true;
            DatumRodjenjaLabel.Location = new Point(12, 247);
            DatumRodjenjaLabel.Name = "DatumRodjenjaLabel";
            DatumRodjenjaLabel.Size = new Size(112, 20);
            DatumRodjenjaLabel.TabIndex = 7;
            DatumRodjenjaLabel.Text = "Datum rođenja:";
            // 
            // MestoIzdLKLabel
            // 
            MestoIzdLKLabel.AutoSize = true;
            MestoIzdLKLabel.Location = new Point(12, 313);
            MestoIzdLKLabel.Name = "MestoIzdLKLabel";
            MestoIzdLKLabel.Size = new Size(140, 20);
            MestoIzdLKLabel.TabIndex = 8;
            MestoIzdLKLabel.Text = "Mesto izdavanja LK:";
            // 
            // BrojLKLabel
            // 
            BrojLKLabel.AutoSize = true;
            BrojLKLabel.Location = new Point(12, 280);
            BrojLKLabel.Name = "BrojLKLabel";
            BrojLKLabel.Size = new Size(111, 20);
            BrojLKLabel.TabIndex = 9;
            BrojLKLabel.Text = "Broj lične karte:";
            // 
            // PosaoLabel
            // 
            PosaoLabel.AutoSize = true;
            PosaoLabel.Location = new Point(12, 346);
            PosaoLabel.Name = "PosaoLabel";
            PosaoLabel.Size = new Size(51, 20);
            PosaoLabel.TabIndex = 10;
            PosaoLabel.Text = "Posao:";
            // 
            // JMBGTextBox
            // 
            JMBGTextBox.Location = new Point(240, 75);
            JMBGTextBox.Name = "JMBGTextBox";
            JMBGTextBox.Size = new Size(117, 27);
            JMBGTextBox.TabIndex = 11;
            JMBGTextBox.TextChanged += JMBGTextBox_TextChanged;
            JMBGTextBox.KeyPress += JMBGTextBox_KeyPress;
            // 
            // BrojeviListView
            // 
            BrojeviListView.Location = new Point(12, 451);
            BrojeviListView.Name = "BrojeviListView";
            BrojeviListView.Size = new Size(345, 121);
            BrojeviListView.TabIndex = 12;
            BrojeviListView.UseCompatibleStateImageBehavior = false;
            BrojeviListView.View = View.List;
            // 
            // AdresaTextBox
            // 
            AdresaTextBox.Location = new Point(240, 108);
            AdresaTextBox.Name = "AdresaTextBox";
            AdresaTextBox.Size = new Size(117, 27);
            AdresaTextBox.TabIndex = 13;
            AdresaTextBox.TextChanged += AdresaTextBox_TextChanged;
            // 
            // ImeTextBox
            // 
            ImeTextBox.Location = new Point(240, 141);
            ImeTextBox.Name = "ImeTextBox";
            ImeTextBox.Size = new Size(117, 27);
            ImeTextBox.TabIndex = 14;
            ImeTextBox.TextChanged += ImeTextBox_TextChanged;
            ImeTextBox.KeyPress += ImeTextBox_KeyPress;
            // 
            // ImeRodTextBox
            // 
            ImeRodTextBox.Location = new Point(240, 174);
            ImeRodTextBox.Name = "ImeRodTextBox";
            ImeRodTextBox.Size = new Size(117, 27);
            ImeRodTextBox.TabIndex = 15;
            ImeRodTextBox.TextChanged += ImeRodTextBox_TextChanged;
            ImeRodTextBox.KeyPress += ImeRodTextBox_KeyPress;
            // 
            // PrezimeTextBox
            // 
            PrezimeTextBox.Location = new Point(240, 207);
            PrezimeTextBox.Name = "PrezimeTextBox";
            PrezimeTextBox.Size = new Size(117, 27);
            PrezimeTextBox.TabIndex = 16;
            PrezimeTextBox.TextChanged += PrezimeTextBox_TextChanged;
            PrezimeTextBox.KeyPress += PrezimeTextBox_KeyPress;
            // 
            // BrojLKTextBox
            // 
            BrojLKTextBox.Location = new Point(240, 273);
            BrojLKTextBox.Name = "BrojLKTextBox";
            BrojLKTextBox.Size = new Size(117, 27);
            BrojLKTextBox.TabIndex = 17;
            BrojLKTextBox.TextChanged += BrojLKTextBox_TextChanged;
            BrojLKTextBox.KeyPress += BrojLKTextBox_KeyPress;
            // 
            // MestoIzdLKTextBox
            // 
            MestoIzdLKTextBox.Location = new Point(240, 306);
            MestoIzdLKTextBox.Name = "MestoIzdLKTextBox";
            MestoIzdLKTextBox.Size = new Size(117, 27);
            MestoIzdLKTextBox.TabIndex = 19;
            MestoIzdLKTextBox.TextChanged += MestoIzdLKTextBox_TextChanged;
            MestoIzdLKTextBox.KeyPress += MestoIzdLKTextBox_KeyPress;
            // 
            // DatumRodjDateTimePicker
            // 
            DatumRodjDateTimePicker.Format = DateTimePickerFormat.Short;
            DatumRodjDateTimePicker.Location = new Point(240, 240);
            DatumRodjDateTimePicker.Name = "DatumRodjDateTimePicker";
            DatumRodjDateTimePicker.Size = new Size(117, 27);
            DatumRodjDateTimePicker.TabIndex = 20;
            // 
            // PosaoTextBox
            // 
            PosaoTextBox.Location = new Point(240, 339);
            PosaoTextBox.Name = "PosaoTextBox";
            PosaoTextBox.Size = new Size(117, 27);
            PosaoTextBox.TabIndex = 21;
            PosaoTextBox.TextChanged += PosaoTextBox_TextChanged;
            PosaoTextBox.KeyPress += PosaoTextBox_KeyPress;
            // 
            // BrojTelTextBox
            // 
            BrojTelTextBox.Location = new Point(240, 372);
            BrojTelTextBox.Name = "BrojTelTextBox";
            BrojTelTextBox.Size = new Size(117, 27);
            BrojTelTextBox.TabIndex = 22;
            BrojTelTextBox.TextChanged += BrojTelTextBox_TextChanged;
            BrojTelTextBox.KeyPress += BrojTelTextBox_KeyPress;
            // 
            // DodajTelDugme
            // 
            DodajTelDugme.Location = new Point(12, 416);
            DodajTelDugme.Name = "DodajTelDugme";
            DodajTelDugme.Size = new Size(345, 29);
            DodajTelDugme.TabIndex = 23;
            DodajTelDugme.Text = "Dodaj broj telefona";
            DodajTelDugme.UseVisualStyleBackColor = true;
            DodajTelDugme.Click += DodajTelDugme_Click;
            // 
            // DodajZaposlenogDugme
            // 
            DodajZaposlenogDugme.Location = new Point(12, 596);
            DodajZaposlenogDugme.Name = "DodajZaposlenogDugme";
            DodajZaposlenogDugme.Size = new Size(148, 50);
            DodajZaposlenogDugme.TabIndex = 24;
            DodajZaposlenogDugme.Text = "Dodaj";
            DodajZaposlenogDugme.UseVisualStyleBackColor = true;
            DodajZaposlenogDugme.Click += DodajZaposlenogDugme_Click;
            // 
            // OdbaciDugme
            // 
            OdbaciDugme.Location = new Point(209, 596);
            OdbaciDugme.Name = "OdbaciDugme";
            OdbaciDugme.Size = new Size(148, 50);
            OdbaciDugme.TabIndex = 25;
            OdbaciDugme.Text = "Odbaci";
            OdbaciDugme.UseVisualStyleBackColor = true;
            OdbaciDugme.Click += OdbaciDugme_Click;
            // 
            // NoviZaposleni
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(373, 652);
            Controls.Add(OdbaciDugme);
            Controls.Add(DodajZaposlenogDugme);
            Controls.Add(DodajTelDugme);
            Controls.Add(BrojTelTextBox);
            Controls.Add(PosaoTextBox);
            Controls.Add(DatumRodjDateTimePicker);
            Controls.Add(MestoIzdLKTextBox);
            Controls.Add(BrojLKTextBox);
            Controls.Add(PrezimeTextBox);
            Controls.Add(ImeRodTextBox);
            Controls.Add(ImeTextBox);
            Controls.Add(AdresaTextBox);
            Controls.Add(BrojeviListView);
            Controls.Add(JMBGTextBox);
            Controls.Add(PosaoLabel);
            Controls.Add(BrojLKLabel);
            Controls.Add(MestoIzdLKLabel);
            Controls.Add(DatumRodjenjaLabel);
            Controls.Add(BrojTelefonaLabel);
            Controls.Add(PrezimeLabel);
            Controls.Add(ImeRodLabel);
            Controls.Add(ImeLabel);
            Controls.Add(AdresaLabel);
            Controls.Add(JMBGLabel);
            Controls.Add(NoviZaposleniLabel);
            Name = "NoviZaposleni";
            Text = "NoviZaposleni";
            Load += NoviZaposleni_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label NoviZaposleniLabel;
        private Label JMBGLabel;
        private Label AdresaLabel;
        private Label ImeLabel;
        private Label ImeRodLabel;
        private Label PrezimeLabel;
        private Label BrojTelefonaLabel;
        private Label DatumRodjenjaLabel;
        private Label MestoIzdLKLabel;
        private Label BrojLKLabel;
        private Label PosaoLabel;
        private TextBox JMBGTextBox;
        private ListView BrojeviListView;
        private TextBox AdresaTextBox;
        private TextBox ImeTextBox;
        private TextBox ImeRodTextBox;
        private TextBox PrezimeTextBox;
        private TextBox BrojLKTextBox;
        private TextBox MestoIzdLKTextBox;
        private DateTimePicker DatumRodjDateTimePicker;
        private TextBox PosaoTextBox;
        private TextBox BrojTelTextBox;
        private Button DodajTelDugme;
        private Button DodajZaposlenogDugme;
        private Button OdbaciDugme;
    }
}