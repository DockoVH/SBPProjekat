using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZgradaLibrary.DTOs;

public class SkupstinaStanaraPregled
{
    public int ID { get; set; }
    public ZgradaPregled? Zgrada { get; set; }
    public VlasnikPregled? Vlasnik { get; set; }
    public string? Funkcija { get; set; }

    public SkupstinaStanaraPregled()
    {

    }

    public SkupstinaStanaraPregled(int id, ZgradaPregled zgrada, VlasnikPregled vlasnik, string funkcija)
    {
        ID = id;
        Zgrada = zgrada;
        Vlasnik = vlasnik;
        Funkcija = funkcija;
    }

    internal SkupstinaStanaraPregled(SkupstinaStanara? s)
    {
        if(s != null)
        {
            ID = s.ID;
            Zgrada = new(s.Zgrada);
            Vlasnik = new(s.Vlasnik);
            Funkcija = s.Funkcija;
        }
    }
}
