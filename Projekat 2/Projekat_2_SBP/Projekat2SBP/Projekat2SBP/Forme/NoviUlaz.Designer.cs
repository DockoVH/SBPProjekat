namespace Projekat2SBP.Forme
{
    partial class NoviUlaz
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
            KameraLabel = new Label();
            PocetakRadnogVremenaLabel = new Label();
            KrajRadnogVremenaLabel = new Label();
            ImaRadioButton = new RadioButton();
            NemaRadioButton = new RadioButton();
            PocetakRadnogVremenaTimePicker = new DateTimePicker();
            KrajRadnogVremenaTimePicker = new DateTimePicker();
            DodajDugme = new Button();
            OtkaziDugme = new Button();
            SuspendLayout();
            // 
            // KameraLabel
            // 
            KameraLabel.AutoSize = true;
            KameraLabel.Location = new Point(41, 36);
            KameraLabel.Name = "KameraLabel";
            KameraLabel.Size = new Size(63, 20);
            KameraLabel.TabIndex = 0;
            KameraLabel.Text = "Kamera:";
            // 
            // PocetakRadnogVremenaLabel
            // 
            PocetakRadnogVremenaLabel.AutoSize = true;
            PocetakRadnogVremenaLabel.Location = new Point(41, 86);
            PocetakRadnogVremenaLabel.Name = "PocetakRadnogVremenaLabel";
            PocetakRadnogVremenaLabel.Size = new Size(176, 20);
            PocetakRadnogVremenaLabel.TabIndex = 1;
            PocetakRadnogVremenaLabel.Text = "Početak radnog vremena:";
            // 
            // KrajRadnogVremenaLabel
            // 
            KrajRadnogVremenaLabel.AutoSize = true;
            KrajRadnogVremenaLabel.Location = new Point(41, 136);
            KrajRadnogVremenaLabel.Name = "KrajRadnogVremenaLabel";
            KrajRadnogVremenaLabel.Size = new Size(151, 20);
            KrajRadnogVremenaLabel.TabIndex = 2;
            KrajRadnogVremenaLabel.Text = "Kraj radnog vremena:";
            // 
            // ImaRadioButton
            // 
            ImaRadioButton.AutoSize = true;
            ImaRadioButton.Location = new Point(278, 32);
            ImaRadioButton.Name = "ImaRadioButton";
            ImaRadioButton.Size = new Size(49, 24);
            ImaRadioButton.TabIndex = 3;
            ImaRadioButton.TabStop = true;
            ImaRadioButton.Text = "Da";
            ImaRadioButton.UseVisualStyleBackColor = true;
            ImaRadioButton.CheckedChanged += ImaRadioButton_CheckedChanged;
            // 
            // NemaRadioButton
            // 
            NemaRadioButton.AutoSize = true;
            NemaRadioButton.Location = new Point(383, 32);
            NemaRadioButton.Name = "NemaRadioButton";
            NemaRadioButton.Size = new Size(49, 24);
            NemaRadioButton.TabIndex = 4;
            NemaRadioButton.TabStop = true;
            NemaRadioButton.Text = "Ne";
            NemaRadioButton.UseVisualStyleBackColor = true;
            NemaRadioButton.CheckedChanged += NemaRadioButton_CheckedChanged;
            // 
            // PocetakRadnogVremenaTimePicker
            // 
            PocetakRadnogVremenaTimePicker.Format = DateTimePickerFormat.Time;
            PocetakRadnogVremenaTimePicker.Location = new Point(278, 79);
            PocetakRadnogVremenaTimePicker.Name = "PocetakRadnogVremenaTimePicker";
            PocetakRadnogVremenaTimePicker.Size = new Size(154, 27);
            PocetakRadnogVremenaTimePicker.TabIndex = 5;
            // 
            // KrajRadnogVremenaTimePicker
            // 
            KrajRadnogVremenaTimePicker.Format = DateTimePickerFormat.Time;
            KrajRadnogVremenaTimePicker.Location = new Point(278, 129);
            KrajRadnogVremenaTimePicker.Name = "KrajRadnogVremenaTimePicker";
            KrajRadnogVremenaTimePicker.Size = new Size(154, 27);
            KrajRadnogVremenaTimePicker.TabIndex = 6;
            // 
            // DodajDugme
            // 
            DodajDugme.Location = new Point(41, 182);
            DodajDugme.Name = "DodajDugme";
            DodajDugme.Size = new Size(176, 43);
            DodajDugme.TabIndex = 7;
            DodajDugme.Text = "Dodaj";
            DodajDugme.UseVisualStyleBackColor = true;
            DodajDugme.Click += DodajDugme_Click;
            // 
            // OtkaziDugme
            // 
            OtkaziDugme.Location = new Point(256, 182);
            OtkaziDugme.Name = "OtkaziDugme";
            OtkaziDugme.Size = new Size(176, 43);
            OtkaziDugme.TabIndex = 8;
            OtkaziDugme.Text = "Otkaži";
            OtkaziDugme.UseVisualStyleBackColor = true;
            OtkaziDugme.Click += OtkaziDugme_Click;
            // 
            // NoviUlaz
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(473, 253);
            Controls.Add(OtkaziDugme);
            Controls.Add(DodajDugme);
            Controls.Add(KrajRadnogVremenaTimePicker);
            Controls.Add(PocetakRadnogVremenaTimePicker);
            Controls.Add(NemaRadioButton);
            Controls.Add(ImaRadioButton);
            Controls.Add(KrajRadnogVremenaLabel);
            Controls.Add(PocetakRadnogVremenaLabel);
            Controls.Add(KameraLabel);
            Name = "NoviUlaz";
            Text = "NoviUlaz";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label KameraLabel;
        private Label PocetakRadnogVremenaLabel;
        private Label KrajRadnogVremenaLabel;
        private RadioButton ImaRadioButton;
        private RadioButton NemaRadioButton;
        private DateTimePicker PocetakRadnogVremenaTimePicker;
        private DateTimePicker KrajRadnogVremenaTimePicker;
        private Button DodajDugme;
        private Button OtkaziDugme;
    }
}