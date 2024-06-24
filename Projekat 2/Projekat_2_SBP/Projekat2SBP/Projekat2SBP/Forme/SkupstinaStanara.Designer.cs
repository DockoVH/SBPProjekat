namespace Projekat2SBP.Forme
{
    partial class SkupstinaStanara
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
            SkupstinaDataGridView = new DataGridView();
            PrikaziVlasnikaDugme = new Button();
            DodajVlasnikaDugme = new Button();
            IzbrisiVlasnikaDugme = new Button();
            ((System.ComponentModel.ISupportInitialize)SkupstinaDataGridView).BeginInit();
            SuspendLayout();
            // 
            // SkupstinaDataGridView
            // 
            SkupstinaDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            SkupstinaDataGridView.Location = new Point(12, 12);
            SkupstinaDataGridView.Name = "SkupstinaDataGridView";
            SkupstinaDataGridView.RowHeadersWidth = 51;
            SkupstinaDataGridView.Size = new Size(526, 426);
            SkupstinaDataGridView.TabIndex = 0;
            // 
            // PrikaziVlasnikaDugme
            // 
            PrikaziVlasnikaDugme.Location = new Point(544, 12);
            PrikaziVlasnikaDugme.Name = "PrikaziVlasnikaDugme";
            PrikaziVlasnikaDugme.Size = new Size(218, 55);
            PrikaziVlasnikaDugme.TabIndex = 1;
            PrikaziVlasnikaDugme.Text = "Prikaži vlasnika";
            PrikaziVlasnikaDugme.UseVisualStyleBackColor = true;
            PrikaziVlasnikaDugme.Click += PrikaziVlasnikaDugme_Click;
            // 
            // DodajVlasnikaDugme
            // 
            DodajVlasnikaDugme.Location = new Point(544, 73);
            DodajVlasnikaDugme.Name = "DodajVlasnikaDugme";
            DodajVlasnikaDugme.Size = new Size(218, 55);
            DodajVlasnikaDugme.TabIndex = 2;
            DodajVlasnikaDugme.Text = "Dodaj vlasnika";
            DodajVlasnikaDugme.UseVisualStyleBackColor = true;
            DodajVlasnikaDugme.Click += DodajVlasnikaDugme_Click;
            // 
            // IzbrisiVlasnikaDugme
            // 
            IzbrisiVlasnikaDugme.Location = new Point(544, 134);
            IzbrisiVlasnikaDugme.Name = "IzbrisiVlasnikaDugme";
            IzbrisiVlasnikaDugme.Size = new Size(218, 55);
            IzbrisiVlasnikaDugme.TabIndex = 3;
            IzbrisiVlasnikaDugme.Text = "Izbriši vlasnika";
            IzbrisiVlasnikaDugme.UseVisualStyleBackColor = true;
            IzbrisiVlasnikaDugme.Click += IzbrisiVlasnikaDugme_Click;
            // 
            // SkupstinaStanara
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(774, 450);
            Controls.Add(IzbrisiVlasnikaDugme);
            Controls.Add(DodajVlasnikaDugme);
            Controls.Add(PrikaziVlasnikaDugme);
            Controls.Add(SkupstinaDataGridView);
            Name = "SkupstinaStanara";
            Text = "SkupstinaStanara";
            ((System.ComponentModel.ISupportInitialize)SkupstinaDataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView SkupstinaDataGridView;
        private Button PrikaziVlasnikaDugme;
        private Button DodajVlasnikaDugme;
        private Button IzbrisiVlasnikaDugme;
    }
}