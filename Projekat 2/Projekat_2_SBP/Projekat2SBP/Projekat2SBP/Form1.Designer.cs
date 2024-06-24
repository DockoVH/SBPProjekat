namespace Projekat2SBP
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            ZgradeDugme = new Button();
            ZaposleniDugme = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 30F);
            label1.Location = new Point(55, 30);
            label1.Name = "label1";
            label1.Size = new Size(484, 67);
            label1.TabIndex = 0;
            label1.Text = "STAMBENA ZGRADA";
            // 
            // ZgradeDugme
            // 
            ZgradeDugme.Font = new Font("Segoe UI", 20F);
            ZgradeDugme.Location = new Point(55, 146);
            ZgradeDugme.Name = "ZgradeDugme";
            ZgradeDugme.Size = new Size(484, 60);
            ZgradeDugme.TabIndex = 1;
            ZgradeDugme.Text = "Zgrade";
            ZgradeDugme.UseVisualStyleBackColor = true;
            ZgradeDugme.Click += ZgradeDugme_Click;
            // 
            // ZaposleniDugme
            // 
            ZaposleniDugme.Font = new Font("Segoe UI", 20F);
            ZaposleniDugme.Location = new Point(55, 250);
            ZaposleniDugme.Name = "ZaposleniDugme";
            ZaposleniDugme.Size = new Size(484, 60);
            ZaposleniDugme.TabIndex = 2;
            ZaposleniDugme.Text = "Zaposleni";
            ZaposleniDugme.UseVisualStyleBackColor = true;
            ZaposleniDugme.Click += ZaposleniDugme_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(593, 499);
            Controls.Add(ZaposleniDugme);
            Controls.Add(ZgradeDugme);
            Controls.Add(label1);
            MaximizeBox = false;
            Name = "Form1";
            Text = "SBP Projekat 1 - STAMBENA ZGRADA";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button ZgradeDugme;
        private Button ZaposleniDugme;
    }
}
