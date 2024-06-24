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
    public partial class IzmeniBrojTelefona : Form
    {
        private OsobaBasic osoba;
        public IzmeniBrojTelefona() 
        {
            InitializeComponent();
        }

        public IzmeniBrojTelefona(OsobaBasic o)
        {
            InitializeComponent();
            osoba = o;

            foreach (var broj in osoba.BrojeviTelefona)
            {
                BrojeviListView.Items.Add(broj.BrojTelefona);
            }
        }

        private void NoviBrojTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void IzbrisiBrojDugme_Click(object sender, EventArgs e)
        {
            if (BrojeviListView.SelectedItems.Count != 1)
            {
                MessageBox.Show("Izaberite jedan broj koji želite da izbrišete.", "Greška.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            TelefonBasic tel = osoba.BrojeviTelefona[BrojeviListView.SelectedIndices[0]];
            osoba.BrojeviTelefona.RemoveAt(BrojeviListView.SelectedIndices[0]);
            BrojeviListView.Items.Remove(new ListViewItem(tel.BrojTelefona));
        }

        private void DodajTelefonDugme_Click(object sender, EventArgs e)
        {
            if(NoviBrojTextBox.Text.Length < 9 || NoviBrojTextBox.Text.Length > 10)
            {
                MessageBox.Show("Unesite broj telefona koji ima 9 ili 10 cifara.", "Neispravan broj.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            BrojeviListView.Items.Add(NoviBrojTextBox.Text);
            osoba.BrojeviTelefona.Add(new TelefonBasic()
            {
                Osoba = osoba,
                BrojTelefona = NoviBrojTextBox.Text
            });
        }
    }
}
