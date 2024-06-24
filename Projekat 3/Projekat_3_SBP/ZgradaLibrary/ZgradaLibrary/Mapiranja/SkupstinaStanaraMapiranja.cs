using FluentNHibernate.Mapping;
using ZgradaLibrary.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZgradaLibrary.Mapiranja;

class SkupstinaStanaraMapiranja : ClassMap<SkupstinaStanara>
{
    public SkupstinaStanaraMapiranja()
    {
        Table("SKUPSTINASTANARA");

        Id(p => p.ID, "ID").GeneratedBy.TriggerIdentity();

        Map(p => p.Funkcija, "FUNKCIJA");

        References(p => p.Zgrada, "IDZGRADE");
        References(p => p.Vlasnik, "JMBGVLASNIKA");
    }
}
