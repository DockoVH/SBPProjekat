namespace Projekat2SBP.Forme
{
    partial class UlaziForma
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
            UlaziDataGridView = new DataGridView();
            DodajUlazDugme = new Button();
            IzbrisiUlazDugme = new Button();
            ((System.ComponentModel.ISupportInitialize)UlaziDataGridView).BeginInit();
            SuspendLayout();
            // 
            // UlaziDataGridView
            // 
            UlaziDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            UlaziDataGridView.Location = new Point(12, 12);
            UlaziDataGridView.Name = "UlaziDataGridView";
            UlaziDataGridView.RowHeadersWidth = 51;
            UlaziDataGridView.Size = new Size(520, 426);
            UlaziDataGridView.TabIndex = 0;
            // 
            // DodajUlazDugme
            // 
            DodajUlazDugme.Location = new Point(538, 12);
            DodajUlazDugme.Name = "DodajUlazDugme";
            DodajUlazDugme.Size = new Size(190, 47);
            DodajUlazDugme.TabIndex = 1;
            DodajUlazDugme.Text = "Dodaj ulaz";
            DodajUlazDugme.UseVisualStyleBackColor = true;
            DodajUlazDugme.Click += DodajUlazDugme_Click;
            // 
            // IzbrisiUlazDugme
            // 
            IzbrisiUlazDugme.Location = new Point(538, 90);
            IzbrisiUlazDugme.Name = "IzbrisiUlazDugme";
            IzbrisiUlazDugme.Size = new Size(190, 47);
            IzbrisiUlazDugme.TabIndex = 2;
            IzbrisiUlazDugme.Text = "Izbriši ulaz";
            IzbrisiUlazDugme.UseVisualStyleBackColor = true;
            IzbrisiUlazDugme.Click += IzbrisiUlazDugme_Click;
            // 
            // JedanUlaz
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(740, 450);
            Controls.Add(IzbrisiUlazDugme);
            Controls.Add(DodajUlazDugme);
            Controls.Add(UlaziDataGridView);
            Name = "JedanUlaz";
            Text = "JedanUlaz";
            ((System.ComponentModel.ISupportInitialize)UlaziDataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView UlaziDataGridView;
        private Button DodajUlazDugme;
        private Button IzbrisiUlazDugme;
    }
}