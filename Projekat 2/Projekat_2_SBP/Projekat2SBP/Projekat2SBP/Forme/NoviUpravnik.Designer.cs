namespace Projekat2SBP.Forme
{
    partial class NoviUpravnik
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
            UpravnikComboBox = new ComboBox();
            UpravnikLabel = new Label();
            DodajDugme = new Button();
            OtkaziDugme = new Button();
            SuspendLayout();
            // 
            // UpravnikComboBox
            // 
            UpravnikComboBox.FormattingEnabled = true;
            UpravnikComboBox.Location = new Point(253, 56);
            UpravnikComboBox.Name = "UpravnikComboBox";
            UpravnikComboBox.Size = new Size(151, 28);
            UpravnikComboBox.TabIndex = 0;
            // 
            // UpravnikLabel
            // 
            UpravnikLabel.AutoSize = true;
            UpravnikLabel.Location = new Point(55, 64);
            UpravnikLabel.Name = "UpravnikLabel";
            UpravnikLabel.Size = new Size(138, 20);
            UpravnikLabel.TabIndex = 1;
            UpravnikLabel.Text = "Izaberite upravnika:";
            // 
            // DodajDugme
            // 
            DodajDugme.Location = new Point(55, 121);
            DodajDugme.Name = "DodajDugme";
            DodajDugme.Size = new Size(138, 40);
            DodajDugme.TabIndex = 2;
            DodajDugme.Text = "Dodaj";
            DodajDugme.UseVisualStyleBackColor = true;
            DodajDugme.Click += DodajDugme_Click;
            // 
            // OtkaziDugme
            // 
            OtkaziDugme.Location = new Point(266, 121);
            OtkaziDugme.Name = "OtkaziDugme";
            OtkaziDugme.Size = new Size(138, 40);
            OtkaziDugme.TabIndex = 3;
            OtkaziDugme.Text = "Otkaži";
            OtkaziDugme.UseVisualStyleBackColor = true;
            OtkaziDugme.Click += OtkaziDugme_Click;
            // 
            // NoviUpravnik
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(459, 195);
            Controls.Add(OtkaziDugme);
            Controls.Add(DodajDugme);
            Controls.Add(UpravnikLabel);
            Controls.Add(UpravnikComboBox);
            Name = "NoviUpravnik";
            Text = "NoviUpravnik";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox UpravnikComboBox;
        private Label UpravnikLabel;
        private Button DodajDugme;
        private Button OtkaziDugme;
    }
}