using FluentNHibernate.Mapping;
using Projekat2SBP.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat2SBP.Mapiranja;

class UgovorMapiranja : ClassMap<Ugovor>
{
    public UgovorMapiranja()
    {
        Table("UGOVOR");

        Id(p => p.Sifra, "SIFRA").GeneratedBy.TriggerIdentity();

        Map(p => p.DatumPotpisa, "DATPOTPISA");
        Map(p => p.PeriodVazenja, "PERIODVAZENJA");

        References(p => p.Zgrada)
            .Column("IDZGRADE");
    }
}
