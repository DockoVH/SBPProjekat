using FluentNHibernate.Mapping;
using Projekat2SBP.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat2SBP.Mapiranja;

class LicencaMapiranja : ClassMap<Licenca>
{
    public LicencaMapiranja()
    {
        Table("LICENCA");

        Id(p => p.ID, "ID").GeneratedBy.TriggerIdentity();

        Map(p => p.BrLicence, "BRLICENCE");
        Map(p => p.Izdavac, "IZDAVAC");
        Map(p => p.DatumSticanja, "DATUMSTICANJA");

        References(p => p.Upravnik, "JMBGUPRAVNIKA");
    }
}
