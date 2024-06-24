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
    public partial class NoviUlaz : Form
    {
        public UlazBasic Novi { get; set; }
        public bool Dodaj { get; set; }
        public NoviUlaz()
        {
            InitializeComponent();
            Novi = new UlazBasic();
            Dodaj = false;
        }

        private void DodajDugme_Click(object sender, EventArgs e)
        {
            if(!ImaRadioButton.Checked || !NemaRadioButton.Checked)
            {
                MessageBox.Show("Izaberite opciju za kameru.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Novi.PocetakRadnogVremena = PocetakRadnogVremenaTimePicker.Text;
            Novi.KrajRadnogVremena = KrajRadnogVremenaTimePicker.Text;
            Novi.Kamera = ImaRadioButton.Checked ? 'Y' : 'N';

            Dodaj = true;
            this.Close();
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

        private void ImaRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (ImaRadioButton.Checked)
            {
                NemaRadioButton.Checked = false;
            }
        }

        private void NemaRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if(NemaRadioButton.Checked)
            {
                ImaRadioButton.Checked = false;
            }
        }
    }
}
