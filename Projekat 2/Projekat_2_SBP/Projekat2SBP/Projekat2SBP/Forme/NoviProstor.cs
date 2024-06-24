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
    public partial class NoviProstor : Form
    {
        public ProstorBasic Novi { get; set; }
        public bool Dodaj { get; set; }
        private ProstorTip tip;
        public NoviProstor()
        {
            InitializeComponent();
            Novi = new();
            Dodaj = false;
        }

        public NoviProstor(ProstorTip tip)
        {
            InitializeComponent();
            this.tip = tip;
            Dodaj = false;

            switch (this.tip)
            {
                case ProstorTip.Stan:
                    Novi = new StanBasic();
                    StanariLabel.Visible = true;
                    PrikaziStanareDugme.Visible = true;
                    break;
                case ProstorTip.Lokal:
                    Novi = new LokalBasic();
                    JMBGVlasnikaLabel.Text = "Ime firme:";
                    break;
                case ProstorTip.Parking:
                    Novi = new ParkingBasic();
                    JMBGVlasnikaLabel.Text = "Registracija vozila:";
                    break;
                default:
                    break;
            }
        }

        private void OtkaziDugme_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Da li želite da odustanete?", "Odustani?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                this.Close();
                Dodaj = false;
            }
        }

        private void DodajDugme_Click(object sender, EventArgs e)
        {
            if(JMBGVlasnikaTextBox.Text.Length == 0)
            {
                StringBuilder sb = new();
                sb.Append("Unesite ");
                switch (this.tip)
                {
                    case ProstorTip.Stan:
                        sb.Append("JMBG vlasnika!");
                        break;
                    case ProstorTip.Lokal:
                        sb.Append("Ime firme!");
                        break;
                    case ProstorTip.Parking:
                        sb.Append("Registraciju vozila");
                        break;
                    default:
                        break;
                }

                MessageBox.Show(sb.ToString(), "Popunite sva polja", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Novi.Sprat = new SpratBasic()
            {
                RBroj = (int)SpratUpDown.Value
            };

            switch (this.tip)
            {
                case ProstorTip.Stan:
                    ((StanBasic)Novi).Vlasnik = new VlasnikBasic()
                    {
                        JMBG = JMBGVlasnikaTextBox.Text
                    };
                    break;
                case ProstorTip.Lokal:
                    ((LokalBasic)Novi).ImeFirme = JMBGVlasnikaTextBox.Text;
                    break;
                case ProstorTip.Parking:
                    ((ParkingBasic)Novi).RegVozila = JMBGVlasnikaTextBox.Text;
                    break;
                default:
                    break;
            }

            Dodaj = true;
            this.Close();
        }

        private void PrikaziStanareDugme_Click(object sender, EventArgs e)
        {
            StanariForma forma = new((StanBasic)Novi);
            forma.ShowDialog();
        }

        private void JMBGVlasnikaTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                if (tip == ProstorTip.Stan  && !char.IsLetter(e.KeyChar))
                {
                    e.Handled = true;
                }
                else
                {
                    e.Handled = true;
                }
            }
        }
    }
}
