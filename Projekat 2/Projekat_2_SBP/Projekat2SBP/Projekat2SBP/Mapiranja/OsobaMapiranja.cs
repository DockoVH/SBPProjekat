using FluentNHibernate.Mapping;
using Projekat2SBP.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat2SBP.Mapiranja;

class OsobaMapiranja : ClassMap<Osoba>
{
    public OsobaMapiranja()
    {
        Table("OSOBA");

        Id(p => p.JMBG, "JMBG");

        Map(p => p.Adresa, "ADRESA");
        Map(p => p.LIme, "LIME");
        Map(p => p.ImeRoditelja, "IMERODITELJA");
        Map(p => p.Prezime, "PREZIME");
        Map(p => p.Tip, "TIP");

        HasMany(p => p.BrojeviTelefona)
            .KeyColumn("JMBGOSOBE")
            .Cascade.All()
            .Inverse();
    }
}
