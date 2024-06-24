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
    public partial class JednaZgrada : Form
    {
        private ZgradaPregled zgrada;
        public JednaZgrada()
        {
            InitializeComponent();
        }

        public JednaZgrada(ZgradaPregled zgrada)
        {
            InitializeComponent();
            this.zgrada = zgrada;

            AdresaTextBox.Text = zgrada.Adresa;
            UpravnikTextBox.Text = zgrada.Upravnik.PunoIme;
            BrojUgovoraTextBox.Text = zgrada.BrojUgovora.ToString();
            BrojUlazaLabel.Text = zgrada.BrojUlaza.ToString();
            BrojLiftovaLabel.Text = zgrada.BrojLiftova.ToString();
            BrojSpratovaTextBox.Text = zgrada.BrojSpratova.ToString();
            BrojVlasnikaTextBox.Text = zgrada.BrojVlasnikaStanova.ToString();

            List<ProstorPregled> prostori =  DTOManager.sviProstoriUZgradi(zgrada.ID);
            int stanovi = 0, lokali = 0, parkinzi = 0;

            foreach (var prostor in prostori)
            {
                if(String.Compare(prostor.Tip, "stan", true) == 0)
                {
                    stanovi++;
                }
                else if(String.Compare(prostor.Tip, "lokal", true) == 0)
                {
                    lokali++;
                }
                else
                {
                    parkinzi++;
                }
            }

            BrojStanovaTextBox.Text = stanovi.ToString();
            BrojLokalaTextBox.Text = lokali.ToString();
            BrojParkingaTextBox.Text = parkinzi.ToString();
        }

        private void PrikaziUpravnikaDugme_Click(object sender, EventArgs e)
        {
            ZaposleniBasic z = DTOManager.vratiZaposlenog(zgrada.Upravnik.JMBG);

            ZaposleniPregled pregled = new ZaposleniPregled()
            {
                JMBG = z.JMBG,
                Adresa = z.Adresa,
                PunoIme = $"{z.LIme} ({z.ImeRoditelja}) {z.Prezime}",
                DatumRodjenja = z.DatumRodjenja,
                BrLicneKarte = z.BrLicneKarte,
                MestoIzdLK = z.MestoIzdLK,
                TipPosla = z.TipPosla
            };

            foreach (var obrazovanje in z.Obrazovanja)
            {
                pregled.Obrazovanja.Add(new ObrazovanjePregled()
                {
                    Zvanje = obrazovanje.Zvanje,
                    Upravnik = pregled,
                    DatumSticanja = obrazovanje.DatumSticanja,
                    NazivInstitucije = obrazovanje.NazivInstitucije
                });
            }

            foreach (var licenca in z.Licence)
            {
                pregled.Licence.Add(new LicencaPregled()
                { 
                    Upravnik = pregled,
                    DatumSticanja = licenca.DatumSticanja,
                    Izdavac = licenca.Izdavac,
                    BrLicence = licenca.BrLicence
                });
            }

            foreach(var zgrada in z.UpravljaZgradama)
            {
                pregled.Zgrade.Add(new ZgradaPregled()
                {
                    ID = zgrada.ID,
                });
            }

            foreach (var telefon in z.BrojeviTelefona)
            {
                pregled.BrojeviTelefona.Add(new TelefonPregled()
                {
                    Osoba = pregled,
                    BrojTelefona = telefon.BrojTelefona
                });
            }

            JedanZaposleni forma = new(pregled);
            forma.ShowDialog();
        }
    }
}
