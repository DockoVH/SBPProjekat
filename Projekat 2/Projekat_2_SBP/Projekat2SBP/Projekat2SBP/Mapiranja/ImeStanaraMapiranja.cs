using FluentNHibernate.Mapping;
using Projekat2SBP.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat2SBP.Mapiranja;

class ImeStanaraMapiranja : ClassMap<ImeStanara>
{
    public ImeStanaraMapiranja()
    {
        Table("IMESTANARA");

        Id(p => p.ID, "ID").GeneratedBy.TriggerIdentity();

        Map(p => p.Ime, "IME");

        References(x => x.Stan, "IDSTANA");
        References(x => x.Sprat, "IDSPRATA");
        References(x => x.Zgrada, "IDZGRADE");
    }
}
