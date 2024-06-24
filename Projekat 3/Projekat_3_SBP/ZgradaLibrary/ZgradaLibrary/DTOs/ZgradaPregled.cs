using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZgradaLibrary.DTOs;

public class ZgradaPregled
{
    public int ID { get; set; }
    public string? Adresa { get; set; }
    public List<ZaposleniPregled>? Upravnici { get; set; }
    public List<UgovorPregled>? Ugovori { get; set; }
    public List<UlazPregled>? Ulazi { get; set; }
    public List<LiftPregled>? Liftovi { get; set; }
    public List<SpratPregled>? Spratovi { get; set; }
    public List<ProstorPregled>? Prostori { get; set; }
    public List<SkupstinaStanaraPregled>? VlasniciStanova { get; set; }

    public ZgradaPregled()
    {

    }

    internal ZgradaPregled(Zgrada? z)
    {
        if(z != null)
        {
            ID = z.ID;
            Adresa = z.Adresa;
            Upravnici = new();
            Ugovori = new();
            Ulazi = new();
            Liftovi = new();
            Spratovi = new();
            Prostori = new();
            VlasniciStanova = new();

            foreach (Zaposleni u in z.Upravnici)    
            {
                Upravnici.Add(new ZaposleniPregled(u));
            }

            foreach (Ugovor u in z.Ugovori)
            {
                Ugovori.Add(new UgovorPregled(u));
            }

            foreach (Ulaz u in z.Ulazi)
            {
                Ulazi.Add(new UlazPregled(u));
            }

            foreach (Lift l in z.Liftovi)
            {
                if(String.Compare(l.Tip, "Teretni", true) == 0)
                {
                    Liftovi.Add(new LiftTeretniPregled((LiftTeretni)l));
                }
                else
                {
                    Liftovi.Add(new LiftZaLjudePregled((LiftZaLjude)l));
                }
            }

            foreach (Sprat s in z.Spratovi)
            {
                Spratovi.Add(new SpratPregled(s));
            }

            foreach (Prostor p in z.Prostori)
            {
                if(String.Compare(p.Tip, "Lokal", true) == 0)
                {
                    Prostori.Add(new LokalPregled((Lokal)p));
                }
                else if(String.Compare(p.Tip, "Parking", true) == 0)
                {
                    Prostori.Add(new ParkingPregled((Parking)p));
                }
                else
                {
                    Prostori.Add(new StanPregled((Stan)p));
                }
            }

            foreach (SkupstinaStanara s in z.VlasniciStanova)
            {
                VlasniciStanova.Add(new SkupstinaStanaraPregled(s));
            }
        }
    }
}
