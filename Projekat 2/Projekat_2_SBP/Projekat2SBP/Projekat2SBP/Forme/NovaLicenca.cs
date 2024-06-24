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
    public partial class NovaLicenca : Form
    {
        public LicencaBasic NovaLic { get; set; }
        public bool Dodaj { get; set; }
        public NovaLicenca()
        {
            InitializeComponent();
            NovaLic = new();
            Dodaj = false;
        }

        private void BrojLicenceTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void IzdavacTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void DodajLicencuDugme_Click(object sender, EventArgs e)
        {
            if(BrojLicenceTextBox.Text.Length == 0 || IzdavacTextBox.Text.Length == 0)
            {
                MessageBox.Show("Popunite sva polja.", "Popunite sva polja.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            NovaLic = new LicencaBasic()
            {
                BrLicence = Int32.Parse(BrojLicenceTextBox.Text),
                Izdavac = IzdavacTextBox.Text,
                DatumSticanja = DatumSticanjDateTimePicker.Value
            };

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
    }
}
