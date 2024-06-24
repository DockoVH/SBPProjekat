using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projekat2SBP.Forme
{
    public partial class NovaZgrada : Form
    {
        public string Adresa { get; set; }
        public NovaZgrada()
        {
            InitializeComponent();
        }

        private void SacuvajDugme_Click(object sender, EventArgs e)
        {
            if(AdresaTextBox.Text.Length == 0)
            {
                MessageBox.Show("Unesite adresu zgrade.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Adresa = AdresaTextBox.Text;
            this.Close();
        }

        private void OtkaziDugme_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Da li želite da odustanete?", "Odustani?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
