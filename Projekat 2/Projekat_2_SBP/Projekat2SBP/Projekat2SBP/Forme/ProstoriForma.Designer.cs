namespace Projekat2SBP.Forme
{
    partial class ProstoriForma
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
            ProstoriDataGridView = new DataGridView();
            PrikaziProstorDugme = new Button();
            IzbrisiProstorDugme = new Button();
            DodajStanDugme = new Button();
            DodajLokalDugme = new Button();
            DodajParkingDugme = new Button();
            ((System.ComponentModel.ISupportInitialize)ProstoriDataGridView).BeginInit();
            SuspendLayout();
            // 
            // ProstoriDataGridView
            // 
            ProstoriDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ProstoriDataGridView.Location = new Point(12, 12);
            ProstoriDataGridView.Name = "ProstoriDataGridView";
            ProstoriDataGridView.RowHeadersWidth = 51;
            ProstoriDataGridView.Size = new Size(512, 426);
            ProstoriDataGridView.TabIndex = 0;
            // 
            // PrikaziProstorDugme
            // 
            PrikaziProstorDugme.Location = new Point(530, 12);
            PrikaziProstorDugme.Name = "PrikaziProstorDugme";
            PrikaziProstorDugme.Size = new Size(200, 48);
            PrikaziProstorDugme.TabIndex = 1;
            PrikaziProstorDugme.Text = "Prikaži prostor";
            PrikaziProstorDugme.UseVisualStyleBackColor = true;
            PrikaziProstorDugme.Click += PrikaziProstorDugme_Click;
            // 
            // IzbrisiProstorDugme
            // 
            IzbrisiProstorDugme.Location = new Point(530, 66);
            IzbrisiProstorDugme.Name = "IzbrisiProstorDugme";
            IzbrisiProstorDugme.Size = new Size(200, 48);
            IzbrisiProstorDugme.TabIndex = 2;
            IzbrisiProstorDugme.Text = "Izbriši prostor";
            IzbrisiProstorDugme.UseVisualStyleBackColor = true;
            IzbrisiProstorDugme.Click += IzbrisiProstorDugme_Click;
            // 
            // DodajStanDugme
            // 
            DodajStanDugme.Location = new Point(530, 120);
            DodajStanDugme.Name = "DodajStanDugme";
            DodajStanDugme.Size = new Size(200, 48);
            DodajStanDugme.TabIndex = 3;
            DodajStanDugme.Text = "Dodaj stan";
            DodajStanDugme.UseVisualStyleBackColor = true;
            DodajStanDugme.Click += DodajStanDugme_Click;
            // 
            // DodajLokalDugme
            // 
            DodajLokalDugme.Location = new Point(530, 174);
            DodajLokalDugme.Name = "DodajLokalDugme";
            DodajLokalDugme.Size = new Size(200, 48);
            DodajLokalDugme.TabIndex = 4;
            DodajLokalDugme.Text = "Dodaj lokal";
            DodajLokalDugme.UseVisualStyleBackColor = true;
            DodajLokalDugme.Click += DodajLokalDugme_Click;
            // 
            // DodajParkingDugme
            // 
            DodajParkingDugme.Location = new Point(530, 228);
            DodajParkingDugme.Name = "DodajParkingDugme";
            DodajParkingDugme.Size = new Size(200, 48);
            DodajParkingDugme.TabIndex = 5;
            DodajParkingDugme.Text = "Dodaj parking";
            DodajParkingDugme.UseVisualStyleBackColor = true;
            DodajParkingDugme.Click += DodajParkingDugme_Click;
            // 
            // ProstoriForma
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(742, 450);
            Controls.Add(DodajParkingDugme);
            Controls.Add(DodajLokalDugme);
            Controls.Add(DodajStanDugme);
            Controls.Add(IzbrisiProstorDugme);
            Controls.Add(PrikaziProstorDugme);
            Controls.Add(ProstoriDataGridView);
            Name = "ProstoriForma";
            Text = "ProstoriForma";
            ((System.ComponentModel.ISupportInitialize)ProstoriDataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView ProstoriDataGridView;
        private Button PrikaziProstorDugme;
        private Button IzbrisiProstorDugme;
        private Button DodajStanDugme;
        private Button DodajLokalDugme;
        private Button DodajParkingDugme;
    }
}