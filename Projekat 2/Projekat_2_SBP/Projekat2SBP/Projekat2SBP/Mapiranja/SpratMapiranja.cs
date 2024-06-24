using FluentNHibernate.Mapping;
using Projekat2SBP.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat2SBP.Mapiranja;

class SpratMapiranja : ClassMap<Sprat>
{
    public SpratMapiranja()
    {
        Table("SPRAT");

        Id(p => p.ID, "ID").GeneratedBy.TriggerIdentity();

        Map(p => p.RBroj, "RBROJ");

        References(p => p.Zgrada, "IDZGRADE");

        HasMany(p => p.Prostori)
            .KeyColumn("IDSPRATA")
            .Cascade.All()
            .Inverse();
    }
}
