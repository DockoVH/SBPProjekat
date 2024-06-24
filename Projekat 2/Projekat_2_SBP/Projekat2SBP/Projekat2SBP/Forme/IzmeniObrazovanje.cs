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
    public partial class IzmeniObrazovanje : Form
    {
        private ZaposleniBasic upravnik;
        public IzmeniObrazovanje()
        {
            InitializeComponent();
            upravnik = new();
        }

        public IzmeniObrazovanje(ZaposleniBasic z)
        {
            InitializeComponent();
            upravnik = z;

            ObrazovanjaGridView.DataSource = upravnik.Obrazovanja.Select(o => new { Zvanje = o.Zvanje, DatumSticanja = o.DatumSticanja, NazivInstitucije = o.NazivInstitucije });
        }

        private void Dodaj_Click(object sender, EventArgs e)
        {
            NovoObrazovanje forma = new();

            if (!forma.Dodaj)
            {
                return;
            }

            forma.novoObrazovanje.Upravnik = upravnik;
            upravnik.Obrazovanja.Add(forma.novoObrazovanje);

            ObrazovanjaGridView.DataSource = null;
            ObrazovanjaGridView.DataSource = upravnik.Obrazovanja.Select(o => new { Zvanje = o.Zvanje, DatumSticanja = o.DatumSticanja, NazivInstitucije = o.NazivInstitucije });
        }

        private void IzbrisiDugme_Click(object sender, EventArgs e)
        {
            if(ObrazovanjaGridView.SelectedRows.Count != 1)
            {
                MessageBox.Show("Izaberite jedno obrazovanje za brisanje.", "Greška.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            upravnik.Obrazovanja.RemoveAt(ObrazovanjaGridView.SelectedRows[0].Index);

            ObrazovanjaGridView.DataSource = null;
            ObrazovanjaGridView.DataSource = upravnik.Obrazovanja.Select(o => new { Zvanje = o.Zvanje, DatumSticanja = o.DatumSticanja, NazivInstitucije = o.NazivInstitucije });
        }
    }
}
