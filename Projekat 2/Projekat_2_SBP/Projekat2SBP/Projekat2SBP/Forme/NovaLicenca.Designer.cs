namespace Projekat2SBP.Forme
{
    partial class NovaLicenca
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
            DodajLicencuDugme = new Button();
            OtkaziDugme = new Button();
            BrojLicenceLabel = new Label();
            IzdavacLabel = new Label();
            DatumSticanjaLabel = new Label();
            DatumSticanjDateTimePicker = new DateTimePicker();
            BrojLicenceTextBox = new TextBox();
            IzdavacTextBox = new TextBox();
            SuspendLayout();
            // 
            // DodajLicencuDugme
            // 
            DodajLicencuDugme.Location = new Point(25, 145);
            DodajLicencuDugme.Name = "DodajLicencuDugme";
            DodajLicencuDugme.Size = new Size(94, 57);
            DodajLicencuDugme.TabIndex = 7;
            DodajLicencuDugme.Text = "Dodaj";
            DodajLicencuDugme.UseVisualStyleBackColor = true;
            DodajLicencuDugme.Click += DodajLicencuDugme_Click;
            // 
            // OtkaziDugme
            // 
            OtkaziDugme.Location = new Point(237, 145);
            OtkaziDugme.Name = "OtkaziDugme";
            OtkaziDugme.Size = new Size(94, 57);
            OtkaziDugme.TabIndex = 8;
            OtkaziDugme.Text = "Otkaži";
            OtkaziDugme.UseVisualStyleBackColor = true;
            OtkaziDugme.Click += OtkaziDugme_Click;
            // 
            // BrojLicenceLabel
            // 
            BrojLicenceLabel.AutoSize = true;
            BrojLicenceLabel.Location = new Point(30, 36);
            BrojLicenceLabel.Name = "BrojLicenceLabel";
            BrojLicenceLabel.Size = new Size(89, 20);
            BrojLicenceLabel.TabIndex = 9;
            BrojLicenceLabel.Text = "Broj licence:";
            // 
            // IzdavacLabel
            // 
            IzdavacLabel.AutoSize = true;
            IzdavacLabel.Location = new Point(30, 69);
            IzdavacLabel.Name = "IzdavacLabel";
            IzdavacLabel.Size = new Size(62, 20);
            IzdavacLabel.TabIndex = 10;
            IzdavacLabel.Text = "Izdavač:";
            // 
            // DatumSticanjaLabel
            // 
            DatumSticanjaLabel.AutoSize = true;
            DatumSticanjaLabel.Location = new Point(30, 102);
            DatumSticanjaLabel.Name = "DatumSticanjaLabel";
            DatumSticanjaLabel.Size = new Size(111, 20);
            DatumSticanjaLabel.TabIndex = 11;
            DatumSticanjaLabel.Text = "Datum sticanja:";
            // 
            // DatumSticanjDateTimePicker
            // 
            DatumSticanjDateTimePicker.Format = DateTimePickerFormat.Short;
            DatumSticanjDateTimePicker.Location = new Point(206, 95);
            DatumSticanjDateTimePicker.Name = "DatumSticanjDateTimePicker";
            DatumSticanjDateTimePicker.Size = new Size(125, 27);
            DatumSticanjDateTimePicker.TabIndex = 12;
            // 
            // BrojLicenceTextBox
            // 
            BrojLicenceTextBox.Location = new Point(206, 29);
            BrojLicenceTextBox.Name = "BrojLicenceTextBox";
            BrojLicenceTextBox.Size = new Size(125, 27);
            BrojLicenceTextBox.TabIndex = 13;
            BrojLicenceTextBox.KeyPress += BrojLicenceTextBox_KeyPress;
            // 
            // IzdavacTextBox
            // 
            IzdavacTextBox.Location = new Point(206, 62);
            IzdavacTextBox.Name = "IzdavacTextBox";
            IzdavacTextBox.Size = new Size(125, 27);
            IzdavacTextBox.TabIndex = 14;
            IzdavacTextBox.KeyPress += IzdavacTextBox_KeyPress;
            // 
            // NovaLicenca
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(362, 217);
            Controls.Add(IzdavacTextBox);
            Controls.Add(BrojLicenceTextBox);
            Controls.Add(DatumSticanjDateTimePicker);
            Controls.Add(DatumSticanjaLabel);
            Controls.Add(IzdavacLabel);
            Controls.Add(BrojLicenceLabel);
            Controls.Add(OtkaziDugme);
            Controls.Add(DodajLicencuDugme);
            Name = "NovaLicenca";
            Text = "NovaLicenca";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button DodajLicencuDugme;
        private Button OtkaziDugme;
        private Label BrojLicenceLabel;
        private Label IzdavacLabel;
        private Label DatumSticanjaLabel;
        private DateTimePicker DatumSticanjDateTimePicker;
        private TextBox BrojLicenceTextBox;
        private TextBox IzdavacTextBox;
    }
}