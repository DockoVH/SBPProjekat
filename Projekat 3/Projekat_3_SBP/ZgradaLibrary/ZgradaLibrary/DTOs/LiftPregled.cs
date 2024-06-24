using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZgradaLibrary.DTOs;

public class LiftPregled
{
    public int SerijskiBroj { get; set; }
    public DateTime DatPoslServisa { get; set; }
    public DateTime DatPoslKvara { get; set; }
    public int UkVanUpotrebe { get; set; }
    public string? Tip { get; set; }
    public string? Proizvodjac { get; set; }
    public ZgradaPregled? Zgrada { get; set; }

    public LiftPregled()
    {

    }

    public LiftPregled(int serijskiBroj, DateTime datPoslServisa, DateTime datPoslKvara, int ukVanUpotrebe, string proizvodjac, ZgradaPregled zgrada, string tip)
    {
        SerijskiBroj = serijskiBroj;
        DatPoslServisa = datPoslServisa;
        DatPoslKvara = datPoslKvara;
        UkVanUpotrebe = ukVanUpotrebe;
        Proizvodjac = proizvodjac;
        Zgrada = zgrada;
        Tip = tip;
    }

    internal LiftPregled(Lift? l)
    {
        if(l != null)
        {
            SerijskiBroj = l.SerijskiBroj;
            DatPoslServisa = l.DatPoslServisa;
            DatPoslKvara = l.DatPoslKvara;
            UkVanUpotrebe = l.UkVanUpotrebe;
            Proizvodjac = l.Proizvodjac;
            Zgrada = new(l.Zgrada);
            Tip = l.Tip;
        }
    }
}
