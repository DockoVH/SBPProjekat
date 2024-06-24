namespace Projekat2SBP.Forme
{
    partial class IzmeniBrojTelefona
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
            BrojeviListView = new ListView();
            NoviBrojTextBox = new TextBox();
            DodajTelefonDugme = new Button();
            IzbrisiBrojDugme = new Button();
            SuspendLayout();
            // 
            // BrojeviListView
            // 
            BrojeviListView.Location = new Point(12, 12);
            BrojeviListView.Name = "BrojeviListView";
            BrojeviListView.Size = new Size(186, 166);
            BrojeviListView.TabIndex = 0;
            BrojeviListView.UseCompatibleStateImageBehavior = false;
            // 
            // NoviBrojTextBox
            // 
            NoviBrojTextBox.Location = new Point(222, 150);
            NoviBrojTextBox.Name = "NoviBrojTextBox";
            NoviBrojTextBox.Size = new Size(94, 27);
            NoviBrojTextBox.TabIndex = 1;
            NoviBrojTextBox.KeyPress += NoviBrojTextBox_KeyPress;
            // 
            // DodajTelefonDugme
            // 
            DodajTelefonDugme.Location = new Point(222, 115);
            DodajTelefonDugme.Name = "DodajTelefonDugme";
            DodajTelefonDugme.Size = new Size(94, 29);
            DodajTelefonDugme.TabIndex = 2;
            DodajTelefonDugme.Text = "Dodaj";
            DodajTelefonDugme.UseVisualStyleBackColor = true;
            DodajTelefonDugme.Click += DodajTelefonDugme_Click;
            // 
            // IzbrisiBrojDugme
            // 
            IzbrisiBrojDugme.Location = new Point(222, 12);
            IzbrisiBrojDugme.Name = "IzbrisiBrojDugme";
            IzbrisiBrojDugme.Size = new Size(94, 29);
            IzbrisiBrojDugme.TabIndex = 4;
            IzbrisiBrojDugme.Text = "Izbriši";
            IzbrisiBrojDugme.UseVisualStyleBackColor = true;
            IzbrisiBrojDugme.Click += IzbrisiBrojDugme_Click;
            // 
            // IzmeniBrojTelefona
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(350, 202);
            Controls.Add(IzbrisiBrojDugme);
            Controls.Add(DodajTelefonDugme);
            Controls.Add(NoviBrojTextBox);
            Controls.Add(BrojeviListView);
            Name = "IzmeniBrojTelefona";
            Text = "IzmeniBrojTelefona";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListView BrojeviListView;
        private TextBox NoviBrojTextBox;
        private Button DodajTelefonDugme;
        private Button IzbrisiBrojDugme;
    }
}