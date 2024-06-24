using FluentNHibernate.Mapping;
using ZgradaLibrary.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZgradaLibrary.Mapiranja;

class StanMapiranja : SubclassMap<Stan>
{
    public StanMapiranja()
    {
        Table("STAN");

        KeyColumn("ID");

        References(p => p.Vlasnik, "JMBGVLASNIKA").Unique();

        HasMany(p => p.Stanari)
            .KeyColumns.Add("IDSTANA")
            .Cascade.All()
            .Inverse();
    }
}
