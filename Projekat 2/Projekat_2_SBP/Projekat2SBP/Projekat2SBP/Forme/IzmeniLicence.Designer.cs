namespace Projekat2SBP.Forme
{
    partial class IzmeniLicence
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
            LicenceGridView = new DataGridView();
            DodajLicencuDugme = new Button();
            IzbrisiLicencuDugme = new Button();
            ((System.ComponentModel.ISupportInitialize)LicenceGridView).BeginInit();
            SuspendLayout();
            // 
            // LicenceGridView
            // 
            LicenceGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            LicenceGridView.Location = new Point(12, 12);
            LicenceGridView.Name = "LicenceGridView";
            LicenceGridView.RowHeadersWidth = 51;
            LicenceGridView.Size = new Size(392, 188);
            LicenceGridView.TabIndex = 0;
            // 
            // DodajLicencuDugme
            // 
            DodajLicencuDugme.Location = new Point(12, 217);
            DodajLicencuDugme.Name = "DodajLicencuDugme";
            DodajLicencuDugme.Size = new Size(124, 49);
            DodajLicencuDugme.TabIndex = 1;
            DodajLicencuDugme.Text = "Dodaj";
            DodajLicencuDugme.UseVisualStyleBackColor = true;
            DodajLicencuDugme.Click += DodajLicencuDugme_Click;
            // 
            // IzbrisiLicencuDugme
            // 
            IzbrisiLicencuDugme.Location = new Point(280, 217);
            IzbrisiLicencuDugme.Name = "IzbrisiLicencuDugme";
            IzbrisiLicencuDugme.Size = new Size(124, 49);
            IzbrisiLicencuDugme.TabIndex = 2;
            IzbrisiLicencuDugme.Text = "Izbriši";
            IzbrisiLicencuDugme.UseVisualStyleBackColor = true;
            IzbrisiLicencuDugme.Click += IzbrisiLicencuDugme_Click;
            // 
            // IzmeniLicence
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(416, 288);
            Controls.Add(IzbrisiLicencuDugme);
            Controls.Add(DodajLicencuDugme);
            Controls.Add(LicenceGridView);
            Name = "IzmeniLicence";
            Text = "IzmeniLicence";
            ((System.ComponentModel.ISupportInitialize)LicenceGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView LicenceGridView;
        private Button DodajLicencuDugme;
        private Button IzbrisiLicencuDugme;
    }
}