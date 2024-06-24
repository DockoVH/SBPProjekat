namespace Projekat2SBP.Forme
{
    partial class NoviLift
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
            DatumServisaLabel = new Label();
            DatumKvaraLabel = new Label();
            VanUpotrebeLabel = new Label();
            ProizvodjacLabel = new Label();
            NosivostLabel = new Label();
            DodajDugme = new Button();
            OtkaziDugme = new Button();
            DatumServisaDateTimePicker = new DateTimePicker();
            DatumKvaraDateTimePicker = new DateTimePicker();
            VanUpotrebeNumericUpDown = new NumericUpDown();
            ProizvodjacTextBox = new TextBox();
            NosivostTextBox = new TextBox();
            ((System.ComponentModel.ISupportInitialize)VanUpotrebeNumericUpDown).BeginInit();
            SuspendLayout();
            // 
            // DatumServisaLabel
            // 
            DatumServisaLabel.AutoSize = true;
            DatumServisaLabel.Location = new Point(52, 45);
            DatumServisaLabel.Name = "DatumServisaLabel";
            DatumServisaLabel.Size = new Size(183, 20);
            DatumServisaLabel.TabIndex = 0;
            DatumServisaLabel.Text = "Datum poslednjeg servisa:";
            // 
            // DatumKvaraLabel
            // 
            DatumKvaraLabel.AutoSize = true;
            DatumKvaraLabel.Location = new Point(52, 78);
            DatumKvaraLabel.Name = "DatumKvaraLabel";
            DatumKvaraLabel.Size = new Size(174, 20);
            DatumKvaraLabel.TabIndex = 1;
            DatumKvaraLabel.Text = "Datum poslednjeg kvara:";
            // 
            // VanUpotrebeLabel
            // 
            VanUpotrebeLabel.AutoSize = true;
            VanUpotrebeLabel.Location = new Point(52, 111);
            VanUpotrebeLabel.Name = "VanUpotrebeLabel";
            VanUpotrebeLabel.Size = new Size(155, 20);
            VanUpotrebeLabel.TabIndex = 2;
            VanUpotrebeLabel.Text = "Ukupno van upotrebe:";
            // 
            // ProizvodjacLabel
            // 
            ProizvodjacLabel.AutoSize = true;
            ProizvodjacLabel.Location = new Point(52, 144);
            ProizvodjacLabel.Name = "ProizvodjacLabel";
            ProizvodjacLabel.Size = new Size(89, 20);
            ProizvodjacLabel.TabIndex = 3;
            ProizvodjacLabel.Text = "Proizvodjač:";
            // 
            // NosivostLabel
            // 
            NosivostLabel.AutoSize = true;
            NosivostLabel.Location = new Point(52, 177);
            NosivostLabel.Name = "NosivostLabel";
            NosivostLabel.Size = new Size(69, 20);
            NosivostLabel.TabIndex = 4;
            NosivostLabel.Text = "Nosivost:";
            // 
            // DodajDugme
            // 
            DodajDugme.Location = new Point(52, 212);
            DodajDugme.Name = "DodajDugme";
            DodajDugme.Size = new Size(174, 51);
            DodajDugme.TabIndex = 5;
            DodajDugme.Text = "Dodaj";
            DodajDugme.UseVisualStyleBackColor = true;
            DodajDugme.Click += DodajDugme_Click;
            // 
            // OtkaziDugme
            // 
            OtkaziDugme.Location = new Point(265, 212);
            OtkaziDugme.Name = "OtkaziDugme";
            OtkaziDugme.Size = new Size(174, 51);
            OtkaziDugme.TabIndex = 6;
            OtkaziDugme.Text = "Otkaži";
            OtkaziDugme.UseVisualStyleBackColor = true;
            OtkaziDugme.Click += OtkaziDugme_Click;
            // 
            // DatumServisaDateTimePicker
            // 
            DatumServisaDateTimePicker.Format = DateTimePickerFormat.Short;
            DatumServisaDateTimePicker.Location = new Point(314, 38);
            DatumServisaDateTimePicker.Name = "DatumServisaDateTimePicker";
            DatumServisaDateTimePicker.Size = new Size(125, 27);
            DatumServisaDateTimePicker.TabIndex = 7;
            // 
            // DatumKvaraDateTimePicker
            // 
            DatumKvaraDateTimePicker.Format = DateTimePickerFormat.Short;
            DatumKvaraDateTimePicker.Location = new Point(314, 71);
            DatumKvaraDateTimePicker.Name = "DatumKvaraDateTimePicker";
            DatumKvaraDateTimePicker.Size = new Size(125, 27);
            DatumKvaraDateTimePicker.TabIndex = 8;
            // 
            // VanUpotrebeNumericUpDown
            // 
            VanUpotrebeNumericUpDown.Location = new Point(314, 104);
            VanUpotrebeNumericUpDown.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            VanUpotrebeNumericUpDown.Name = "VanUpotrebeNumericUpDown";
            VanUpotrebeNumericUpDown.Size = new Size(125, 27);
            VanUpotrebeNumericUpDown.TabIndex = 9;
            // 
            // ProizvodjacTextBox
            // 
            ProizvodjacTextBox.Location = new Point(314, 137);
            ProizvodjacTextBox.Name = "ProizvodjacTextBox";
            ProizvodjacTextBox.Size = new Size(125, 27);
            ProizvodjacTextBox.TabIndex = 10;
            ProizvodjacTextBox.KeyPress += ProizvodjacTextBox_KeyPress;
            // 
            // NosivostTextBox
            // 
            NosivostTextBox.Location = new Point(314, 170);
            NosivostTextBox.Name = "NosivostTextBox";
            NosivostTextBox.Size = new Size(125, 27);
            NosivostTextBox.TabIndex = 11;
            NosivostTextBox.KeyPress += NosivostTextBox_KeyPress;
            // 
            // NoviLift
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(509, 278);
            Controls.Add(NosivostTextBox);
            Controls.Add(ProizvodjacTextBox);
            Controls.Add(VanUpotrebeNumericUpDown);
            Controls.Add(DatumKvaraDateTimePicker);
            Controls.Add(DatumServisaDateTimePicker);
            Controls.Add(OtkaziDugme);
            Controls.Add(DodajDugme);
            Controls.Add(NosivostLabel);
            Controls.Add(ProizvodjacLabel);
            Controls.Add(VanUpotrebeLabel);
            Controls.Add(DatumKvaraLabel);
            Controls.Add(DatumServisaLabel);
            Name = "NoviLift";
            Text = "NoviLift";
            ((System.ComponentModel.ISupportInitialize)VanUpotrebeNumericUpDown).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label DatumServisaLabel;
        private Label DatumKvaraLabel;
        private Label VanUpotrebeLabel;
        private Label ProizvodjacLabel;
        private Label NosivostLabel;
        private Button DodajDugme;
        private Button OtkaziDugme;
        private DateTimePicker DatumServisaDateTimePicker;
        private DateTimePicker DatumKvaraDateTimePicker;
        private NumericUpDown VanUpotrebeNumericUpDown;
        private TextBox ProizvodjacTextBox;
        private TextBox NosivostTextBox;
    }
}