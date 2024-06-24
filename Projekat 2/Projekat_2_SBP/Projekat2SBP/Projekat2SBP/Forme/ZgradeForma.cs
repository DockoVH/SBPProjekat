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
    public partial class ZgradeForma : Form
    {
        List<ZgradaPregled> zgrade = DTOManager.sveZgrade();
        public ZgradeForma()
        {
            InitializeComponent();
            ZgradeGridView.DataSource = zgrade.Select(z => new { Adresa = z.Adresa, Upravnik = z.Upravnik.PunoIme, BrojSpratova = z.BrojSpratova });
        }

        private void PrikaziZgraduDugme_Click(object sender, EventArgs e)
        {
            if (ZgradeGridView.SelectedRows.Count != 1)
            {
                MessageBox.Show("Izaberite jednu zgradu za prikaz.", "Izaberite zgradu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            JednaZgrada forma = new(zgrade[ZgradeGridView.SelectedRows[0].Index]);
            forma.ShowDialog();
        }

        private void DodajZgraduDugme_Click(object sender, EventArgs e)
        {
            NovaZgrada forma = new();
            forma.ShowDialog();

            if (forma.Adresa.Length == 0)
            {
                return;
            }

            ZgradaBasic zgrada = new ZgradaBasic()
            {
                Adresa = forma.Adresa
            };

            int idZgrade = DTOManager.dodajZgradu(zgrada);
            if (idZgrade != -1)
            {
                ZgradaPregled pregled = DTOManager.vratiZgraduPregled(idZgrade);
                zgrade.Add(pregled);
            }

            ZgradeGridView.DataSource = null;
            ZgradeGridView.DataSource = zgrade.Select(z => new { Adresa = z.Adresa, Upravnik = z.Upravnik.PunoIme, BrojSpratova = z.BrojSpratova });
        }

        private void IzbrisiZgraduDugme_Click(object sender, EventArgs e)
        {
            if (ZgradeGridView.SelectedRows.Count != 1)
            {
                MessageBox.Show("Izaberite jednu zgradu za brisanje.", "Izaberite zgradu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DTOManager.obrisiZgradu(zgrade[ZgradeGridView.SelectedRows[0].Index].ID);
        }

        private void UpravniciDugme_Click(object sender, EventArgs e)
        {
            if (ZgradeGridView.SelectedRows.Count != 1)
            {
                MessageBox.Show("Izaberite jednu zgradu za prikaz.", "Izaberite zgradu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ZgradaBasic z = DTOManager.vratiZgradu(zgrade[ZgradeGridView.SelectedRows[0].Index].ID);

            UpravniciZgrade forma = new(z);
            forma.ShowDialog();

            DTOManager.izmeniZgradu(z);
        }

        private void UgovoriDugme_Click(object sender, EventArgs e)
        {
            if (ZgradeGridView.SelectedRows.Count != 1)
            {
                MessageBox.Show("Izaberite jednu zgradu za prikaz.", "Izaberite zgradu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ZgradaBasic z = DTOManager.vratiZgradu(zgrade[ZgradeGridView.SelectedRows[0].Index].ID);

            UgovoriForma forma = new(z);
            forma.ShowDialog();

            DTOManager.izmeniZgradu(z);
        }

        private void UlaziDugme_Click(object sender, EventArgs e)
        {
            if (ZgradeGridView.SelectedRows.Count != 1)
            {
                MessageBox.Show("Izaberite jednu zgradu za prikaz.", "Izaberite zgradu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ZgradaBasic z = DTOManager.vratiZgradu(zgrade[ZgradeGridView.SelectedRows[0].Index].ID);

            UlaziForma forma = new(z);
            forma.ShowDialog();

            DTOManager.izmeniZgradu(z);
        }

        private void LiftoviDugme_Click(object sender, EventArgs e)
        {
            if (ZgradeGridView.SelectedRows.Count != 1)
            {
                MessageBox.Show("Izaberite jednu zgradu za prikaz.", "Izaberite zgradu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ZgradaBasic z = DTOManager.vratiZgradu(zgrade[ZgradeGridView.SelectedRows[0].Index].ID);

            LiftoviForma forma = new(z);
            forma.ShowDialog();

            DTOManager.izmeniZgradu(z);
        }

        private void ProstoriDugme_Click(object sender, EventArgs e)
        {
            if (ZgradeGridView.SelectedRows.Count != 1)
            {
                MessageBox.Show("Izaberite jednu zgradu za prikaz.", "Izaberite zgradu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ZgradaBasic z = DTOManager.vratiZgradu(zgrade[ZgradeGridView.SelectedRows[0].Index].ID);

            ProstoriForma forma = new(z);
            forma.ShowDialog();
            DTOManager.izmeniZgradu(z);
        }

        private void VlasniciStanovaDugme_Click(object sender, EventArgs e)
        {
            if (ZgradeGridView.SelectedRows.Count != 1)
            {
                MessageBox.Show("Izaberite jednu zgradu za prikaz.", "Izaberite zgradu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ZgradaBasic z = DTOManager.vratiZgradu(zgrade[ZgradeGridView.SelectedRows[0].Index].ID);

            SkupstinaStanara forma = new(z);
            forma.ShowDialog();
            DTOManager.izmeniZgradu(z);
        }
    }
}