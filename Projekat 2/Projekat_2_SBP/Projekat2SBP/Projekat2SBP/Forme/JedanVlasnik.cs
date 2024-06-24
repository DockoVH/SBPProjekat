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
    public partial class JedanVlasnik : Form
    {
        private VlasnikBasic vlasnik;
        public JedanVlasnik()
        {
            InitializeComponent();
            vlasnik = new();
        }

        public JedanVlasnik(VlasnikBasic v)
        {
            InitializeComponent();
            vlasnik = v;

            JMBGTextBox.Text = vlasnik.JMBG;
            AdresaTextBox.Text = vlasnik.Adresa;
            ImeTextBox.Text = vlasnik.LIme;
            ImeRoditeljaTextBox.Text = vlasnik.ImeRoditelja;
            PrezimeTextBox.Text = vlasnik.Prezime;
        }

        private void PrikaziTelefoneDugme_Click(object sender, EventArgs e)
        {
            IzmeniBrojTelefona forma = new(vlasnik);
            forma.ShowDialog();
            DTOManager.izmeniVlasnika(vlasnik);
        }
    }
}
