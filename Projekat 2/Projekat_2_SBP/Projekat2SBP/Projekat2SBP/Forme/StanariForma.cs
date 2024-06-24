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
    public partial class StanariForma : Form
    {
        private StanBasic stan;
        public StanariForma()
        {
            InitializeComponent();
        }

        public StanariForma(StanBasic s)
        {
            InitializeComponent();
            stan = s;

            foreach (var stanar in stan.Stanari)
            {
                StanariListBox.Items.Add(stanar.Ime);
            }
        }

        private void DodajStanaraDugme_Click(object sender, EventArgs e)
        {
            if (String.Compare(DodajStanaraDugme.Text, "Dodaj stanara", true) == 0)
            {
                ImeTextBox.Visible = true;
                DodajStanaraDugme.Text = "Potvrdi";
            }
            else
            {
                stan.Stanari.Add(new ImeStanaraBasic()
                {
                    Stan = stan,
                    Ime = ImeTextBox.Text
                });

                StanariListBox.Items.Add(ImeTextBox.Text);

                ImeTextBox.Visible = false;
                DodajStanaraDugme.Text = "Dodaj stanara";
            }
        }

        private void IzbrisiStanaraDugme_Click(object sender, EventArgs e)
        {
            if(StanariListBox.SelectedItems.Count != 1)
            {
                MessageBox.Show("Izaberite jednog stanara za brisanje.", "Greška!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            StanariListBox.Items.RemoveAt(StanariListBox.SelectedIndex);
            stan.Stanari.RemoveAt(StanariListBox.SelectedIndex);
        }
    }
}
