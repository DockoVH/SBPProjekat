namespace Projekat2SBP.Forme
{
    partial class StanariForma
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
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            StanariListBox = new ListBox();
            DodajStanaraDugme = new Button();
            IzbrisiStanaraDugme = new Button();
            ImeTextBox = new TextBox();
            SuspendLayout();
            // 
            // StanariListBox
            // 
            StanariListBox.FormattingEnabled = true;
            StanariListBox.Location = new Point(12, 12);
            StanariListBox.Name = "StanariListBox";
            StanariListBox.Size = new Size(311, 164);
            StanariListBox.TabIndex = 0;
            // 
            // DodajStanaraDugme
            // 
            DodajStanaraDugme.Location = new Point(329, 12);
            DodajStanaraDugme.Name = "DodajStanaraDugme";
            DodajStanaraDugme.Size = new Size(157, 39);
            DodajStanaraDugme.TabIndex = 1;
            DodajStanaraDugme.Text = "Dodaj stanara";
            DodajStanaraDugme.UseVisualStyleBackColor = true;
            DodajStanaraDugme.Click += DodajStanaraDugme_Click;
            // 
            // IzbrisiStanaraDugme
            // 
            IzbrisiStanaraDugme.Location = new Point(329, 137);
            IzbrisiStanaraDugme.Name = "IzbrisiStanaraDugme";
            IzbrisiStanaraDugme.Size = new Size(157, 39);
            IzbrisiStanaraDugme.TabIndex = 2;
            IzbrisiStanaraDugme.Text = "Izbriši stanara";
            IzbrisiStanaraDugme.UseVisualStyleBackColor = true;
            IzbrisiStanaraDugme.Click += IzbrisiStanaraDugme_Click;
            // 
            // ImeTextBox
            // 
            ImeTextBox.Location = new Point(329, 57);
            ImeTextBox.Name = "ImeTextBox";
            ImeTextBox.Size = new Size(157, 27);
            ImeTextBox.TabIndex = 3;
            ImeTextBox.Visible = false;
            // 
            // StanariForma
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(498, 186);
            Controls.Add(ImeTextBox);
            Controls.Add(IzbrisiStanaraDugme);
            Controls.Add(DodajStanaraDugme);
            Controls.Add(StanariListBox);
            Name = "StanariForma";
            Text = "StanariForma";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private ListBox StanariListBox;
        private Button DodajStanaraDugme;
        private Button IzbrisiStanaraDugme;
        private TextBox ImeTextBox;
    }
}