using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZgradaLibrary.DTOs;

public class LiftTeretniPregled : LiftPregled
{
    public double Nosivost { get; set; }

    public LiftTeretniPregled() : base()
    {

    }

    public LiftTeretniPregled(double nosivost, int serijskiBroj, DateTime datPoslServisa, DateTime datPoslKvara, int ukVanUpotrebe, string proizvodjac, ZgradaPregled zgrada, string tip) : base(serijskiBroj, datPoslServisa, datPoslKvara, ukVanUpotrebe, proizvodjac, zgrada, tip)
    {
        Nosivost = nosivost;
    }

    internal LiftTeretniPregled(LiftTeretni? l) : base(l)
    {
        if(l != null)
        {
            Nosivost = l.Nosivost;
        }
    }
}
