namespace Projekat2SBP.Forme
{
    partial class NoviUgovor
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
            DatumPotpisivanjaLabel = new Label();
            PeriodVazenjaLabel = new Label();
            DatumPotpisivanjaDateTimePicker = new DateTimePicker();
            PeriodVazenjaUpDown = new NumericUpDown();
            DodajDugme = new Button();
            OtkaziDugme = new Button();
            ((System.ComponentModel.ISupportInitialize)PeriodVazenjaUpDown).BeginInit();
            SuspendLayout();
            // 
            // DatumPotpisivanjaLabel
            // 
            DatumPotpisivanjaLabel.AutoSize = true;
            DatumPotpisivanjaLabel.Location = new Point(39, 34);
            DatumPotpisivanjaLabel.Name = "DatumPotpisivanjaLabel";
            DatumPotpisivanjaLabel.Size = new Size(142, 20);
            DatumPotpisivanjaLabel.TabIndex = 0;
            DatumPotpisivanjaLabel.Text = "Datum potpisivanja:\r\n";
            // 
            // PeriodVazenjaLabel
            // 
            PeriodVazenjaLabel.AutoSize = true;
            PeriodVazenjaLabel.Location = new Point(39, 83);
            PeriodVazenjaLabel.Name = "PeriodVazenjaLabel";
            PeriodVazenjaLabel.Size = new Size(101, 20);
            PeriodVazenjaLabel.TabIndex = 1;
            PeriodVazenjaLabel.Text = "Priod važenja:";
            // 
            // DatumPotpisivanjaDateTimePicker
            // 
            DatumPotpisivanjaDateTimePicker.Format = DateTimePickerFormat.Short;
            DatumPotpisivanjaDateTimePicker.Location = new Point(239, 27);
            DatumPotpisivanjaDateTimePicker.Name = "DatumPotpisivanjaDateTimePicker";
            DatumPotpisivanjaDateTimePicker.Size = new Size(129, 27);
            DatumPotpisivanjaDateTimePicker.TabIndex = 2;
            // 
            // PeriodVazenjaUpDown
            // 
            PeriodVazenjaUpDown.Location = new Point(239, 76);
            PeriodVazenjaUpDown.Maximum = new decimal(new int[] { 3, 0, 0, 0 });
            PeriodVazenjaUpDown.Name = "PeriodVazenjaUpDown";
            PeriodVazenjaUpDown.Size = new Size(129, 27);
            PeriodVazenjaUpDown.TabIndex = 3;
            // 
            // DodajDugme
            // 
            DodajDugme.Location = new Point(39, 132);
            DodajDugme.Name = "DodajDugme";
            DodajDugme.Size = new Size(142, 49);
            DodajDugme.TabIndex = 4;
            DodajDugme.Text = "Dodaj";
            DodajDugme.UseVisualStyleBackColor = true;
            DodajDugme.Click += DodajDugme_Click;
            // 
            // OtkaziDugme
            // 
            OtkaziDugme.Location = new Point(226, 132);
            OtkaziDugme.Name = "OtkaziDugme";
            OtkaziDugme.Size = new Size(142, 49);
            OtkaziDugme.TabIndex = 5;
            OtkaziDugme.Text = "Otkaži";
            OtkaziDugme.UseVisualStyleBackColor = true;
            OtkaziDugme.Click += OtkaziDugme_Click;
            // 
            // NoviUgovor
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(422, 212);
            Controls.Add(OtkaziDugme);
            Controls.Add(DodajDugme);
            Controls.Add(PeriodVazenjaUpDown);
            Controls.Add(DatumPotpisivanjaDateTimePicker);
            Controls.Add(PeriodVazenjaLabel);
            Controls.Add(DatumPotpisivanjaLabel);
            Name = "NoviUgovor";
            Text = "NoviUgovor";
            ((System.ComponentModel.ISupportInitialize)PeriodVazenjaUpDown).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label DatumPotpisivanjaLabel;
        private Label PeriodVazenjaLabel;
        private DateTimePicker DatumPotpisivanjaDateTimePicker;
        private NumericUpDown PeriodVazenjaUpDown;
        private Button DodajDugme;
        private Button OtkaziDugme;
    }
}