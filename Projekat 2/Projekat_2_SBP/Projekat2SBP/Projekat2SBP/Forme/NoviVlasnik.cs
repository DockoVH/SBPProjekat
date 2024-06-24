using Projekat2SBP.Entiteti;
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
    public partial class NoviVlasnik : Form
    {
        public SkupstinaStanaraBasic Vlasnik { get; set; }
        public bool Dodaj { get; set; }
        public NoviVlasnik()
        {
            InitializeComponent();
            Vlasnik = new();
            Dodaj = false;
        }

        private void JMBGTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void AdresaTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsLetter(e.KeyChar))
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

        private void ImeRoditeljaTextBox_KeyPress(object sender, KeyPressEventArgs e)
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

        private void FunkcijaTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void BrojeviTelefonaDugme_Click(object sender, EventArgs e)
        {
            IzmeniBrojTelefona forma = new(Vlasnik.Vlasnik);
            forma.ShowDialog();
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

        private void DodajDugme_Click(object sender, EventArgs e)
        {
            if (JMBGTextBox.Text.Length != 13)
            {
                MessageBox.Show("Popunite sva polja!", "Greška!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (AdresaTextBox.Text.Length == 0)
            {
                MessageBox.Show("Popunite sva polja!", "Greška!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (ImeTextBox.Text.Length == 0)
            {
                MessageBox.Show("Popunite sva polja!", "Greška!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (ImeRoditeljaTextBox.Text.Length == 0)
            {
                MessageBox.Show("Popunite sva polja!", "Greška!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (PrezimeTextBox.Text.Length == 0)
            {
                MessageBox.Show("Popunite sva polja!", "Greška!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (FunkcijaTextBox.Text.Length == 0)
            {
                MessageBox.Show("Popunite sva polja!", "Greška!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Vlasnik.Vlasnik.JMBG = JMBGTextBox.Text;
            Vlasnik.Vlasnik.Adresa = AdresaTextBox.Text;
            Vlasnik.Vlasnik.LIme = ImeTextBox.Text;
            Vlasnik.Vlasnik.ImeRoditelja = ImeRoditeljaTextBox.Text;
            Vlasnik.Vlasnik.Prezime = PrezimeTextBox.Text;

            Vlasnik.Funkcija = FunkcijaTextBox.Text;

            Dodaj = true;
            this.Close();
        }

    }
}
