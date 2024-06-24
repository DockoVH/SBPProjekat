using FluentNHibernate.Automapping;
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
    public partial class SkupstinaStanara : Form
    {
        private ZgradaBasic zgrada;
        private List<SkupstinaStanaraPregled> skupstinaStanara;
        public SkupstinaStanara()
        {
            InitializeComponent();
            zgrada = new();
            skupstinaStanara = new();
        }

        public SkupstinaStanara(ZgradaBasic z)
        {
            InitializeComponent();
            zgrada = z;
            skupstinaStanara = DTOManager.sviVlasniciPregled(zgrada.ID);
            SkupstinaDataGridView.DataSource = skupstinaStanara.Select(p => new { Vlasnik = p.Vlasnik.PunoIme, Funkcija = p.Funkcija });
        }

        private void PrikaziVlasnikaDugme_Click(object sender, EventArgs e)
        {
            if (SkupstinaDataGridView.SelectedRows.Count != 1)
            {
                MessageBox.Show("Izaberite jednog vlasnika za prikaz.", "Greška!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            VlasnikPregled pom = skupstinaStanara[SkupstinaDataGridView.SelectedRows[0].Index].Vlasnik;

            string[] delovi = pom.PunoIme.Split(' ');

            VlasnikBasic vlasnik = new VlasnikBasic()
            {
                JMBG = pom.JMBG,
                Adresa = pom.Adresa,
                LIme = delovi[0],
                ImeRoditelja = delovi[1].Substring(1, delovi[1].Length - 2),
                Prezime = delovi[2]
            };

            foreach (var broj in pom.BrojeviTelefona)
            {
                vlasnik.BrojeviTelefona.Add(new TelefonBasic()
                {
                    ID = broj.ID,
                    Osoba = vlasnik,
                    BrojTelefona = broj.BrojTelefona
                });
            }

            JedanVlasnik forma = new(vlasnik);
            forma.ShowDialog();

            DTOManager.izmeniVlasnika(vlasnik);
        }

        private void DodajVlasnikaDugme_Click(object sender, EventArgs e)
        {
            NoviVlasnik forma = new();
            forma.ShowDialog();

            if(!forma.Dodaj)
            {
                return;
            }

            zgrada.VlasniciStanova.Add(forma.Vlasnik);
            skupstinaStanara.Add(new SkupstinaStanaraPregled()
            {
                Vlasnik = new VlasnikPregled()
                {
                    JMBG = forma.Vlasnik.Vlasnik.JMBG
                },
                Zgrada = new ZgradaPregled()
                {
                    ID = zgrada.ID
                },
                Funkcija = forma.Vlasnik.Funkcija
            });

            SkupstinaDataGridView.DataSource = null;
            SkupstinaDataGridView.DataSource = skupstinaStanara.Select(p => new { Vlasnik = p.Vlasnik.PunoIme, Funkcija = p.Funkcija });
        }

        private void IzbrisiVlasnikaDugme_Click(object sender, EventArgs e)
        {
            if (SkupstinaDataGridView.SelectedRows.Count != 1)
            {
                MessageBox.Show("Izaberite jednog vlasnika za prikaz.", "Greška!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            zgrada.VlasniciStanova.RemoveAt(SkupstinaDataGridView.SelectedRows[0].Index);

            skupstinaStanara.RemoveAt(SkupstinaDataGridView.SelectedRows[0].Index);

            SkupstinaDataGridView.DataSource = null;
            SkupstinaDataGridView.DataSource = skupstinaStanara.Select(p => new { Vlasnik = p.Vlasnik.PunoIme, Funkcija = p.Funkcija });
        }
    }
}
