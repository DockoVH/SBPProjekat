using FluentNHibernate.Mapping;
using Projekat2SBP.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat2SBP.Mapiranja;

class TelefonMapiranja : ClassMap<Telefon>
{
    public TelefonMapiranja()
    {
        Table("TELEFON");

        Id(p => p.ID, "ID").GeneratedBy.TriggerIdentity();

        Map(p => p.BrojTelefona, "BROJ");

        References(p => p.Osoba, "JMBGOSOBE");
    }
}
