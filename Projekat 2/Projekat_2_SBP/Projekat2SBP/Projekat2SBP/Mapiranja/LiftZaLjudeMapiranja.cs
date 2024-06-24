using FluentNHibernate.Mapping;
using Projekat2SBP.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat2SBP.Mapiranja;

class LiftZaLjudeMapiranja : SubclassMap<LiftZaLjude>
{
    public LiftZaLjudeMapiranja()
    {
        DiscriminatorValue("Za ljude");

        Map(p => p.KapLjudi, "KAPLJUDI");
    }
}
