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
    public partial class NoviLift : Form
    {
        public LiftBasic Novi { get; set; }
        private LiftTip tipLifta;
        public bool Dodaj { get; set; }
        public NoviLift()
        {
            InitializeComponent();
            Novi = new LiftBasic();
            Dodaj = false;
        }

        public NoviLift(LiftTip tipLifta)
        {
            InitializeComponent();
            this.tipLifta = tipLifta;

            if (this.tipLifta == LiftTip.Teretni)
            {
                Novi = new LiftTeretniBasic();
                Novi.Tip = "Teretni";
            }
            else
            {
                Novi = new LiftZaLjudeBasic();
                Novi.Tip = "Za ljude";

                NosivostLabel.Text = "Kapacitet ljudi:";
            }

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
            if((ProizvodjacTextBox.Text.Length == 0) || NosivostTextBox.Text.Length == 0)
            {
                MessageBox.Show("Popunite sva polja.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Novi.DatPoslServisa = DatumServisaDateTimePicker.Value;
            Novi.DatPoslKvara = DatumKvaraDateTimePicker.Value;
            Novi.UkVanUpotrebe = (int)VanUpotrebeNumericUpDown.Value;
            Novi.Proizvodjac = ProizvodjacTextBox.Text;
            if(tipLifta == LiftTip.Teretni)
            {
                ((LiftTeretniBasic)Novi).Nosivost = Double.Parse(NosivostTextBox.Text);
            }
            else
            {
                ((LiftZaLjudeBasic)Novi).KapLjudi = Int32.Parse(NosivostTextBox.Text);
            }

            Dodaj = true;
            this.Close();
        }

        private void ProizvodjacTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void NosivostTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (String.Compare(NosivostLabel.Text, "Nosivost", true) == 0)
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
                {
                    e.Handled = true;
                }
                if((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
                {
                    e.Handled = true;
                }
            }
            else
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }
    }
}
