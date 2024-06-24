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
    public partial class NoviUgovor : Form
    {
        public UgovorBasic Novi { get; set; }
        public bool Dodaj { get; set; }
        public NoviUgovor()
        {
            InitializeComponent();
            Dodaj = false;
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

        private void DodajDugme_Click(object sender, EventArgs e)
        {
            if(PeriodVazenjaUpDown.Value == 0)
            {
                MessageBox.Show("Unesite period važenja ugovora.", "Period važenja?", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Novi.DatumPotpisivanja = DatumPotpisivanjaDateTimePicker.Value;
            Novi.PeriodVazenja = (int)PeriodVazenjaUpDown.Value;

            Dodaj = true;
            this.Close();
        }
    }
}
