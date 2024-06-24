namespace Projekat2SBP.Forme
{
    partial class IzmeniObrazovanje
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
            ObrazovanjaGridView = new DataGridView();
            Dodaj = new Button();
            IzbrisiDugme = new Button();
            ((System.ComponentModel.ISupportInitialize)ObrazovanjaGridView).BeginInit();
            SuspendLayout();
            // 
            // ObrazovanjaGridView
            // 
            ObrazovanjaGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ObrazovanjaGridView.Location = new Point(12, 12);
            ObrazovanjaGridView.Name = "ObrazovanjaGridView";
            ObrazovanjaGridView.RowHeadersWidth = 51;
            ObrazovanjaGridView.Size = new Size(393, 188);
            ObrazovanjaGridView.TabIndex = 0;
            // 
            // Dodaj
            // 
            Dodaj.Location = new Point(12, 215);
            Dodaj.Name = "Dodaj";
            Dodaj.Size = new Size(124, 51);
            Dodaj.TabIndex = 1;
            Dodaj.Text = "Dodaj";
            Dodaj.UseVisualStyleBackColor = true;
            Dodaj.Click += Dodaj_Click;
            // 
            // IzbrisiDugme
            // 
            IzbrisiDugme.Location = new Point(281, 215);
            IzbrisiDugme.Name = "IzbrisiDugme";
            IzbrisiDugme.Size = new Size(124, 51);
            IzbrisiDugme.TabIndex = 2;
            IzbrisiDugme.Text = "Izbriši";
            IzbrisiDugme.UseVisualStyleBackColor = true;
            IzbrisiDugme.Click += IzbrisiDugme_Click;
            // 
            // IzmeniObrazovanje
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(417, 288);
            Controls.Add(IzbrisiDugme);
            Controls.Add(Dodaj);
            Controls.Add(ObrazovanjaGridView);
            Name = "IzmeniObrazovanje";
            Text = "IzmeniObrazovanje";
            ((System.ComponentModel.ISupportInitialize)ObrazovanjaGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView ObrazovanjaGridView;
        private Button Dodaj;
        private Button IzbrisiDugme;
    }
}