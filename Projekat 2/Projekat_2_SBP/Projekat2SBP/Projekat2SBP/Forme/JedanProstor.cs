using Projekat2SBP.Enums;
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
    public partial class JedanProstor : Form
    {
        private ProstorBasic prostor;
        public JedanProstor()
        {
            InitializeComponent();
        }

        public JedanProstor(ProstorBasic p)
        {
            prostor = p;

            RedniBrojTextBox.Text = prostor.RBroj.ToString();
            SpratTextBox.Text = prostor.Sprat.RBroj.ToString();
            TipTextBox.Text = prostor.Tip;

            switch (prostor.Tip)
            {
                case "stan":
                    DodatnoLabel.Text = "Vlasnik:";
                    DodatnoTextBox.Text = $"{((StanBasic)prostor).Vlasnik.LIme} ({((StanBasic)prostor).Vlasnik.ImeRoditelja}) {((StanBasic)prostor).Vlasnik.Prezime}";
                    BrojStanaraLabel.Visible = true;
                    BrojStanaraTextBox.Visible = true;
                    BrojStanaraTextBox.Text = ((StanBasic)prostor).Stanari.Count.ToString();
                    PrikaziStanareDugme.Visible = true;
                    break;
                case "lokal":
                    DodatnoLabel.Text = "Ime firme:";
                    DodatnoTextBox.Text = ((LokalBasic)prostor).ImeFirme;
                    BrojStanaraLabel.Visible = false;
                    BrojStanaraTextBox.Visible = false;
                    PrikaziStanareDugme.Visible = false;
                    break;
                case "parking":
                    DodatnoLabel.Text = "Registracija vozila:";
                    DodatnoTextBox.Text = ((ParkingBasic)prostor).RegVozila;
                    BrojStanaraLabel.Visible = false;
                    BrojStanaraTextBox.Visible = false;
                    PrikaziStanareDugme.Visible = false;
                    break;
                default:
                    break;
            }
        }

        private void PrikaziStanareDugme_Click(object sender, EventArgs e)
        {
            StanariForma forma = new((StanBasic)prostor);
            forma.ShowDialog();
            DTOManager.izmeniProstor(prostor, ProstorTip.Stan);
        }
    }
}
