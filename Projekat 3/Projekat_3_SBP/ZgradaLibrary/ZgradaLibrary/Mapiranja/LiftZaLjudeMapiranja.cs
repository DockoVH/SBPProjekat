using FluentNHibernate.Mapping;
using ZgradaLibrary.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZgradaLibrary.Mapiranja;

class LiftZaLjudeMapiranja : SubclassMap<LiftZaLjude>
{
    public LiftZaLjudeMapiranja()
    {
        DiscriminatorValue("Za ljude");

        Map(p => p.KapLjudi, "KAPLJUDI");
    }
}
