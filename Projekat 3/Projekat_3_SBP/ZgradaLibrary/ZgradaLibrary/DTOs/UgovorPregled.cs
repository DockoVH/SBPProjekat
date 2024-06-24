using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZgradaLibrary.DTOs;

public class UgovorPregled
{
    public int Sifra { get; set; }
    public DateTime DatumPotpisivanja { get; set; }
    public int PeriodVazenja { get; set; }
    public ZgradaPregled? Zgrada { get; set; }

    public UgovorPregled()
    {

    }
    public UgovorPregled(int sifra, DateTime datumPotpisivanja, int periodVazenja, ZgradaPregled zgrada)
    {
        Sifra = sifra;
        DatumPotpisivanja = datumPotpisivanja;
        PeriodVazenja = periodVazenja;
        Zgrada = zgrada;
    }

    internal UgovorPregled(Ugovor? u)
    {
        if(u != null)
        {
            Sifra = u.Sifra;
            DatumPotpisivanja = u.DatumPotpisa;
            PeriodVazenja = u.PeriodVazenja;
            Zgrada = new(u.Zgrada);
        }
    }
}
