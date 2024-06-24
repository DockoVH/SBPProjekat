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
    public partial class JedanZaposleni : Form
    {
        ZaposleniPregled Zaposleni;

        public JedanZaposleni()
        {
            InitializeComponent();
        }

        public JedanZaposleni(ZaposleniPregled z)
        {
            Zaposleni = z;
            InitializeComponent();

            ImeZaposlenogLabel.Text = Zaposleni.PunoIme;
            MaticniBrojTextBox.Text = z.JMBG;
            DatumRodjenjaDateTimePicker.Value = z.DatumRodjenja.Date;
            MestoIzdLKTextBox.Text = z.MestoIzdLK;
            BrojTelefonaTextBox.Text = z.BrojeviTelefona.First() != null ? z.BrojeviTelefona.First().BrojTelefona : "";
            TipPoslaTextBox.Text = z.TipPosla;
            if(z.TipPosla == "Upravnik")
            {
                ObrazovanjaTextBox.Text = z.Obrazovanja.Count.ToString();
                LicenceTextBox.Text = z.Licence.Count.ToString();
                BrojZgradaTextBox.Text = z.Zgrade.Count.ToString();
            }
            else
            {
                ObrazovanjaTextBox.Visible = false;
                LicenceTextBox.Visible = false;
                BrojZgradaTextBox.Visible = false;
                ObrazovanjaLabel.Visible = false;
                LicenceLabel.Visible = false;
                BrojZgradaLabel.Visible = false;
            }
        }

        private void JedanZaposleni_Load(object sender, EventArgs e)
        {

        }
    }
}
