﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat2SBP.Entiteti;

public class Parking : Prostor
{
    public virtual string RegVozila { get; set; }

    public Parking()
    {
        
    }
}
