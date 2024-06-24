namespace Projekat2SBP.Forme
{
    partial class NovoObrazovanje
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
            ZvanjeLabel = new Label();
            DatumSticanjaLabel = new Label();
            NazivInstitucijeLabel = new Label();
            ZvanjeTextBox = new TextBox();
            NazivInstitucijeTextBox = new TextBox();
            DatumSticanjaDateTimePicker = new DateTimePicker();
            DodajObrazovanjeDugme = new Button();
            OtkaziDugme = new Button();
            SuspendLayout();
            // 
            // ZvanjeLabel
            // 
            ZvanjeLabel.AutoSize = true;
            ZvanjeLabel.Location = new Point(30, 32);
            ZvanjeLabel.Name = "ZvanjeLabel";
            ZvanjeLabel.Size = new Size(56, 20);
            ZvanjeLabel.TabIndex = 0;
            ZvanjeLabel.Text = "Zvanje:";
            // 
            // DatumSticanjaLabel
            // 
            DatumSticanjaLabel.AutoSize = true;
            DatumSticanjaLabel.Location = new Point(30, 65);
            DatumSticanjaLabel.Name = "DatumSticanjaLabel";
            DatumSticanjaLabel.Size = new Size(111, 20);
            DatumSticanjaLabel.TabIndex = 1;
            DatumSticanjaLabel.Text = "Datum sticanja:";
            // 
            // NazivInstitucijeLabel
            // 
            NazivInstitucijeLabel.AutoSize = true;
            NazivInstitucijeLabel.Location = new Point(30, 98);
            NazivInstitucijeLabel.Name = "NazivInstitucijeLabel";
            NazivInstitucijeLabel.Size = new Size(116, 20);
            NazivInstitucijeLabel.TabIndex = 2;
            NazivInstitucijeLabel.Text = "Naziv institucije:";
            // 
            // ZvanjeTextBox
            // 
            ZvanjeTextBox.Location = new Point(212, 25);
            ZvanjeTextBox.Name = "ZvanjeTextBox";
            ZvanjeTextBox.Size = new Size(125, 27);
            ZvanjeTextBox.TabIndex = 3;
            ZvanjeTextBox.KeyPress += ZvanjeTextBox_KeyPress;
            // 
            // NazivInstitucijeTextBox
            // 
            NazivInstitucijeTextBox.Location = new Point(212, 91);
            NazivInstitucijeTextBox.Name = "NazivInstitucijeTextBox";
            NazivInstitucijeTextBox.Size = new Size(125, 27);
            NazivInstitucijeTextBox.TabIndex = 4;
            NazivInstitucijeTextBox.KeyPress += NazivInstitucijeTextBox_KeyPress;
            // 
            // DatumSticanjaDateTimePicker
            // 
            DatumSticanjaDateTimePicker.Format = DateTimePickerFormat.Short;
            DatumSticanjaDateTimePicker.Location = new Point(212, 58);
            DatumSticanjaDateTimePicker.Name = "DatumSticanjaDateTimePicker";
            DatumSticanjaDateTimePicker.Size = new Size(125, 27);
            DatumSticanjaDateTimePicker.TabIndex = 5;
            // 
            // DodajObrazovanjeDugme
            // 
            DodajObrazovanjeDugme.Location = new Point(30, 138);
            DodajObrazovanjeDugme.Name = "DodajObrazovanjeDugme";
            DodajObrazovanjeDugme.Size = new Size(94, 57);
            DodajObrazovanjeDugme.TabIndex = 6;
            DodajObrazovanjeDugme.Text = "Dodaj";
            DodajObrazovanjeDugme.UseVisualStyleBackColor = true;
            DodajObrazovanjeDugme.Click += DodajObrazovanjeDugme_Click;
            // 
            // OtkaziDugme
            // 
            OtkaziDugme.Location = new Point(243, 138);
            OtkaziDugme.Name = "OtkaziDugme";
            OtkaziDugme.Size = new Size(94, 57);
            OtkaziDugme.TabIndex = 7;
            OtkaziDugme.Text = "Otkaži";
            OtkaziDugme.UseVisualStyleBackColor = true;
            OtkaziDugme.Click += OtkaziDugme_Click;
            // 
            // NovoObrazovanje
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(362, 207);
            Controls.Add(OtkaziDugme);
            Controls.Add(DodajObrazovanjeDugme);
            Controls.Add(DatumSticanjaDateTimePicker);
            Controls.Add(NazivInstitucijeTextBox);
            Controls.Add(ZvanjeTextBox);
            Controls.Add(NazivInstitucijeLabel);
            Controls.Add(DatumSticanjaLabel);
            Controls.Add(ZvanjeLabel);
            Name = "NovoObrazovanje";
            Text = "NovoObrazovanje";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label ZvanjeLabel;
        private Label DatumSticanjaLabel;
        private Label NazivInstitucijeLabel;
        private TextBox ZvanjeTextBox;
        private TextBox NazivInstitucijeTextBox;
        private DateTimePicker DatumSticanjaDateTimePicker;
        private Button DodajObrazovanjeDugme;
        private Button OtkaziDugme;
    }
}