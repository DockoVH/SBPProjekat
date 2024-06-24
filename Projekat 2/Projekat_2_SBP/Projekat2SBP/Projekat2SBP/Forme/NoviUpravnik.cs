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
    public partial class NoviUpravnik : Form
    {
        public ZaposleniBasic Novi { get; set; }
        private List<ZaposleniPregled> sviUpravnici;
        public bool Dodaj { get; set; }
        public NoviUpravnik()
        {
            InitializeComponent();
            Dodaj = false;
        }

        public NoviUpravnik(List<ZaposleniPregled> upravniciZgrade)
        {
            InitializeComponent();

            sviUpravnici = DTOManager.sviUpravniciPregled();
            HashSet<string> MatBrojevi = new HashSet<string>(upravniciZgrade.Select(p => p.JMBG));
            sviUpravnici = sviUpravnici.Where(p => !MatBrojevi.Contains(p.JMBG)).ToList();

            foreach (ZaposleniPregled upravnik in sviUpravnici)
            {
                UpravnikComboBox.Items.Add($"{upravnik.JMBG} {upravnik.PunoIme}");
            }
        }

        private void DodajDugme_Click(object sender, EventArgs e)
        {
            if(UpravnikComboBox.SelectedItem == null)
            {
                MessageBox.Show("Izaberite upravnika za dodavanje.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ZaposleniPregled z = sviUpravnici[UpravnikComboBox.SelectedIndex];
            Novi = DTOManager.vratiZaposlenog(z.JMBG);

            Dodaj = true;
            this.Close();
        }

        private void OtkaziDugme_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Da li želite da odustanete?", "Odustani?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                Dodaj = false;
                this.Close();
            }
        }
    }
}
