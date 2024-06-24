using FluentNHibernate.Mapping;
using ZgradaLibrary.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZgradaLibrary.Mapiranja;

class LiftMapiranja : ClassMap<Lift>
{
    public LiftMapiranja()
    {
        Table("LIFT");

        Id(p => p.SerijskiBroj, "SERIJSKIBROJ");

        DiscriminateSubClassesOnColumn("TIP");
        
        Map(p => p.DatPoslServisa, "DATPOSLSERV");
        Map(p => p.DatPoslKvara, "DATPOSLKVARA");
        Map(p => p.UkVanUpotrebe, "UKVANUPOTREBE");
        Map(p => p.Proizvodjac, "PROIZVODJAC");

        References(p => p.Zgrada)
            .Column("IDZGRADE");

    }
}
