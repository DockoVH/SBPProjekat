using FluentNHibernate.Mapping;
using FluentNHibernate.Utils;
using ZgradaLibrary.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZgradaLibrary.Mapiranja;

class ProstorMapiranja : ClassMap<Prostor>
{
    public ProstorMapiranja()
    {
        Table("PROSTOR");

        Id(p => p.ID, "ID").GeneratedBy.TriggerIdentity();

        Map(p => p.RBroj, "RBROJ");
        Map(p => p.Tip, "TIP");

        References(p => p.Zgrada, "IDZGRADE");
        References(p => p.Sprat, "IDSPRATA");
    }
}
