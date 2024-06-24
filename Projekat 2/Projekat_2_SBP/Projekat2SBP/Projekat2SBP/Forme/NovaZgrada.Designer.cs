namespace Projekat2SBP.Forme
{
    partial class NovaZgrada
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
            AdresaLabel = new Label();
            AdresaTextBox = new TextBox();
            SacuvajDugme = new Button();
            OtkaziDugme = new Button();
            SuspendLayout();
            // 
            // AdresaLabel
            // 
            AdresaLabel.AutoSize = true;
            AdresaLabel.Location = new Point(28, 47);
            AdresaLabel.Name = "AdresaLabel";
            AdresaLabel.Size = new Size(58, 20);
            AdresaLabel.TabIndex = 0;
            AdresaLabel.Text = "Adresa:";
            // 
            // AdresaTextBox
            // 
            AdresaTextBox.Location = new Point(163, 40);
            AdresaTextBox.Name = "AdresaTextBox";
            AdresaTextBox.Size = new Size(125, 27);
            AdresaTextBox.TabIndex = 1;
            // 
            // SacuvajDugme
            // 
            SacuvajDugme.Location = new Point(28, 93);
            SacuvajDugme.Name = "SacuvajDugme";
            SacuvajDugme.Size = new Size(99, 29);
            SacuvajDugme.TabIndex = 2;
            SacuvajDugme.Text = "Sačuvaj";
            SacuvajDugme.UseVisualStyleBackColor = true;
            SacuvajDugme.Click += SacuvajDugme_Click;
            // 
            // OtkaziDugme
            // 
            OtkaziDugme.Location = new Point(189, 93);
            OtkaziDugme.Name = "OtkaziDugme";
            OtkaziDugme.Size = new Size(99, 29);
            OtkaziDugme.TabIndex = 3;
            OtkaziDugme.Text = "Otkaži";
            OtkaziDugme.UseVisualStyleBackColor = true;
            OtkaziDugme.Click += OtkaziDugme_Click;
            // 
            // NovaZgrada
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(311, 134);
            Controls.Add(OtkaziDugme);
            Controls.Add(SacuvajDugme);
            Controls.Add(AdresaTextBox);
            Controls.Add(AdresaLabel);
            Name = "NovaZgrada";
            Text = "NovaZgrada";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label AdresaLabel;
        private TextBox AdresaTextBox;
        private Button SacuvajDugme;
        private Button OtkaziDugme;
    }
}