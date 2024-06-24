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
    public partial class NoviZaposleni : Form
    {
        public ZaposleniBasic NoviRadnik { get; set; }

        private List<string> brojeviTelefona = new List<string>();
        private bool jmbgMoze, adresaMoze, imeMoze, imeRodMoze, prezimeMoze, brLKMoze, mestoLKMoze, posaoMoze, brTelMoze;
        public NoviZaposleni()
        {

            jmbgMoze = adresaMoze = imeMoze = imeRodMoze = prezimeMoze = brLKMoze = mestoLKMoze = posaoMoze = brTelMoze = false;
        }

        public NoviZaposleni(bool upravnik)
        {

            jmbgMoze = adresaMoze = imeMoze = imeRodMoze = prezimeMoze = brLKMoze = mestoLKMoze = posaoMoze = brTelMoze = false;
        
            if(upravnik)
            {
                PosaoTextBox.Text = "Upravnik";
                PosaoTextBox.Enabled = false;
            }
        }

        private void NoviZaposleni_Load(object sender, EventArgs e)
        {

        }

        private void JMBGTextBox_TextChanged(object sender, EventArgs e)
        {
            if (JMBGTextBox.Text.Length != 13)
            {
                DodajZaposlenogDugme.Enabled = false;
                jmbgMoze = false;
            }
            else
            {
                DodajZaposlenogDugme.Enabled = true;
                jmbgMoze = true;
            }
        }

        private void JMBGTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
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

        private void PosaoTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void BrojTelTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void BrojTelTextBox_TextChanged(object sender, EventArgs e)
        {
            if (BrojTelTextBox.Text.Length < 9 || BrojTelTextBox.Text.Length > 10)
            {
                DodajTelDugme.Enabled = false;
            }
            else
            {
                DodajTelDugme.Enabled = true;
            }
        }

        private void DodajTelDugme_Click(object sender, EventArgs e)
        {
            if (BrojTelTextBox.Text.Length >= 9 && BrojTelTextBox.Text.Length <= 10)
            {
                brojeviTelefona.Add(BrojTelTextBox.Text);
                BrojTelTextBox.Text = "";

                BrojeviListView.Items.Clear();
                foreach (string s in brojeviTelefona)
                {
                    BrojeviListView.Items.Add(new ListViewItem(s));
                }

                brTelMoze = true;
            }
        }

        private void DodajZaposlenogDugme_Click(object sender, EventArgs e)
        {
            if (jmbgMoze && adresaMoze && imeMoze && imeRodMoze && prezimeMoze && brLKMoze && mestoLKMoze && brTelMoze && posaoMoze)
            {
                NoviRadnik = new ZaposleniBasic()
                {
                    JMBG = JMBGTextBox.Text,
                    Adresa = AdresaTextBox.Text,
                    LIme = ImeTextBox.Text,
                    ImeRoditelja = ImeRodTextBox.Text,
                    Prezime = PrezimeTextBox.Text,
                    Tip = "Zaposleni",
                    DatumRodjenja = DatumRodjDateTimePicker.Value,
                    BrLicneKarte = BrojLKTextBox.Text,
                    MestoIzdLK = MestoIzdLKTextBox.Text,
                    TipPosla = String.Compare(PosaoTextBox.Text, "Upravnik", true) == 0 ? "Upravnik" : PosaoTextBox.Text
                };

                foreach (string s in brojeviTelefona)
                {
                    NoviRadnik.BrojeviTelefona.Add(new TelefonBasic()
                    {
                        Osoba = new OsobaBasic()
                        {
                            JMBG = NoviRadnik.JMBG
                        },
                        BrojTelefona = s
                    });
                }

                this.Close();
            }
            else
            {
                MessageBox.Show("Popunite sva polja.", "Popunite sva polja!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void AdresaTextBox_TextChanged(object sender, EventArgs e)
        {
            adresaMoze = AdresaTextBox.Text.Length > 0;
        }

        private void ImeTextBox_TextChanged(object sender, EventArgs e)
        {
            imeMoze = ImeTextBox.Text.Length > 0;
        }

        private void ImeRodTextBox_TextChanged(object sender, EventArgs e)
        {
            imeRodMoze = ImeRodTextBox.Text.Length > 0;
        }

        private void PrezimeTextBox_TextChanged(object sender, EventArgs e)
        {
            prezimeMoze = PrezimeTextBox.Text.Length > 0;
        }

        private void BrojLKTextBox_TextChanged(object sender, EventArgs e)
        {
            brLKMoze = BrojLKTextBox.Text.Length > 0;
        }

        private void MestoIzdLKTextBox_TextChanged(object sender, EventArgs e)
        {
            mestoLKMoze = MestoIzdLKTextBox.Text.Length > 0;
        }

        private void PosaoTextBox_TextChanged(object sender, EventArgs e)
        {
            posaoMoze = PosaoTextBox.Text.Length > 0;
        }

        private void OdbaciDugme_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Da li ste sigurni da želite da odustanete?", "Odustani?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if(dr == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
