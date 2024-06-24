using Projekat2SBP.Entiteti;
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
    public partial class IzmeniLicence : Form
    {
        private ZaposleniBasic upravnik;
        public IzmeniLicence()
        {
            InitializeComponent();
            upravnik = new();
        }

        public IzmeniLicence(ZaposleniBasic z)
        {
            InitializeComponent();
            upravnik = z;

            LicenceGridView.DataSource = upravnik.Licence.Select(l => new { BrojLicence = l.BrLicence, Izdvac = l.Izdavac, DatumSticanja = l.DatumSticanja });
        }

        private void DodajLicencuDugme_Click(object sender, EventArgs e)
        {
            NovaLicenca forma = new();
            forma.ShowDialog();

            if(!forma.Dodaj)
            {
                return;
            }

            forma.NovaLic.Upravnik = upravnik;
            upravnik.Licence.Add(forma.NovaLic);

            LicenceGridView.DataSource = null;
            LicenceGridView.DataSource = upravnik.Licence.Select(l => new { BrojLicence = l.BrLicence, Izdvac = l.Izdavac, DatumSticanja = l.DatumSticanja });
        }

        private void IzbrisiLicencuDugme_Click(object sender, EventArgs e)
        {
            if (LicenceGridView.SelectedRows.Count != 1)
            {
                MessageBox.Show("Izaberite jednu licencu za brisanje.", "Greška.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            upravnik.Licence.RemoveAt(LicenceGridView.SelectedRows[0].Index);

            LicenceGridView.DataSource = null;
            LicenceGridView.DataSource = upravnik.Licence.Select(l => new { BrojLicence = l.BrLicence, Izdvac = l.Izdavac, DatumSticanja = l.DatumSticanja });
        }
    }
}
