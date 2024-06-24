namespace Projekat2SBP.Forme
{
    partial class NoviProstor
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
            JMBGVlasnikaLabel = new Label();
            StanariLabel = new Label();
            PrikaziStanareDugme = new Button();
            DodajDugme = new Button();
            OtkaziDugme = new Button();
            SpratLabel = new Label();
            JMBGVlasnikaTextBox = new TextBox();
            SpratUpDown = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)SpratUpDown).BeginInit();
            SuspendLayout();
            // 
            // JMBGVlasnikaLabel
            // 
            JMBGVlasnikaLabel.AutoSize = true;
            JMBGVlasnikaLabel.Location = new Point(42, 62);
            JMBGVlasnikaLabel.Name = "JMBGVlasnikaLabel";
            JMBGVlasnikaLabel.Size = new Size(107, 20);
            JMBGVlasnikaLabel.TabIndex = 0;
            JMBGVlasnikaLabel.Text = "JMBG Vlasnika:";
            // 
            // StanariLabel
            // 
            StanariLabel.AutoSize = true;
            StanariLabel.Location = new Point(42, 95);
            StanariLabel.Name = "StanariLabel";
            StanariLabel.Size = new Size(58, 20);
            StanariLabel.TabIndex = 2;
            StanariLabel.Text = "Stanari:";
            StanariLabel.Visible = false;
            // 
            // PrikaziStanareDugme
            // 
            PrikaziStanareDugme.Location = new Point(228, 88);
            PrikaziStanareDugme.Name = "PrikaziStanareDugme";
            PrikaziStanareDugme.Size = new Size(125, 27);
            PrikaziStanareDugme.TabIndex = 4;
            PrikaziStanareDugme.Text = "Prikaži";
            PrikaziStanareDugme.UseVisualStyleBackColor = true;
            PrikaziStanareDugme.Visible = false;
            PrikaziStanareDugme.Click += PrikaziStanareDugme_Click;
            // 
            // DodajDugme
            // 
            DodajDugme.Location = new Point(42, 136);
            DodajDugme.Name = "DodajDugme";
            DodajDugme.Size = new Size(125, 46);
            DodajDugme.TabIndex = 5;
            DodajDugme.Text = "Dodaj";
            DodajDugme.UseVisualStyleBackColor = true;
            DodajDugme.Click += DodajDugme_Click;
            // 
            // OtkaziDugme
            // 
            OtkaziDugme.Location = new Point(228, 136);
            OtkaziDugme.Name = "OtkaziDugme";
            OtkaziDugme.Size = new Size(125, 46);
            OtkaziDugme.TabIndex = 6;
            OtkaziDugme.Text = "Otkaži";
            OtkaziDugme.UseVisualStyleBackColor = true;
            OtkaziDugme.Click += OtkaziDugme_Click;
            // 
            // SpratLabel
            // 
            SpratLabel.AutoSize = true;
            SpratLabel.Location = new Point(42, 29);
            SpratLabel.Name = "SpratLabel";
            SpratLabel.Size = new Size(47, 20);
            SpratLabel.TabIndex = 7;
            SpratLabel.Text = "Sprat:";
            // 
            // JMBGVlasnikaTextBox
            // 
            JMBGVlasnikaTextBox.Location = new Point(228, 55);
            JMBGVlasnikaTextBox.Name = "JMBGVlasnikaTextBox";
            JMBGVlasnikaTextBox.Size = new Size(125, 27);
            JMBGVlasnikaTextBox.TabIndex = 1;
            JMBGVlasnikaTextBox.KeyPress += JMBGVlasnikaTextBox_KeyPress;
            // 
            // SpratUpDown
            // 
            SpratUpDown.Location = new Point(228, 22);
            SpratUpDown.Name = "SpratUpDown";
            SpratUpDown.Size = new Size(125, 27);
            SpratUpDown.TabIndex = 8;
            // 
            // NoviProstor
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(395, 207);
            Controls.Add(SpratUpDown);
            Controls.Add(SpratLabel);
            Controls.Add(OtkaziDugme);
            Controls.Add(DodajDugme);
            Controls.Add(PrikaziStanareDugme);
            Controls.Add(StanariLabel);
            Controls.Add(JMBGVlasnikaTextBox);
            Controls.Add(JMBGVlasnikaLabel);
            Name = "NoviProstor";
            Text = "NoviProstor";
            ((System.ComponentModel.ISupportInitialize)SpratUpDown).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label JMBGVlasnikaLabel;
        private Label StanariLabel;
        private Button PrikaziStanareDugme;
        private Button DodajDugme;
        private Button OtkaziDugme;
        private Label SpratLabel;
        private TextBox JMBGVlasnikaTextBox;
        private NumericUpDown SpratUpDown;
    }
}