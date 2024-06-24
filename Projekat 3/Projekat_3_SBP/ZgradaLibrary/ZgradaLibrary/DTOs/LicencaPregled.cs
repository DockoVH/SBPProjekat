using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZgradaLibrary.DTOs;

public class LicencaPregled
{
    public int ID { get; set; }
    public ZaposleniPregled? Upravnik { get; set; }
    public int BrLicence { get; set; }
    public string? Izdavac { get; set; }
    public DateTime DatumSticanja { get; set; }

    public LicencaPregled()
    {

    }

    public LicencaPregled(int id, ZaposleniPregled upravnik, int brLicence, string izdavac, DateTime datumSticanja)
    {
        ID = id;
        Upravnik = upravnik;
        BrLicence = brLicence;
        Izdavac = izdavac;
        DatumSticanja = datumSticanja;
    }

    internal LicencaPregled(Licenca? l)
    {
        if(l != null)
        {
            ID = l.ID;
            Upravnik = new(l.Upravnik);
            BrLicence = l.BrLicence;
            Izdavac = l.Izdavac;
            DatumSticanja = l.DatumSticanja;
        }
    }
}
