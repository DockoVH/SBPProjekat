using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZgradaLibrary.DTOs;

public class TelefonPregled
{
    public int ID { get; set; }
    public OsobaPregled? Osoba { get; set; }
    public string? BrojTelefona { get; set; }

    public TelefonPregled()
    {

    }
    public TelefonPregled(int id, OsobaPregled osoba, string brojTelefona)
    {
        ID = id;
        Osoba = osoba;
        BrojTelefona = brojTelefona;
    }

    internal TelefonPregled(Telefon? t)
    {
        if(t != null)
        {
            ID = t.ID;
            Osoba = new(t.Osoba);
            BrojTelefona = t.BrojTelefona;
        }
    }
}
