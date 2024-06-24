using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Projekat2SBP.Enums;

namespace Projekat2SBP.Forme
{
    public partial class LiftoviForma : Form
    {
        private List<LiftPregled> liftovi;
        private ZgradaBasic zgrada;
        public LiftoviForma()
        {
            InitializeComponent();
        }

        public LiftoviForma(ZgradaBasic zgrada)
        {
            InitializeComponent();
            this.zgrada = zgrada;
            liftovi = DTOManager.sviLiftoviUZgradi(zgrada.ID);

            LiftoviDataGridView.DataSource = liftovi.Select(p => new { SerijskiBroj = p.SerijskiBroj, Proizvodjac = p.Proizvodjac, Tip = p.Tip });
        }

        private void PrikaziLiftDugme_Click(object sender, EventArgs e)
        {
            if (LiftoviDataGridView.SelectedRows.Count != 1)
            {
                MessageBox.Show("Izaberite jedan lift za prikaz.", "Greška!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            JedanLift forma = new(liftovi[LiftoviDataGridView.SelectedRows[0].Index]);
            forma.ShowDialog();
        }

        private void IzbrisiLiftDugme_Click(object sender, EventArgs e)
        {
            if (LiftoviDataGridView.SelectedRows.Count != 1)
            {
                MessageBox.Show("Izaberite jedan lift za prikaz.", "Greška!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            LiftPregled lift = liftovi[LiftoviDataGridView.SelectedRows[0].Index];
            LiftBasic l = DTOManager.vratiLift(lift.SerijskiBroj);
            zgrada.Liftovi.Remove(l);
            liftovi.Remove(lift);

            LiftoviDataGridView.DataSource = null;
            LiftoviDataGridView.DataSource = liftovi.Select(p => new { SerijskiBroj = p.SerijskiBroj, Proizvodjac = p.Proizvodjac, Tip = p.Tip });
        }

        private void DodajLiftZaLjudeDugme_Click(object sender, EventArgs e)
        {
            NoviLift forma = new(LiftTip.ZaLjude);
            forma.ShowDialog();

            if(forma.Dodaj)
            {
                forma.Novi.Zgrada = zgrada;

                zgrada.Liftovi.Add(forma.Novi);
            }
        }

        private void DodajLiftTeretniDugme_Click(object sender, EventArgs e)
        {
            NoviLift forma = new(LiftTip.Teretni);
            forma.ShowDialog();

            if(forma.Dodaj)
            {
                forma.Novi.Zgrada = zgrada;

                zgrada.Liftovi.Add(forma.Novi);
            }
        }
    }
}
