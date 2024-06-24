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
    public partial class ProstoriForma : Form
    {
        private List<ProstorPregled> prostori;
        private ZgradaBasic zgrada;
        public ProstoriForma()
        {
            InitializeComponent();
        }

        public ProstoriForma(ZgradaBasic zgrada)
        {
            InitializeComponent();
            this.zgrada = zgrada;
            prostori = DTOManager.sviProstoriUZgradi(zgrada.ID);

            ProstoriDataGridView.DataSource = prostori.Select(p => new { RedniBroj = p.RBroj, Sprat = p.Sprat.RBroj, Tip = p.Tip });
        }

        private void PrikaziProstorDugme_Click(object sender, EventArgs e)
        {
            if (ProstoriDataGridView.SelectedRows.Count != 1)
            {
                MessageBox.Show("Izaberite jedan prostor za prikaz.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ProstorPregled p = prostori[ProstoriDataGridView.SelectedRows[0].Index];
            ProstorBasic prostor = DTOManager.vratiProstor(p.ID);
            JedanProstor forma = new(prostor);
            forma.ShowDialog();
        }

        private void IzbrisiProstorDugme_Click(object sender, EventArgs e)
        {
            if (ProstoriDataGridView.SelectedRows.Count != 1)
            {
                MessageBox.Show("Izaberite jedan prostor za brisanje.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ProstorPregled p = prostori[ProstoriDataGridView.SelectedRows[0].Index];
            prostori.Remove(p);

            ProstorBasic pr = DTOManager.vratiProstor(p.ID);
            zgrada.Prostori.Remove(pr);


            ProstoriDataGridView.DataSource = null;
            ProstoriDataGridView.DataSource = prostori.Select(p => new { RedniBroj = p.RBroj, Sprat = p.Sprat.RBroj, Tip = p.Tip });
        }

        private void DodajStanDugme_Click(object sender, EventArgs e)
        {
            NoviProstor forma = new(ProstorTip.Stan);
            forma.ShowDialog();

            if (forma.Dodaj)
            {
                zgrada.Prostori.Add(new StanBasic()
                {
                    Sprat = new SpratBasic()
                    {
                        RBroj = forma.Novi.Sprat.RBroj,
                        Zgrada = zgrada
                    },
                    Zgrada = zgrada,
                    Vlasnik = DTOManager.vratiVlasnika(((StanBasic)forma.Novi).Vlasnik.JMBG)
                });
            }
        }

        private void DodajLokalDugme_Click(object sender, EventArgs e)
        {
            NoviProstor forma = new(ProstorTip.Lokal);
            forma.ShowDialog();

            if (forma.Dodaj)
            {
                zgrada.Prostori.Add(new LokalBasic()
                {
                    Sprat = new SpratBasic()
                    {
                        RBroj = forma.Novi.Sprat.RBroj,
                        Zgrada = zgrada
                    },
                    Zgrada = zgrada,
                    ImeFirme = ((LokalBasic)forma.Novi).ImeFirme
                });
            }
        }

        private void DodajParkingDugme_Click(object sender, EventArgs e)
        {
            NoviProstor forma = new(ProstorTip.Parking);
            forma.ShowDialog();

            if (forma.Dodaj)
            {
                zgrada.Prostori.Add(new ParkingBasic()
                {
                    Sprat = new SpratBasic()
                    {
                        RBroj = forma.Novi.Sprat.RBroj,
                        Zgrada = zgrada
                    },
                    Zgrada = zgrada,
                    RegVozila = ((ParkingBasic)forma.Novi).RegVozila
                });
            }
        }
    }
}
