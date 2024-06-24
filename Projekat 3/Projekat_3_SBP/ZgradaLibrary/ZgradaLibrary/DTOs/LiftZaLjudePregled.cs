using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZgradaLibrary.DTOs;

public class LiftZaLjudePregled : LiftPregled
{
    public int KapLjudi { get; set; }

    public LiftZaLjudePregled() : base()
    {

    }

    public LiftZaLjudePregled(int kapLjudi, int serijskiBroj, DateTime datPoslServisa, DateTime datPoslKvara, int ukVanUpotrebe, string proizvodjac, ZgradaPregled zgrada, string tip) : base(serijskiBroj, datPoslServisa, datPoslKvara, ukVanUpotrebe, proizvodjac, zgrada, tip)
    {
        KapLjudi = kapLjudi;
    }

    internal LiftZaLjudePregled(LiftZaLjude? l) : base(l) 
    {
        if (l != null)
        {
            KapLjudi = l.KapLjudi;
        }
    }
}
