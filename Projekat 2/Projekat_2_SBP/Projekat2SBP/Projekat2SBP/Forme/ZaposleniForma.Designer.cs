namespace Projekat2SBP.Forme
{
    partial class ZaposleniForma
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
            ZaposleniGridView = new DataGridView();
            PrikaziZaposlenogDugme = new Button();
            DodajZaposlenogDugme = new Button();
            IzbrisiZaposlenogDugme = new Button();
            IzmeniZaposlenogDugme = new Button();
            ((System.ComponentModel.ISupportInitialize)ZaposleniGridView).BeginInit();
            SuspendLayout();
            // 
            // ZaposleniGridView
            // 
            ZaposleniGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            ZaposleniGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllHeaders;
            ZaposleniGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ZaposleniGridView.Location = new Point(12, 12);
            ZaposleniGridView.Name = "ZaposleniGridView";
            ZaposleniGridView.RowHeadersWidth = 51;
            ZaposleniGridView.Size = new Size(511, 426);
            ZaposleniGridView.TabIndex = 0;
            // 
            // PrikaziZaposlenogDugme
            // 
            PrikaziZaposlenogDugme.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            PrikaziZaposlenogDugme.Location = new Point(529, 12);
            PrikaziZaposlenogDugme.Name = "PrikaziZaposlenogDugme";
            PrikaziZaposlenogDugme.Size = new Size(207, 47);
            PrikaziZaposlenogDugme.TabIndex = 1;
            PrikaziZaposlenogDugme.Text = "Prikaži zaposlenog";
            PrikaziZaposlenogDugme.UseVisualStyleBackColor = true;
            PrikaziZaposlenogDugme.Click += PrikaziZaposlenogDugme_Click;
            // 
            // DodajZaposlenogDugme
            // 
            DodajZaposlenogDugme.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            DodajZaposlenogDugme.Location = new Point(529, 75);
            DodajZaposlenogDugme.Name = "DodajZaposlenogDugme";
            DodajZaposlenogDugme.Size = new Size(207, 47);
            DodajZaposlenogDugme.TabIndex = 2;
            DodajZaposlenogDugme.Text = "Dodaj zaposlenog";
            DodajZaposlenogDugme.UseVisualStyleBackColor = true;
            DodajZaposlenogDugme.Click += DodajZaposlenogDugme_Click;
            // 
            // IzbrisiZaposlenogDugme
            // 
            IzbrisiZaposlenogDugme.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            IzbrisiZaposlenogDugme.Location = new Point(529, 139);
            IzbrisiZaposlenogDugme.Name = "IzbrisiZaposlenogDugme";
            IzbrisiZaposlenogDugme.Size = new Size(207, 47);
            IzbrisiZaposlenogDugme.TabIndex = 3;
            IzbrisiZaposlenogDugme.Text = "Izbriši zaposlenog";
            IzbrisiZaposlenogDugme.UseVisualStyleBackColor = true;
            IzbrisiZaposlenogDugme.Click += IzbrisiZaposlenogDugme_Click;
            // 
            // IzmeniZaposlenogDugme
            // 
            IzmeniZaposlenogDugme.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            IzmeniZaposlenogDugme.Location = new Point(529, 208);
            IzmeniZaposlenogDugme.Name = "IzmeniZaposlenogDugme";
            IzmeniZaposlenogDugme.Size = new Size(207, 47);
            IzmeniZaposlenogDugme.TabIndex = 4;
            IzmeniZaposlenogDugme.Text = "Izmeni zaposlenog";
            IzmeniZaposlenogDugme.UseVisualStyleBackColor = true;
            IzmeniZaposlenogDugme.Click += IzmeniZaposlenogDugme_Click;
            // 
            // ZaposleniForma
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(744, 450);
            Controls.Add(IzmeniZaposlenogDugme);
            Controls.Add(IzbrisiZaposlenogDugme);
            Controls.Add(DodajZaposlenogDugme);
            Controls.Add(PrikaziZaposlenogDugme);
            Controls.Add(ZaposleniGridView);
            MaximizeBox = false;
            Name = "ZaposleniForma";
            Text = "Zaposleni";
            ((System.ComponentModel.ISupportInitialize)ZaposleniGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView ZaposleniGridView;
        private Button PrikaziZaposlenogDugme;
        private Button DodajZaposlenogDugme;
        private Button IzbrisiZaposlenogDugme;
        private Button IzmeniZaposlenogDugme;
    }
}