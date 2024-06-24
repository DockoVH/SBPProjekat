using FluentNHibernate.Mapping;
using ZgradaLibrary.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZgradaLibrary.Mapiranja;

class ObrazovanjeMapiranja : ClassMap<Obrazovanje>
{
    public ObrazovanjeMapiranja()
    {
        Table("OBRAZOVANJE");

        Id(p => p.ID, "ID").GeneratedBy.TriggerIdentity();

        Map(p => p.Zvanje, "ZVANJE");
        Map(p => p.DatumSticanja, "DATSTICANJA");
        Map(p => p.NazivInstitucije, "NAZIVINSTITUCIJE");

        References(p => p.Upravnik, "JMBGUPRAVNIKA");
    }
}
