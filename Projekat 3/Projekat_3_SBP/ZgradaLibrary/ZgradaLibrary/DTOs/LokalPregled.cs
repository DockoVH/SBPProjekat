using FluentNHibernate.Mapping.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZgradaLibrary.DTOs;

public class LokalPregled : ProstorPregled
{
    public string? ImeFirme { get; set; }

    public LokalPregled() : base()
    {

    }
    public LokalPregled(int id, string imeFirme, int rBroj, SpratPregled sprat, ZgradaPregled zgrada, string tip) : base(id, rBroj, sprat, zgrada, tip)
    {
        ImeFirme = imeFirme;
    }

    internal LokalPregled(Lokal? l) : base(l)
    {
        if(l != null)
        {
            ImeFirme = l.ImeFirme;
        }
    }
}
