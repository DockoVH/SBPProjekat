using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZgradaLibrary.DTOs;

public class StanPregled : ProstorPregled
{
    public VlasnikPregled? Vlasnik { get; set; }
    public List<ImeStanaraPregled>? Stanari { get; set; }

    public StanPregled() : base()
    {

    }
    public StanPregled(int id, VlasnikPregled vlasnik, int rBroj, SpratPregled sprat, ZgradaPregled zgrada, string tip) : base(id, rBroj, sprat, zgrada, tip)
    {
        Vlasnik = vlasnik;
        Stanari = new();
    }

    internal StanPregled(Stan? s) : base(s)
    {
        if(s != null)
        {
            Vlasnik = new(s.Vlasnik);
            Stanari = new();

            foreach(ImeStanara i in s.Stanari)
            {
                Stanari.Add(new ImeStanaraPregled(i));
            }
        }
    }
}
