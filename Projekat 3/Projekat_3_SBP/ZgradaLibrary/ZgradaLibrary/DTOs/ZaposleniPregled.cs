using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZgradaLibrary.DTOs;

public class ZaposleniPregled : OsobaPregled
{
    public DateTime DatumRodjenja { get; set; }
    public string? BrLicneKarte { get; set; }
    public string? MestoIzdLK { get; set; }
    public string? TipPosla { get; set; }
    public List<ObrazovanjePregled>? Obrazovanja { get; set; }
    public List<LicencaPregled>? Licence { get; set; }
    public List<ZgradaPregled>? Zgrade { get; set; }

    public ZaposleniPregled() : base()
    {

    }
    public ZaposleniPregled(DateTime datumRodjenja, string brLicneKarte, string mestoIzdLK, string tipPosla, string jMBG, string adresa, string punoIme) : base(jMBG, adresa, punoIme)
    {
        DatumRodjenja = datumRodjenja;
        BrLicneKarte = brLicneKarte;
        MestoIzdLK = mestoIzdLK;
        TipPosla = tipPosla;
        Obrazovanja = new();
        Licence = new();
        Zgrade = new();
    }

    internal ZaposleniPregled(Zaposleni? z) : base(z)
    {
        if(z != null)
        {
            DatumRodjenja = z.DatumRodjenja;
            BrLicneKarte = z.BrLicneKarte;
            MestoIzdLK = z.MestoIzdLK;
            TipPosla = z.TipPosla;
            Obrazovanja = new();
            Licence = new();
            Zgrade = new();

            foreach(Obrazovanje o in z.Obrazovanja)
            {
                Obrazovanja.Add(new ObrazovanjePregled(o));
            }

            foreach (Licenca l in z.Licence)
            {
                Licence.Add(new LicencaPregled(l));
            }

            foreach(Zgrada zg in z.UpravljaZgradama)
            {
                Zgrade.Add(new ZgradaPregled(zg));
            }
        }
    }
}
