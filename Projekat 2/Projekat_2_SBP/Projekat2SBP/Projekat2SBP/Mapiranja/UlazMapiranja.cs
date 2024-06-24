using FluentNHibernate.Mapping;
using Projekat2SBP.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat2SBP.Mapiranja;

class UlazMapiranja : ClassMap<Ulaz>
{
    public UlazMapiranja()
    {
        Table("ULAZ");

        Id(p => p.ID, "ID").GeneratedBy.TriggerIdentity();

        Map(p => p.RBroj, "RBROJ");
        Map(p => p.Kamera, "KAMERA");
        Map(p => p.PocetakRadnogVremena, "POCETAKRADNOGVREMENA");
        Map(p => p.KrajRadnogVremena, "KRAJRADNOGVREMENA");

        References(p => p.Zgrada, "IDZGRADE");
    }
}
