using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZgradaLibrary.DTOs;

public class ObrazovanjePregled
{
    public int ID { get; set; }
    public ZaposleniPregled? Upravnik { get; set; }
    public string? Zvanje { get; set; }
    public DateTime DatumSticanja { get; set; }
    public string? NazivInstitucije { get; set; }

    public ObrazovanjePregled()
    {

    }

    public ObrazovanjePregled(int id, ZaposleniPregled upravnik, string zvanje, DateTime datumSticanja, string nazivInstitucije)
    {
        ID = id;
        Upravnik = upravnik;
        Zvanje = zvanje;
        DatumSticanja = datumSticanja;
        NazivInstitucije = nazivInstitucije;
    }

    internal ObrazovanjePregled(Obrazovanje? o)
    {
        if(o != null)
        {
            ID = o.ID;
            Upravnik = new(o.Upravnik);
            Zvanje = o.Zvanje;
            DatumSticanja = o.DatumSticanja;
            NazivInstitucije = o.NazivInstitucije;
        }
    }
}
