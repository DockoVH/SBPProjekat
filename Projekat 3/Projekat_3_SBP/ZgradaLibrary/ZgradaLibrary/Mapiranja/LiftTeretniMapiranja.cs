using FluentNHibernate.Mapping;
using ZgradaLibrary.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZgradaLibrary.Mapiranja;

class LiftTeretniMapiranja : SubclassMap<LiftTeretni>
{
    public LiftTeretniMapiranja()
    {
        DiscriminatorValue("Teretni");

        Map(p => p.Nosivost, "NOSIVOST");
    }
}
