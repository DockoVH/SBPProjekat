using FluentNHibernate.Mapping;
using Projekat2SBP.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat2SBP.Mapiranja;

class LiftTeretniMapiranja : SubclassMap<LiftTeretni>
{
    public LiftTeretniMapiranja()
    {
        DiscriminatorValue("Teretni");

        Map(p => p.Nosivost, "NOSIVOST");
    }
}
