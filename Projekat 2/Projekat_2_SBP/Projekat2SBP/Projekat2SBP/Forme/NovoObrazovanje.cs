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
    public partial class NovoObrazovanje : Form
    {
        public ObrazovanjeBasic novoObrazovanje { get; set; }
        public bool Dodaj { get; set; }
        public NovoObrazovanje()
        {
            InitializeComponent();
            novoObrazovanje = new();
            Dodaj = false;
        }

        private void ZvanjeTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void NazivInstitucijeTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void OtkaziDugme_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Da li želite da odustanete?", "Odustani?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                Dodaj = false;
                this.Close();
            }
        }

        private void DodajObrazovanjeDugme_Click(object sender, EventArgs e)
        {
            if(ZvanjeTextBox.Text.Length == 0 || NazivInstitucijeTextBox.Text.Length == 0)
            {
                MessageBox.Show("Popunite sva polja.", "Popunite polja.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            novoObrazovanje = new()
            {
                Zvanje = ZvanjeTextBox.Text,
                DatumSticanja = DatumSticanjaDateTimePicker.Value,
                NazivInstitucije = NazivInstitucijeTextBox.Text
            };

            Dodaj = true;
            this.Close();
        }
    }
}
