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
    public partial class UlaziForma : Form
    {
        private List<UlazPregled> ulazi;
        private ZgradaBasic zgrada;
        public UlaziForma()
        {
            InitializeComponent();
            ulazi = new();
            zgrada = new();
        }

        public UlaziForma(ZgradaBasic zgrada)
        {
            this.zgrada = zgrada;
            ulazi = DTOManager.sviUlazi(zgrada.ID);

            UlaziDataGridView.DataSource = ulazi.Select(p => new { RedniBroj = p.RBroj, Kamera = p.Kamera, PocetakRadnogVremena = p.PocetakRadnogVremena, KrajRadnogVremena = p.KrajRadnogVremena });
        }

        private void DodajUlazDugme_Click(object sender, EventArgs e)
        {
            NoviUlaz forma = new();
            forma.ShowDialog();

            if(!forma.Dodaj)
            {
                return;
            }

            forma.Novi.Zgrada = zgrada;
            zgrada.Ulazi.Add(forma.Novi);

            ulazi.Add(new UlazPregled()
            {
                Kamera = forma.Novi.Kamera,
                PocetakRadnogVremena = forma.Novi.PocetakRadnogVremena,
                KrajRadnogVremena = forma.Novi.KrajRadnogVremena,
                Zgrada = new ZgradaPregled()
                {
                    ID = zgrada.ID
                }
            });

            UlaziDataGridView.DataSource = null;
            UlaziDataGridView.DataSource = ulazi.Select(p => new { RedniBroj = p.RBroj, Kamera = p.Kamera, PocetakRadnogVremena = p.PocetakRadnogVremena, KrajRadnogVremena = p.KrajRadnogVremena });
        }

        private void IzbrisiUlazDugme_Click(object sender, EventArgs e)
        {
            if(UlaziDataGridView.SelectedRows.Count != 1)
            {
                MessageBox.Show("Izaberite jedan ulaz za brisanje.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            UlazPregled ulaz = ulazi[UlaziDataGridView.SelectedRows[0].Index];
            ulazi.Remove(ulaz);
            
            UlazBasic ul = DTOManager.vratiUlaz(ulaz.ID);
            zgrada.Ulazi.Remove(ul);

            UlaziDataGridView.DataSource = null;
            UlaziDataGridView.DataSource = ulazi.Select(p => new { RedniBroj = p.RBroj, Kamera = p.Kamera, PocetakRadnogVremena = p.PocetakRadnogVremena, KrajRadnogVremena = p.KrajRadnogVremena });
        }
    }
}
