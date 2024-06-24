using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZgradaLibrary.DTOs;

public class VlasnikPregled : OsobaPregled
{
    public VlasnikPregled() : base()
    {

    }

    public VlasnikPregled(string jMBG, string adresa, string punoIme) : base(jMBG, adresa, punoIme)
    {

    }

    internal VlasnikPregled(Vlasnik? v) : base(v)
    {

    }
}
