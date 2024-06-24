using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZgradaLibrary.DTOs;

public class AngazovanjePregled
{
    public ZgradaPregled? Zgrada { get; set; }
    public ZaposleniPregled? Upravnik { get; set; }

    public AngazovanjePregled()
    {

    }

    public AngazovanjePregled(ZgradaPregled zgrada, ZaposleniPregled upravnik)
    {
        Zgrada = zgrada;
        Upravnik = upravnik;
    }

    internal AngazovanjePregled(Angazovanje? a)
    {
        if(a != null)
        {
            Zgrada = new(a.Zgrada);
            Upravnik = new(a.Upravnik);
        }
    }
}
