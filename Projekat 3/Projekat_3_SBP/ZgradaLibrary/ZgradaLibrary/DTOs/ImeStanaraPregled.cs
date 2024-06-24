using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZgradaLibrary.DTOs;

public class ImeStanaraPregled
{
    public int ID { get; set; }
    public StanPregled? Stan { get; set; }
    public string? Ime { get; set; }

    public ImeStanaraPregled()
    {

    }

    public ImeStanaraPregled(int id, StanPregled stan, string ime)
    {
        ID = id;
        Stan = stan;
        Ime = ime;
    }

    internal ImeStanaraPregled(ImeStanara? i)
    {
        if(i != null)
        {
            ID = i.ID;
            Stan = new(i.Stan);
            Ime = i.Ime;
        }
    }
}
