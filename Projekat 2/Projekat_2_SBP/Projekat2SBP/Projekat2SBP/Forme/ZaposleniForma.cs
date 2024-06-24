using NHibernate.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace Projekat2SBP.Forme
{
    public partial class ZaposleniForma : Form
    {
        List<ZaposleniPregled> zaposleni = DTOManager.sviZaposleni();

        public ZaposleniForma()
        {
            InitializeComponent();
            ZaposleniGridView.DataSource = zaposleni.Select(z => new { JMBG = z.JMBG, PunoIme = z.PunoIme, Adresa = z.Adresa, TipPosla = z.TipPosla }).ToList();

            int pom = ZaposleniGridView.RowHeadersWidth;
            foreach (DataGridViewColumn col in ZaposleniGridView.Columns)
            {
                pom += col.Width + ZaposleniGridView.Margin.Horizontal;
            }

            ZaposleniGridView.Width = pom + 40;
            this.Width = ZaposleniGridView.Width + PrikaziZaposlenogDugme.Width + 45;
        }

        private void PrikaziZaposlenogDugme_Click(object sender, EventArgs e)
        {
            if (ZaposleniGridView.SelectedRows.Count != 1)
            {
                MessageBox.Show("Izaberite jednog zaposlenog za prikaz.", "Greška!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ZaposleniPregled z = (zaposleni.Select(p => p).Where(p => p.JMBG == ZaposleniGridView.SelectedRows[0].Cells[0].Value.ToString())).First();
            JedanZaposleni forma = new(z);
            forma.ShowDialog();
        }

        private void DodajZaposlenogDugme_Click(object sender, EventArgs e)
        {
            NoviZaposleni forma = new();
            forma.ShowDialog();

            if (forma.NoviRadnik == null)
            {
                return;
            }

            ZaposleniBasic novi = forma.NoviRadnik;
            DTOManager.dodajZaposlenog(novi);
            ZaposleniPregled noviPregled = new ZaposleniPregled()
            {
                JMBG = novi.JMBG,
                Adresa = novi.Adresa,
                PunoIme = $"{novi.LIme} ({novi.ImeRoditelja}) {novi.Prezime}",
                DatumRodjenja = novi.DatumRodjenja,
                BrLicneKarte = novi.BrLicneKarte,
                MestoIzdLK = novi.MestoIzdLK,
                TipPosla = novi.TipPosla,
            };

            foreach (ObrazovanjeBasic obr in novi.Obrazovanja)
            {
                noviPregled.Obrazovanja.Add(new ObrazovanjePregled()
                {
                    DatumSticanja = obr.DatumSticanja,
                    NazivInstitucije = obr.NazivInstitucije,
                    Zvanje = obr.Zvanje,
                    Upravnik = noviPregled
                });
            }

            foreach (LicencaBasic lic in novi.Licence)
            {
                noviPregled.Licence.Add(new LicencaPregled()
                {
                    Upravnik = noviPregled,
                    BrLicence = lic.BrLicence,
                    DatumSticanja = lic.DatumSticanja,
                    Izdavac = lic.Izdavac
                });
            }

            foreach (ZgradaBasic zgrada in novi.UpravljaZgradama)
            {
                noviPregled.Zgrade.Add(new ZgradaPregled()
                {
                    ID = zgrada.ID
                });
            }

            foreach (TelefonBasic t in novi.BrojeviTelefona)
            {
                noviPregled.BrojeviTelefona.Add(new TelefonPregled()
                {
                    Osoba = new OsobaPregled()
                    {
                        JMBG = t.Osoba.JMBG
                    },
                    BrojTelefona = t.BrojTelefona
                });
            }

            zaposleni.Add(noviPregled);

            ZaposleniGridView.DataSource = null;
            ZaposleniGridView.DataSource = zaposleni.Select(z => new { JMBG = z.JMBG, PunoIme = z.PunoIme, Adresa = z.Adresa, TipPosla = z.TipPosla }).ToList();
        }

        private void IzbrisiZaposlenogDugme_Click(object sender, EventArgs e)
        {
            if (ZaposleniGridView.SelectedRows.Count != 1)
            {
                MessageBox.Show("Izaberite jednog zaposlenog kog želite da izbrišete.", "Greška!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ZaposleniPregled z = (zaposleni.Select(p => p).Where(p => p.JMBG == ZaposleniGridView.SelectedRows[0].Cells[0].Value.ToString())).First();
            zaposleni.Remove(z);
            DTOManager.obrisiZaposlenog(z.JMBG);

            ZaposleniGridView.DataSource = null;
            ZaposleniGridView.DataSource = zaposleni.Select(z => new { JMBG = z.JMBG, PunoIme = z.PunoIme, Adresa = z.Adresa, TipPosla = z.TipPosla }).ToList();
        }

        private void IzmeniZaposlenogDugme_Click(object sender, EventArgs e)
        {
            if (ZaposleniGridView.SelectedRows.Count != 1)
            {
                MessageBox.Show("Izaberite jednog zaposlenog kog želite da izmenite.", "Greška!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ZaposleniPregled z = (zaposleni.Select(p => p).Where(p => p.JMBG == ZaposleniGridView.SelectedRows[0].Cells[0].Value.ToString())).First();

            ZaposleniBasic za = DTOManager.vratiZaposlenog(z.JMBG);

            IzmeniZaposlenog forma = new(za);
            forma.ShowDialog();
            DTOManager.izmeniZaposlenog(za);
        }
    }
}
