namespace Projekat2SBP.Forme
{
    partial class UpravniciZgrade
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
            UpravniciGridView = new DataGridView();
            PrikaziUpravnikaDugme = new Button();
            DodajUpravnikaDugme = new Button();
            IzbrisiUpravnikaDugme = new Button();
            ((System.ComponentModel.ISupportInitialize)UpravniciGridView).BeginInit();
            SuspendLayout();
            // 
            // UpravniciGridView
            // 
            UpravniciGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            UpravniciGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllHeaders;
            UpravniciGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            UpravniciGridView.Location = new Point(12, 12);
            UpravniciGridView.Name = "UpravniciGridView";
            UpravniciGridView.RowHeadersWidth = 51;
            UpravniciGridView.Size = new Size(511, 426);
            UpravniciGridView.TabIndex = 1;
            // 
            // PrikaziUpravnikaDugme
            // 
            PrikaziUpravnikaDugme.Location = new Point(529, 12);
            PrikaziUpravnikaDugme.Name = "PrikaziUpravnikaDugme";
            PrikaziUpravnikaDugme.Size = new Size(207, 47);
            PrikaziUpravnikaDugme.TabIndex = 2;
            PrikaziUpravnikaDugme.Text = "Prikaži upravika";
            PrikaziUpravnikaDugme.UseVisualStyleBackColor = true;
            PrikaziUpravnikaDugme.Click += PrikaziUpravnikaDugme_Click;
            // 
            // DodajUpravnikaDugme
            // 
            DodajUpravnikaDugme.Location = new Point(529, 82);
            DodajUpravnikaDugme.Name = "DodajUpravnikaDugme";
            DodajUpravnikaDugme.Size = new Size(207, 47);
            DodajUpravnikaDugme.TabIndex = 3;
            DodajUpravnikaDugme.Text = "Dodaj upravnika";
            DodajUpravnikaDugme.UseVisualStyleBackColor = true;
            DodajUpravnikaDugme.Click += DodajUpravnikaDugme_Click;
            // 
            // IzbrisiUpravnikaDugme
            // 
            IzbrisiUpravnikaDugme.Location = new Point(529, 155);
            IzbrisiUpravnikaDugme.Name = "IzbrisiUpravnikaDugme";
            IzbrisiUpravnikaDugme.Size = new Size(207, 47);
            IzbrisiUpravnikaDugme.TabIndex = 4;
            IzbrisiUpravnikaDugme.Text = "Izbriši upravnika";
            IzbrisiUpravnikaDugme.UseVisualStyleBackColor = true;
            IzbrisiUpravnikaDugme.Click += IzbrisiUpravnikaDugme_Click;
            // 
            // UpravniciZgrade
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(744, 450);
            Controls.Add(IzbrisiUpravnikaDugme);
            Controls.Add(DodajUpravnikaDugme);
            Controls.Add(PrikaziUpravnikaDugme);
            Controls.Add(UpravniciGridView);
            Name = "UpravniciZgrade";
            Text = "UpravniciZgrade";
            ((System.ComponentModel.ISupportInitialize)UpravniciGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView UpravniciGridView;
        private Button PrikaziUpravnikaDugme;
        private Button DodajUpravnikaDugme;
        private Button IzbrisiUpravnikaDugme;
    }
}