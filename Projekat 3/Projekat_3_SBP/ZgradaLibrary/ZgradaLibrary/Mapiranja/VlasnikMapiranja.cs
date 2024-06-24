using FluentNHibernate.Mapping;
using ZgradaLibrary.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZgradaLibrary.Mapiranja;

class VlasnikMapiranja : SubclassMap<Vlasnik>
{
    public VlasnikMapiranja()
    {
        Table("VLASNIK");

        KeyColumn("JMBG");
    }
}
