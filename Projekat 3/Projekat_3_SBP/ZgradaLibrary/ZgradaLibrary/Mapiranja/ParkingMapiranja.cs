using FluentNHibernate.Mapping;
using ZgradaLibrary.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZgradaLibrary.Mapiranja;

class ParkingMapiranja : SubclassMap<Parking>
{
    public ParkingMapiranja()
    {
        Table("PARKING");

        KeyColumn("ID");

        Map(p => p.RegVozila, "REGVOZILA");
    }
}
