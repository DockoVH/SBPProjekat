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
    public partial class IzmeniZaposlenog : Form
    {
        private ZaposleniBasic zaposleni;
        public IzmeniZaposlenog()
        {
            InitializeComponent();
            zaposleni = new();
        }

        public IzmeniZaposlenog(ZaposleniBasic z)
        {
            InitializeComponent();
            zaposleni = z;

            JMBGTextBox.Text = zaposleni.JMBG;
            AdresaTextBox.Text = zaposleni.Adresa;
            ImeTextBox.Text = zaposleni.LIme;
            ImeRodTextBox.Text = zaposleni.ImeRoditelja;
            PrezimeTextBox.Text = zaposleni.Prezime;
            DatumRodDatePicker.Value = zaposleni.DatumRodjenja;
            BrojLKTextBox.Text = zaposleni.BrLicneKarte;
            MestoIzdLKTextBox.Text = zaposleni.MestoIzdLK;
            PosaoTextBox.Text = zaposleni.TipPosla;

            if (String.Compare(zaposleni.Tip, "Upravnik", true) == 0)
            {
                BrojeviTelefonaTextBox.Text = zaposleni.BrojeviTelefona.Count.ToString();
                ObrazovanjaTextBox.Text = zaposleni.Obrazovanja.Count.ToString();
                LicenceTextBox.Text = zaposleni.Licence.Count.ToString();

                BrojeviTelefonaTextBox.Visible = true;
                ObrazovanjaTextBox.Visible = true;
                LicenceTextBox.Visible = true;
                IzmeniBrojeveDugme.Visible = true;
                IzmeniObrazovanjaDugme.Visible = true;
                IzmeniLicenceDugme.Visible = true;
            }
            else
            {
                BrojeviTelefonaTextBox.Visible = false;
                ObrazovanjaTextBox.Visible = false;
                LicenceTextBox.Visible = false;
                IzmeniBrojeveDugme.Visible = false;
                IzmeniObrazovanjaDugme.Visible = false;
                IzmeniLicenceDugme.Visible = false;
            }
        }

        private void BrojLKTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void MestoIzdLKTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void ImeTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void ImeRodTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void PrezimeTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void PosaoTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void IzmeniBrojeveDugme_Click(object sender, EventArgs e)
        {
            IzmeniBrojTelefona forma = new(zaposleni);
            forma.ShowDialog();
            BrojeviTelefonaTextBox.Text = zaposleni.BrojeviTelefona.Count.ToString();
        }

        private void IzmeniObrazovanjaDugme_Click(object sender, EventArgs e)
        {
            IzmeniObrazovanje forma = new(zaposleni);
            forma.ShowDialog();
            ObrazovanjaTextBox.Text = zaposleni.Obrazovanja.Count.ToString();
        }

        private void IzmeniLicenceDugme_Click(object sender, EventArgs e)
        {
            IzmeniLicence forma = new(zaposleni);
            forma.ShowDialog();
            LicenceTextBox.Text = zaposleni.Licence.ToString();
        }

        private void SacuvajDugme_Click(object sender, EventArgs e)
        {
            DTOManager.izmeniZaposlenog(zaposleni);
            this.Close();
        }

        private void OtkaziDugme_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Da li želite da odustanete?", "Izaz iz forme?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
