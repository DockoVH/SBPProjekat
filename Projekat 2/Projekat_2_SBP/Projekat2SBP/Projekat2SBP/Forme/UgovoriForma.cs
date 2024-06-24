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
    public partial class UgovoriForma : Form
    {
        private List<UgovorPregled> ugovori;
        private ZgradaBasic zgrada;
        public UgovoriForma()
        {
            InitializeComponent();
            ugovori = new();
            zgrada = new();
        }

        public UgovoriForma(ZgradaBasic zgrada)
        {
            InitializeComponent();
            this.zgrada = zgrada;
            ugovori = DTOManager.sviUgovori(zgrada.ID);

            UgovoriDataGridView.DataSource = ugovori.Select(p => new { Sifra = p.Sifra, DatumPotpisivanja = p.DatumPotpisivanja, PeriodVazenja = p.PeriodVazenja });
        }

        private void IzbrisiUgovorDugme_Click(object sender, EventArgs e)
        {
            if(UgovoriDataGridView.SelectedRows.Count != 1)
            {
                MessageBox.Show("Izaberite jedan ugovor za brisanje.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            UgovorPregled ug = ugovori[UgovoriDataGridView.SelectedRows[0].Index];
            ugovori.Remove(ug);

            UgovorBasic u = DTOManager.vratiUgovor(ug.Sifra);
            zgrada.Ugovori.Remove(u);

            UgovoriDataGridView.DataSource = null;
            UgovoriDataGridView.DataSource = ugovori.Select(p => new { Sifra = p.Sifra, DatumPotpisivanja = p.DatumPotpisivanja, PeriodVazenja = p.PeriodVazenja });
        }

        private void DodajUgovorDugme_Click(object sender, EventArgs e)
        {
            NoviUgovor forma = new();
            forma.ShowDialog();

            if(!forma.Dodaj)
            {
                return;
            }

            forma.Novi.Zgrada = this.zgrada;

            ugovori.Add(new UgovorPregled()
            {
                DatumPotpisivanja = forma.Novi.DatumPotpisivanja,
                PeriodVazenja = forma.Novi.PeriodVazenja,
                Zgrada = new ZgradaPregled()
                {
                    ID = zgrada.ID
                }
            });

            zgrada.Ugovori.Add(forma.Novi);

            UgovoriDataGridView.DataSource = null;
            UgovoriDataGridView.DataSource = ugovori.Select(p => new { Sifra = p.Sifra, DatumPotpisivanja = p.DatumPotpisivanja, PeriodVazenja = p.PeriodVazenja });
        }
    }
}
