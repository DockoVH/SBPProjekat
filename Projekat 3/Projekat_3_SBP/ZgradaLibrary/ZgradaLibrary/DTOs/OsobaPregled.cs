using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZgradaLibrary.DTOs;

public class OsobaPregled
{
    public string? JMBG { get; set; }
    public string? Adresa { get; set; }
    public string? PunoIme { get; set; }
    public List<TelefonPregled>? BrojeviTelefona { get; set; }

    public OsobaPregled()
    {
        BrojeviTelefona = new();
    }

    public OsobaPregled(string jMBG, string adresa, string punoIme)
    {
        JMBG = jMBG;
        Adresa = adresa;
        PunoIme = punoIme;
        BrojeviTelefona = new();
    }

    internal OsobaPregled(Osoba? o)
    {
        if(o != null)
        {
            JMBG = o.JMBG;
            Adresa = o.Adresa;
            PunoIme = $"{o.LIme} ({o.ImeRoditelja}) {o.Prezime}";
            BrojeviTelefona = new();

            if(o.BrojeviTelefona != null)
            {
                foreach(Telefon broj in o.BrojeviTelefona)
                {
                    BrojeviTelefona.Add(new TelefonPregled(broj));
                }
            }
        }
    }
}
