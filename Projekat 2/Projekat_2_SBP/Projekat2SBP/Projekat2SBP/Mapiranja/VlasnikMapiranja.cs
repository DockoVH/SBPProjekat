using FluentNHibernate.Mapping;
using Projekat2SBP.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat2SBP.Mapiranja;

class VlasnikMapiranja : SubclassMap<Vlasnik>
{
    public VlasnikMapiranja()
    {
        Table("VLASNIK");

        KeyColumn("JMBG");
    }
}
