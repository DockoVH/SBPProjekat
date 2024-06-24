using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projekat2SBP.Entiteti;
using FluentNHibernate.Mapping;

namespace Projekat2SBP.Mapiranja;

class ZgradaMapiranja : ClassMap<Zgrada>
{
    public ZgradaMapiranja()
    {
        Table("ZGRADA");

        Id(p => p.ID, "ID").GeneratedBy.TriggerIdentity();

        Map(p => p.Adresa, "ADRESA");

        HasManyToMany(p => p.Upravnici)
            .Table("ANGAZOVANJE")
            .ParentKeyColumn("IDZGRADE")
            .ChildKeyColumn("JMBGUPRAVNIKA")
            .Inverse()
            .Cascade.All();

        HasMany(p => p.Ugovori)
            .KeyColumn("IDZGRADE")
            .Inverse()
            .Cascade.All();

        HasMany(p => p.Ulazi)
            .KeyColumn("IDZGRADE")
            .Inverse()
            .Cascade.All();

        HasMany(p => p.Liftovi)
            .KeyColumn("IDZGRADE")
            .Inverse()
            .Cascade.All();

        HasMany(p => p.Spratovi)
            .KeyColumn("IDZGRADE")
            .Inverse()
            .Cascade.All();

        HasMany(p => p.Prostori)
            .KeyColumn("IDZGRADE")
            .Inverse()
            .Cascade.All();

        HasMany(p => p.VlasniciStanova)
            .KeyColumn("IDZGRADE")
            .Inverse()
            .Cascade.All();
    }
}
