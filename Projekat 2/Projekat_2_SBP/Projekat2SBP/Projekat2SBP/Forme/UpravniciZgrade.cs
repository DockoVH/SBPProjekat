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
    public partial class UpravniciZgrade : Form
    {
        private List<ZaposleniPregled> upravnici;
        private ZgradaBasic zgrada;
        public UpravniciZgrade()
        {
            InitializeComponent();
        }

        public UpravniciZgrade(ZgradaBasic zgrada)
        {
            InitializeComponent();
            this.zgrada = zgrada;
            upravnici = DTOManager.sviUpravniciZgradePregled(this.zgrada.ID);

            UpravniciGridView.DataSource = upravnici.Select(u => new { Ime = u.PunoIme, Obrazovanje = u.Obrazovanja.First().Zvanje, BrojLicence = u.Licence.First().BrLicence });
        }

        private void PrikaziUpravnikaDugme_Click(object sender, EventArgs e)
        {
            if (UpravniciGridView.SelectedRows.Count != 1)
            {
                MessageBox.Show("Izaberite jednog upravnika za prikaz.", "Izaberite upravnika", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            JedanZaposleni forma = new JedanZaposleni(upravnici[UpravniciGridView.SelectedRows[0].Index]);
            forma.ShowDialog();
        }

        private void DodajUpravnikaDugme_Click(object sender, EventArgs e)
        {
            NoviUpravnik forma = new(upravnici);
            forma.ShowDialog();

            if (!forma.Dodaj)
            {
                return;
            }

            zgrada.Upravnici.Add(forma.Novi);

            ZaposleniPregled upravnik = new ZaposleniPregled()
            {
                JMBG = forma.Novi.JMBG,
                PunoIme = $"{forma.Novi.LIme} ({forma.Novi.ImeRoditelja}) {forma.Novi.Prezime}",
                Adresa = forma.Novi.Adresa,
                DatumRodjenja = forma.Novi.DatumRodjenja,
                BrLicneKarte = forma.Novi.BrLicneKarte,
                MestoIzdLK = forma.Novi.MestoIzdLK,
                TipPosla = forma.Novi.TipPosla,
            };

            foreach (var broj in forma.Novi.BrojeviTelefona)
            {
                upravnik.BrojeviTelefona.Add(new TelefonPregled()
                {
                    Osoba = upravnik,
                    BrojTelefona = broj.BrojTelefona
                });
            }
            foreach (var obrazovanje in forma.Novi.Obrazovanja)
            {
                upravnik.Obrazovanja.Add(new ObrazovanjePregled()
                {
                    Upravnik = upravnik,
                    DatumSticanja = obrazovanje.DatumSticanja,
                    NazivInstitucije = obrazovanje.NazivInstitucije,
                    Zvanje = obrazovanje.Zvanje
                });
            }
            foreach (var licenca in forma.Novi.Licence)
            {
                upravnik.Licence.Add(new LicencaPregled()
                {
                    BrLicence = licenca.BrLicence,
                    DatumSticanja = licenca.DatumSticanja,
                    Izdavac = licenca.Izdavac,
                    Upravnik = upravnik
                });
            }

            upravnici.Add(upravnik);

            UpravniciGridView.DataSource = null;
            UpravniciGridView.DataSource = upravnici.Select(u => new { Ime = u.PunoIme, Obrazovanje = u.Obrazovanja.First().Zvanje, BrojLicence = u.Licence.First().BrLicence });
        }

        private void IzbrisiUpravnikaDugme_Click(object sender, EventArgs e)
        {
            if (UpravniciGridView.SelectedRows.Count != 1)
            {
                MessageBox.Show("Izaberite jednog upravnika za brisanje.", "Izaberite upravnika", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ZaposleniPregled upravnik = upravnici[UpravniciGridView.SelectedRows[0].Index];
            upravnici.Remove(upravnik);

            ZaposleniBasic z = DTOManager.vratiZaposlenog(upravnik.JMBG);
            zgrada.Upravnici.Remove(z);

            UpravniciGridView.DataSource = null;
            UpravniciGridView.DataSource = upravnici.Select(u => new { Ime = u.PunoIme, Obrazovanje = u.Obrazovanja.First().Zvanje, BrojLicence = u.Licence.First().BrLicence });
        }
    }
}
