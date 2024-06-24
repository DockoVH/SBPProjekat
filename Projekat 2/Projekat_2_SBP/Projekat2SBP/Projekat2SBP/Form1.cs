using Projekat2SBP.Forme;

namespace Projekat2SBP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ZgradeDugme_Click(object sender, EventArgs e)
        {
            Form zgrade = new ZgradeForma();
            zgrade.ShowDialog();
        }

        private void ZaposleniDugme_Click(object sender, EventArgs e)
        {
            Form zaposleni = new ZaposleniForma();
            zaposleni.ShowDialog();
        }
    }
}
