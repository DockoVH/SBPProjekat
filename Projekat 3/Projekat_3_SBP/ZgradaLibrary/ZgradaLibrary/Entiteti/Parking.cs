using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZgradaLibrary.Entiteti;

internal class Parking : Prostor
{
    public virtual string? RegVozila { get; set; }

    public Parking()
    {
        
    }
}
