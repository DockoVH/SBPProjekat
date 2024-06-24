using FluentNHibernate.Mapping;
using ZgradaLibrary.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZgradaLibrary.Mapiranja;

class LokalMapiranja : SubclassMap<Lokal>
{
    public LokalMapiranja()
    {
        Table("LOKAL");

        KeyColumn("ID");

        Map(p => p.ImeFirme, "IMEFIRME");
    }
}
