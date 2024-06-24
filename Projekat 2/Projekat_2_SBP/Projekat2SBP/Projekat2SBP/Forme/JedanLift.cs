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
    public partial class JedanLift : Form
    {
        public JedanLift()
        {
            InitializeComponent();
        }

        public JedanLift(LiftPregled lift)
        {
            InitializeComponent();

            SerijskiBrojTextBox.Text = lift.SerijskiBroj.ToString();
            DatKvaraDateTimePicker.Value = lift.DatPoslKvara;
            DatServisaDateTimePicker.Value = lift.DatPoslServisa;
            VanUpotrebeTextBox.Text = lift.UkVanUpotrebe.ToString();
            ProizvodjacTextBox.Text = lift.Proizvodjac;
            TipTextBox.Text = lift.Tip;

            if(String.Compare(lift.Tip, "Teretni", true) == 0)
            {
                NosivostTextBox.Text = ((LiftTeretniPregled)lift).Nosivost.ToString();
            }
            else
            {
                NosivostTextBox.Text = ((LiftZaLjudePregled)lift).KapLjudi.ToString();
                NosivostLabel.Text = "Kapacitet ljudi:";
            }
        }
    }
}
