using FluentNHibernate.Mapping;
using ZgradaLibrary.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZgradaLibrary.Mapiranja;

class ZaposleniMapiranja : SubclassMap<Zaposleni>
{
    public ZaposleniMapiranja()
    {
        Table("ZAPOSLENI");

        KeyColumn("JMBG");

        Map(p => p.TipPosla, "TIPPOSLA");
        Map(p => p.DatumRodjenja)
            .Column("DATRODJENJA");
        Map(p => p.BrLicneKarte)
            .Column("BRLICNEKARTE");
        Map(p => p.MestoIzdLK)
            .Column("MESTOIZDLK");

        HasMany<Obrazovanje>(p => p.Obrazovanja)
            .KeyColumn("JMBGUPRAVNIKA")
            .Cascade.All()
            .Inverse();

        HasMany<Licenca>(p => p.Licence)
           .KeyColumn("JMBGUPRAVNIKA")
           .Cascade.All()
           .Inverse();

        HasManyToMany(p => p.UpravljaZgradama)
            .Table("ANGAZOVANJE")
            .ParentKeyColumn("JMBGUPRAVNIKA")
            .ChildKeyColumn("IDZGRADE")
            .Cascade.All();
    }
}
