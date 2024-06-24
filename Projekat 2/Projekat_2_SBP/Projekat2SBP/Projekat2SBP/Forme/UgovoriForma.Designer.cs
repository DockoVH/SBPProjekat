namespace Projekat2SBP.Forme
{
    partial class UgovoriForma
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
            UgovoriDataGridView = new DataGridView();
            DodajUgovorDugme = new Button();
            IzbrisiUgovorDugme = new Button();
            ((System.ComponentModel.ISupportInitialize)UgovoriDataGridView).BeginInit();
            SuspendLayout();
            // 
            // UgovoriDataGridView
            // 
            UgovoriDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            UgovoriDataGridView.Location = new Point(12, 12);
            UgovoriDataGridView.Name = "UgovoriDataGridView";
            UgovoriDataGridView.RowHeadersWidth = 51;
            UgovoriDataGridView.Size = new Size(518, 426);
            UgovoriDataGridView.TabIndex = 0;
            // 
            // DodajUgovorDugme
            // 
            DodajUgovorDugme.Location = new Point(536, 12);
            DodajUgovorDugme.Name = "DodajUgovorDugme";
            DodajUgovorDugme.Size = new Size(223, 49);
            DodajUgovorDugme.TabIndex = 1;
            DodajUgovorDugme.Text = "Dodaj ugovor";
            DodajUgovorDugme.UseVisualStyleBackColor = true;
            DodajUgovorDugme.Click += DodajUgovorDugme_Click;
            // 
            // IzbrisiUgovorDugme
            // 
            IzbrisiUgovorDugme.Location = new Point(536, 91);
            IzbrisiUgovorDugme.Name = "IzbrisiUgovorDugme";
            IzbrisiUgovorDugme.Size = new Size(223, 49);
            IzbrisiUgovorDugme.TabIndex = 2;
            IzbrisiUgovorDugme.Text = "Izbriši ugovor";
            IzbrisiUgovorDugme.UseVisualStyleBackColor = true;
            IzbrisiUgovorDugme.Click += IzbrisiUgovorDugme_Click;
            // 
            // UgovoriForma
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(769, 450);
            Controls.Add(IzbrisiUgovorDugme);
            Controls.Add(DodajUgovorDugme);
            Controls.Add(UgovoriDataGridView);
            Name = "UgovoriForma";
            Text = "UgovoriForma";
            ((System.ComponentModel.ISupportInitialize)UgovoriDataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView UgovoriDataGridView;
        private Button DodajUgovorDugme;
        private Button IzbrisiUgovorDugme;
    }
}