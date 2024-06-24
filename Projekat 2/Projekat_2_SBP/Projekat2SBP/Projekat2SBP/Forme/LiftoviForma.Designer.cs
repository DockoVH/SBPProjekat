namespace Projekat2SBP.Forme
{
    partial class LiftoviForma
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
            LiftoviDataGridView = new DataGridView();
            PrikaziLiftDugme = new Button();
            IzbrisiLiftDugme = new Button();
            DodajLiftZaLjudeDugme = new Button();
            DodajLiftTeretniDugme = new Button();
            ((System.ComponentModel.ISupportInitialize)LiftoviDataGridView).BeginInit();
            SuspendLayout();
            // 
            // LiftoviDataGridView
            // 
            LiftoviDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            LiftoviDataGridView.Location = new Point(12, 12);
            LiftoviDataGridView.Name = "LiftoviDataGridView";
            LiftoviDataGridView.RowHeadersWidth = 51;
            LiftoviDataGridView.Size = new Size(524, 426);
            LiftoviDataGridView.TabIndex = 0;
            // 
            // PrikaziLiftDugme
            // 
            PrikaziLiftDugme.Location = new Point(542, 12);
            PrikaziLiftDugme.Name = "PrikaziLiftDugme";
            PrikaziLiftDugme.Size = new Size(223, 52);
            PrikaziLiftDugme.TabIndex = 1;
            PrikaziLiftDugme.Text = "Prikaži lift";
            PrikaziLiftDugme.UseVisualStyleBackColor = true;
            PrikaziLiftDugme.Click += PrikaziLiftDugme_Click;
            // 
            // IzbrisiLiftDugme
            // 
            IzbrisiLiftDugme.Location = new Point(542, 70);
            IzbrisiLiftDugme.Name = "IzbrisiLiftDugme";
            IzbrisiLiftDugme.Size = new Size(223, 52);
            IzbrisiLiftDugme.TabIndex = 2;
            IzbrisiLiftDugme.Text = "Izbriši lift";
            IzbrisiLiftDugme.UseVisualStyleBackColor = true;
            IzbrisiLiftDugme.Click += IzbrisiLiftDugme_Click;
            // 
            // DodajLiftZaLjudeDugme
            // 
            DodajLiftZaLjudeDugme.Location = new Point(542, 128);
            DodajLiftZaLjudeDugme.Name = "DodajLiftZaLjudeDugme";
            DodajLiftZaLjudeDugme.Size = new Size(223, 52);
            DodajLiftZaLjudeDugme.TabIndex = 3;
            DodajLiftZaLjudeDugme.Text = "Dodaj lift za ljude";
            DodajLiftZaLjudeDugme.UseVisualStyleBackColor = true;
            DodajLiftZaLjudeDugme.Click += DodajLiftZaLjudeDugme_Click;
            // 
            // DodajLiftTeretniDugme
            // 
            DodajLiftTeretniDugme.Location = new Point(542, 186);
            DodajLiftTeretniDugme.Name = "DodajLiftTeretniDugme";
            DodajLiftTeretniDugme.Size = new Size(223, 52);
            DodajLiftTeretniDugme.TabIndex = 4;
            DodajLiftTeretniDugme.Text = "Dodaj teretni lift";
            DodajLiftTeretniDugme.UseVisualStyleBackColor = true;
            DodajLiftTeretniDugme.Click += DodajLiftTeretniDugme_Click;
            // 
            // LiftoviForma
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(776, 450);
            Controls.Add(DodajLiftTeretniDugme);
            Controls.Add(DodajLiftZaLjudeDugme);
            Controls.Add(IzbrisiLiftDugme);
            Controls.Add(PrikaziLiftDugme);
            Controls.Add(LiftoviDataGridView);
            Name = "LiftoviForma";
            Text = "LiftoviForma";
            ((System.ComponentModel.ISupportInitialize)LiftoviDataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView LiftoviDataGridView;
        private Button PrikaziLiftDugme;
        private Button IzbrisiLiftDugme;
        private Button DodajLiftZaLjudeDugme;
        private Button DodajLiftTeretniDugme;
    }
}